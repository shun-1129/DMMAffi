using DMMAffiDBEntity;
using DMMAffiDBEntity.Entities.Master;
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

            await _dbAccessor.InsertMFloor ( CreateFloorData ( siteList ) );
            _dbAccessor.SaveChanges ();
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

        private List<MFloor> CreateFloorData ( List<Site> sites )
        {
            List<MFloor> floorList = new List<MFloor> ();
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

                floorList.Add ( mFloor );
            }

            return floorList;
        }
    }
}
