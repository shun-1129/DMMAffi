using DMMAffiDBEntity.Entities.Master;

namespace MasterDataCreator.Infrastructures.Interface
{
    public interface IDBAccessor
    {
        int SaveChanges ();
        Task<int> SaveChangesAsync ( CancellationToken cancellationToken = default );
        Task<List<MAffiliateUser>> GetAffiliateUsersAsync ();
        Task InsertMFloor ( List<MFloor> mFloorList );
    }
}
