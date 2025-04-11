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
                    id = table.Column<int>(type: "integer", nullable: false, comment: "フロアマスタID:【値例】1"),
                    dmm_site_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "DMM サイト名"),
                    dmm_site_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "DMM サイトコード"),
                    content = table.Column<JsonDocument>(type: "jsonb", nullable: false, comment: "コンテンツ:【値例】"),
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
                name: "m_floor_detail",
                columns: table => new
                {
                    m_floor_id = table.Column<int>(type: "integer", nullable: false, comment: "フロアマスタID"),
                    dmm_floor_id = table.Column<int>(type: "integer", nullable: false, comment: "DMM フロアID"),
                    dmm_service_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "DMM サービス名"),
                    dmm_service_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "DMM サービスコード"),
                    dmm_floor_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true, comment: "DMM フロア名"),
                    dmm_floor_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "DMM フロアコード"),
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
                    table.PrimaryKey("m_floor_detail_PKC", x => new { x.m_floor_id, x.dmm_floor_id, x.dmm_service_name });
                },
                comment: "フロア詳細マスタ");

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
                    dmm_content_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "DMM 商品ID:【値例】15dss00145"),
                    dmm_product_id = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false, comment: "DMM 品番ID:【値例】15dss00145dl"),
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
                name: "m_floor_detail");

            migrationBuilder.DropTable(
                name: "t_product");

            migrationBuilder.DropTable(
                name: "t_product_detail");
        }
    }
}
