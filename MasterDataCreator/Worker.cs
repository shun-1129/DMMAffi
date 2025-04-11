using DMMAffiDBEntity;
using DMMAffiDBEntity.Entities.Master;
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

        private async Task GetMasterData ()
        {
            _masterDataStore.Set<List<MAffiliateUser>> ( await _dbAccessor.GetAffiliateUsersAsync () );
        }
    }
}
