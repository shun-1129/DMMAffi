using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMMAffiDBEntity.Migrations
{
    /// <inheritdoc />
    public partial class DBMigration_Ver002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_product");
        }
    }
}
