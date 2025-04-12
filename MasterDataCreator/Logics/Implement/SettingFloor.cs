using DMMAffiDBEntity;
using DMMAffiDBEntity.Entities.Master;
using DMMAffiDBEntity.Entities.Transaction;
using DMMLibrary;
using DMMLibrary.Models.Data;
using MasterDataCreator.Infrastructures.Interface;
using MasterDataCreator.Logics.Interface;
using System.Text.Json;

namespace MasterDataCreator.Logics.Implement
{
    internal class SettingFloor : ISettingFloor
    {
        private MasterDataStore _masterDataStore;
        private IDBAccessor _dbAccessor;

        private List<MFloor> _floorList = new List<MFloor> ();
        private List<MFloorDetail> _floorDetailList = new List<MFloorDetail> ();

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="masterDataStore"></param>
        private SettingFloor ( MasterDataStore masterDataStore , IDBAccessor dbAccessor )
        {
            _masterDataStore = masterDataStore;
            _dbAccessor = dbAccessor;
        }

        public static ISettingFloor CreateInstance ( MasterDataStore masterDataStore , IDBAccessor dbAccessor)
        {
            return new SettingFloor ( masterDataStore , dbAccessor );
        }

        public async Task Executor ()
        {
            List<MAffiliateUser> mAffiliateUsers = _masterDataStore.Get<List<MAffiliateUser>> () ?? new List<MAffiliateUser> ();
            if ( !HasExecute ( mAffiliateUsers ) )
            {
                return;
            }

            MAffiliateUser mAffiliateUser = mAffiliateUsers[0];

            DMMAPI dmmAPI = new DMMAPI ( mAffiliateUser.AIPId , mAffiliateUser.AffiliateId );
            List<Site> siteList = await dmmAPI.SearchFloor ();

            CreateFloorData ( siteList );
            await _dbAccessor.InsertMFloor ( _floorList );
            CreateFloorDetailData ( siteList );
            await _dbAccessor.InsertMFloorDetail ( _floorDetailList );
            int resultCount = _dbAccessor.SaveChanges ();
            if ( resultCount > 0 )
            {
                DateTime dateTime = DateTime.Now;
                TMasterManagement masterManagement = _masterDataStore.Get<TMasterManagement> ()!;
                masterManagement.MasterChangeDate = dateTime;
                masterManagement.UpdatedDate = dateTime;
                masterManagement.UpdateUser = "System";
                masterManagement.UpdateProgram = "System";

                resultCount = _dbAccessor.SaveChanges ();
                int hoge = 0;
            }
            else
            {
                int hoge = 0;
            }
        }

        private bool HasExecute ( List<MAffiliateUser> mAffiliateUsers )
        {
            if ( mAffiliateUsers.Count == 0 )
            {
                return false;
            }

            if ( mAffiliateUsers[0] == null )
            {
                return false;
            }

            return true;
        }

        private void CreateFloorData ( List<Site> sites )
        {
            foreach ( Site site in sites )
            {
                DateTime dateTime = DateTime.Now;
                JsonDocument jsonDocument = JsonDocumentExpansion.ConvertModelToJsonDocument ( site );
                MFloor mFloor = new MFloor ()
                {
                    DMMSiteName = site.name,
                    DMMSiteCode = site.code,
                    Content = jsonDocument,
                    CreatedDate = dateTime,
                    CreateUser = "System",
                    CreateProgram = "System",
                    UpdatedDate = dateTime,
                    UpdateUser = "System",
                    UpdateProgram = "System",
                    IsDeleted = false,
                };

                _floorList.Add ( mFloor );
            }
        }
    
        private void CreateFloorDetailData ( List<Site> sites )
        {
            DateTime dateTime = DateTime.Now;
            foreach ( Site site in sites )
            {
                MFloor? mFloor = _floorList.Find ( x => x.DMMSiteName == site.name );
                if ( mFloor == null )
                {
                    continue;
                }

                foreach ( Service service in site.service )
                {
                    foreach ( Floor floor in service.floor )
                    {
                        MFloorDetail mFloorDetail = new MFloorDetail ()
                        {
                            FloorId = mFloor.Id,
                            DMMServiceName = service.name,
                            DMMServiceCode = service.code,
                            DMMFloorId = floor.id,
                            DMMFloorName = floor.name,
                            DMMFloorCode = floor.code,
                            CreatedDate = dateTime,
                            CreateUser = "System",
                            CreateProgram= "System",
                            UpdatedDate = dateTime,
                            UpdateUser = "System",
                            UpdateProgram = "System",
                            IsDeleted = false
                        };

                        _floorDetailList.Add ( mFloorDetail );
                    }
                }
            }
        }
    }
}
