using DMMAffiDBEntity;
using DMMAffiDBEntity.Entities.Master;
using DMMAffiDBEntity.Entities.Transaction;
using MasterDataCreator.Infrastructures.Interface;
using MasterDataCreator.Logics.Implement;
using MasterDataCreator.Logics.Interface;

namespace MasterDataCreator
{
    public class Worker
    {
        private IDBAccessor _dbAccessor;
        private MasterDataStore _masterDataStore;

        public Worker ( IDBAccessor dbAccessor )
        {
            _dbAccessor = dbAccessor;
            _masterDataStore = new MasterDataStore ();
        }

        public async Task ExecuteAsync ()
        {
            await GetMasterData ();
            ISettingFloor settingFloor = SettingFloor.CreateInstance ( _masterDataStore , _dbAccessor );
            await settingFloor.Executor ();
        }

        /// <summary>
        /// マスタデータ取得
        /// </summary>
        /// <returns></returns>
        private async Task GetMasterData ()
        {
            TMasterManagement? masterManagement = await _dbAccessor.GetMasterManagementAsync ( 1 );
            DateTime dateTime = DateTime.Now;

            if ( masterManagement != null )
            {
                _masterDataStore.Set ( masterManagement );
            }

            if ( masterManagement == null || masterManagement.MasterChangeDate.CompareTo ( dateTime ) < 0 )
            {
                _masterDataStore.Set ( await _dbAccessor.GetAffiliateUsersAsync () );
                _masterDataStore.Set ( await _dbAccessor.GetMFloorsAsync () );
                _masterDataStore.Set ( await _dbAccessor.GetFloorDetailsAsync () );
            }
        }
    }
}
