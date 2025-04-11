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
        #region メンバ変数
        /// <summary>
        /// DB接続文字列
        /// </summary>
        private string _connectionStrings = "Host=localhost;Port=5433;Database=dmm_affi;Username=postgres;Password=postgres;";
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        /// <param name="connectionStrings"></param>
        public ApplicationDbContext ( string connectionStrings ) => _connectionStrings = connectionStrings;
        #endregion

        #region DbSet
        #region マスタ
        /// <summary>
        /// アフィリエイトユーザマスタ
        /// </summary>
        public DbSet<MAffiliateUser> MAffiliateUsers { get; set; }
        /// <summary>
        /// フロアマスタ
        /// </summary>
        public DbSet<MFloor> MFloors { get; set; }
        /// <summary>
        /// フロア詳細マスタ
        /// </summary>
        public DbSet<MFloorDetail> MFloorDetails { get; set; }
        #endregion

        #region システム
        #endregion

        #region トランザクション
        /// <summary>
        /// 商品テーブル
        /// </summary>
        public DbSet<TProduct> TProducts { get; set; }
        /// <summary>
        /// 商品詳細テーブル
        /// </summary>
        public DbSet<TProductDetail> TProductDetails { get; set; }
        #endregion
        #endregion

        #region メソッド
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
        {
            // DB接続
            optionsBuilder.UseNpgsql ( _connectionStrings );
            //optionsBuilder.UseNpgsql ( "Host=localhost;Port=5433;Database=dmm_affi;Username=postgres;Password=postgres;" );
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
            // フロアマスタ定義
            modelBuilder.Entity<MFloor> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "m_floor_PKC" );
                entity.HasQueryFilter ( x => !x.IsDeleted );
            } );
            // フロア詳細マスタ定義
            modelBuilder.Entity<MFloorDetail> ( entity =>
            {
                entity.HasKey ( x => new
                {
                    x.FloorId ,
                    x.DMMFloorId,
                    x.DMMServiceName
                } )
                .HasName ( "m_floor_detail_PKC" );

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
            // 商品詳細テーブル
            modelBuilder.Entity<TProductDetail> ( entity =>
            {
                entity.HasKey ( x => x.ProductId ).HasName ( "t_product_detail_PKC" );
            } );
            #endregion
        }
        #endregion
    }
}
