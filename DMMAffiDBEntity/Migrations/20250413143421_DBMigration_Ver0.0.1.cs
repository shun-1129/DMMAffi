using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMMAffiDBEntity.Migrations
{
    /// <inheritdoc />
    public partial class DBMigration_Ver001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_affiliate_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "アフィリエイトユーザマスタID:【値例】1"),
                    api_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "APIID:【値例】"),
                    affiliate_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "アフィリエイトID:【値例】"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "論理削除:【値例】false：未削除 , true：削除済み"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_affiliate_user_PKC", x => x.id);
                },
                comment: "アフィリエイトユーザマスタ");

            migrationBuilder.CreateTable(
                name: "m_floor",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false, comment: "フロアマスタID"),
                    m_site_id = table.Column<int>(type: "integer", nullable: false, comment: "サイトマスタID:【値例】1"),
                    m_service_id = table.Column<int>(type: "integer", nullable: false, comment: "サービスマスタID:【値例】1"),
                    floor_id = table.Column<int>(type: "integer", nullable: false, comment: "フロアID:【値例】1"),
                    floor_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "フロア名:【値例】"),
                    floor_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "フロアコード:【値例】"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "論理削除:【値例】false：未削除 , true：削除済み"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_floor_PKC", x => x.id);
                },
                comment: "フロアマスタ");

            migrationBuilder.CreateTable(
                name: "m_genre",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false, comment: "ジャンルマスタID:【値例】1"),
                    m_floor_id = table.Column<int>(type: "integer", nullable: false, comment: "フロアマスタID:【値例】1"),
                    genre_id = table.Column<int>(type: "integer", nullable: false, comment: "ジャンルID"),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "ジャンル名称"),
                    ruby = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "ジャンル名称(読み仮名)"),
                    list_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false, comment: "リストページURL:アフィリエイトID付き"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "論理削除:【値例】false：未削除 , true：削除済み"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_genre_PKC", x => x.id);
                },
                comment: "ジャンルマスタ");

            migrationBuilder.CreateTable(
                name: "m_service",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false, comment: "サービスマスタID:【値例】1"),
                    service_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "サービス名称:【値例】AKBグループ"),
                    service_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "サービスコード:【値例】"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "論理削除:【値例】false：未削除 , true：削除済み"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_service_PKC", x => x.id);
                },
                comment: "サービスマスタ");

            migrationBuilder.CreateTable(
                name: "m_site",
                columns: table => new
                {
                    id = table.Column<int>(type: "serial", nullable: false, comment: "サイトマスタID:【値例】1"),
                    site_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "サイト名称"),
                    site_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "サイトコード"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, comment: "論理削除:【値例】false：未削除 , true：削除済み"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("m_site_PKC", x => x.id);
                },
                comment: "サイトマスタ");

            migrationBuilder.CreateTable(
                name: "t_master_management",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "マスタ管理ID:【値例】1"),
                    master_change_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "マスタ更新日時:【値例】2025/04/01 00:00:00"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_mastar_management_PKC", x => x.id);
                },
                comment: "マスタ管理テーブル");

            migrationBuilder.CreateTable(
                name: "t_product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigserial", nullable: false, comment: "商品ID:【値例】1"),
                    product_content = table.Column<JsonDocument>(type: "jsonb", nullable: false, comment: "商品内容:【値例】"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_product_PKC", x => x.id);
                },
                comment: "商品テーブル");

            migrationBuilder.CreateTable(
                name: "t_product_detail",
                columns: table => new
                {
                    t_product_id = table.Column<long>(type: "bigint", nullable: false, comment: "商品ID:【値例】1"),
                    content_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "商品ID:【値例】15dss00145"),
                    product_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "品番ID:【値例】15dss00145dl"),
                    title = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false, comment: "タイトル:【値例】タイトル"),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "作成日時:【値例】2025/01/01 00:00:00"),
                    create_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "作成者:【値例】System"),
                    create_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "作成プログラム:【値例】System"),
                    update_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "更新日時:【値例】2025/01/01 00:00:00"),
                    update_user = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "更新者:【値例】System"),
                    update_program = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "更新プログラム:【値例】System")
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_product_detail_PKC", x => x.t_product_id);
                },
                comment: "商品詳細テーブル");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_affiliate_user");

            migrationBuilder.DropTable(
                name: "m_floor");

            migrationBuilder.DropTable(
                name: "m_genre");

            migrationBuilder.DropTable(
                name: "m_service");

            migrationBuilder.DropTable(
                name: "m_site");

            migrationBuilder.DropTable(
                name: "t_master_management");

            migrationBuilder.DropTable(
                name: "t_product");

            migrationBuilder.DropTable(
                name: "t_product_detail");
        }
    }
}
