using DMMAffiDBEntity;
using DMMAffiDBEntity.Entities.Master;
using MasterDataCreator.Infrastructures.Interface;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MasterDataCreator.Infrastructures.Implement
{
    public class DBAccessor : IDBAccessor
    {
        private const string CONNECT_INFO = "Host=localhost;Port=5433;Database=dmm_affi;Username=postgres;Password=postgres;";

        private ApplicationDbContext _applicationDbContext;

        private DBAccessor ()
        {
            _applicationDbContext = new ApplicationDbContext ( CONNECT_INFO );
        }

        public static IDBAccessor CreateInstance ()
        {
            return new DBAccessor ();
        }

        /// <summary>
        /// DB反映
        /// </summary>
        /// <returns>実行結果数</returns>
        public int SaveChanges ()
        {
            return _applicationDbContext.SaveChanges ();
        }

        /// <summary>
        /// DB反映(非同期)
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>実行結果数</returns>
        public async Task<int> SaveChangesAsync ( CancellationToken cancellationToken = default )
        {
            return await _applicationDbContext.SaveChangesAsync ();
        }

        #region 取得
        #region マスタ
        public async Task<List<MAffiliateUser>> GetAffiliateUsersAsync ()
        {
            return await _applicationDbContext.MAffiliateUsers.ToListAsync ();
        }
        #endregion
        #endregion

        #region 挿入
        public async Task InsertMFloor ( List<MFloor> mFloorList )
        {
            List<string> nameList = mFloorList.Select ( x => x.DMMSiteName ).ToList ();
            List<MFloor> mFloors = await _applicationDbContext.MFloors
                .Where ( x => nameList.Contains ( x.DMMSiteName ) )
                .ToListAsync ();

            MFloor? floor = await _applicationDbContext.MFloors
                .OrderBy ( x => x.Id )
                .LastOrDefaultAsync ();
            int lastId = floor == null ? 0 : floor.Id;

            foreach ( MFloor mFloor in mFloorList )
            {
                if ( mFloors.Any ( x => x.DMMSiteName == mFloor.DMMSiteName ) )
                {
                    continue;
                }

                mFloor.Id = ++lastId;
                _applicationDbContext.MFloors.Add ( mFloor );
            }
        }
        #endregion
    }
}
