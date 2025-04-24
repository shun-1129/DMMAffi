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
        public DbSet<MSite> MSites { get; set; }
        /// <summary>
        /// サービスマスタ
        /// </summary>
        public DbSet<MService> MServices { get; set; }
        /// <summary>
        /// フロアマスタ
        /// </summary>
        public DbSet<MFloor> MFloors { get; set; }
        /// <summary>
        /// ジャンルマスタ
        /// </summary>
        public DbSet<MGenre> MGenres { get; set; }
        #endregion

        #region システム
        #endregion

        #region トランザクション
        /// <summary>
        /// マスタ管理テーブル
        /// </summary>
        public DbSet<TMasterManagement> TMasterManagements { get; set; }
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
            // サイトマスタ定義
            modelBuilder.Entity<MSite> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "m_site_PKC" );
                entity.Property ( x => x.Id ).HasColumnType ( "serial" );
                entity.HasQueryFilter ( x => !x.IsDeleted );
            } );
            // サービスマスタ定義
            modelBuilder.Entity<MService> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "m_service_PKC" );
                entity.Property ( x => x.Id ).HasColumnType ( "serial" );
                entity.HasQueryFilter ( x => !x.IsDeleted );
            } );
            // フロアマスタ定義
            modelBuilder.Entity<MFloor> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "m_floor_PKC" );
                entity.Property ( x => x.Id ).HasColumnType ( "serial" );
                entity.HasQueryFilter ( x => !x.IsDeleted );
            } );
            // ジャンルマスタ定義
            modelBuilder.Entity<MGenre> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "m_genre_PKC" );
                entity.Property ( x => x.Id ).HasColumnType ( "serial" );
                entity.HasQueryFilter ( x => !x.IsDeleted );
            } );
            #endregion

            #region システム
            #endregion

            #region トランザクション
            // マスタ管理テーブル定義
            modelBuilder.Entity<TMasterManagement> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "t_mastar_management_PKC" );
            } );
            // 商品テーブル定義
            modelBuilder.Entity<TProduct> ( entity =>
            {
                entity.HasKey ( x => x.Id ).HasName ( "t_product_PKC" );
            } );
            // 商品詳細テーブル定義
            modelBuilder.Entity<TProductDetail> ( entity =>
            {
                entity.HasKey ( x => x.TProductId ).HasName ( "t_product_detail_PKC" );
            } );
            #endregion
        }
        #endregion
    }
}
