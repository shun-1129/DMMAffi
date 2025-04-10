using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMMAffiDBEntity.Migrations
{
    /// <inheritdoc />
    public partial class DBMigration_Ver003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "t_product_detail");
        }
    }
}
