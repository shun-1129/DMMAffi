using DMMAffiDBEntity.Entities.Master;
using DMMAffiDBEntity.Entities.Transaction;

namespace MasterDataCreator.Infrastructures.Interface
{
    public interface IDBAccessor
    {
        #region DB操作
        int SaveChanges ();
        Task<int> SaveChangesAsync ( CancellationToken cancellationToken = default );
        #endregion

        #region 取得
        #region マスタデータ
        Task<List<MAffiliateUser>> GetAffiliateUsersAsync ();
        Task<List<MFloor>> GetMFloorsAsync ();
        Task<List<MFloorDetail>> GetFloorDetailsAsync ();
        #endregion
        #region トランザクション
        /// <summary>
        /// マスタ管理テーブル取得
        /// </summary>
        /// <param name="id">取得対象のID</param>
        /// <returns>マスタ管理テーブル</returns>
        Task<TMasterManagement?> GetMasterManagementAsync ( int id );
        #endregion
        #endregion

        #region 挿入
        Task InsertMFloor ( List<MFloor> mFloorList );
        Task InsertMFloorDetail ( List<MFloorDetail> mFloorDetails );
        #endregion

        #region 更新
        #endregion

        #region 削除
        #endregion
    }
}
