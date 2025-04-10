using DMMAffiDBEntity.Entities.Master;
using DMMAffiDBEntity.Entities.Transaction;
using Microsoft.EntityFrameworkCore;

namespace DMMAffiDBEntity
{
    /// <summary>
    /// アプリケーションDBコンテキスト
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<MAffiliateUser> MAffiliateUsers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            // DB接続
            optionsBuilder.UseNpgsql ( "Host=localhost;Port=5433;Database=dmm_affi;Username=postgres;Password=postgres;" );
            // 時間設定
            AppContext.SetSwitch ( "Npgsql.EnableLegacyTimestampBehavior" , true );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating ( ModelBuilder modelBuilder )
        {
            #region マスタ
            // アフィリエイトユーザマスタ定義
            modelBuilder.Entity<MAffiliateUser> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "m_affiliate_user_PKC" );
                entity.HasQueryFilter ( x => !x.IsDeleted );
            } );
            #endregion

            #region システム
            #endregion

            #region トランザクション
            // 商品テーブル
            modelBuilder.Entity<TProduct> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "t_product_PKC" );
                entity.Property ( x => x.Id ).HasColumnType ( "bigserial" );
                entity.Property ( x => x.ProductContent ).HasColumnType ( "jsonb" );
            } );
            #endregion
        }
    }
}
