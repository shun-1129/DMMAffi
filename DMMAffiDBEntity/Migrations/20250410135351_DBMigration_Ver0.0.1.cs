using System;
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_affiliate_user");
        }
    }
}
