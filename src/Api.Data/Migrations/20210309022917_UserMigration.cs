using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    nome = table.Column<string>(maxLength: 60, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "email", "nome", "UpdateAt" },
                values: new object[] { new Guid("c76a1dcc-12fd-40f3-a9ec-5c8b297fc0c4"), new DateTime(2021, 3, 8, 23, 29, 17, 759, DateTimeKind.Local).AddTicks(6912), "emailAdmin@email.com", "Admnistrador", new DateTime(2021, 3, 8, 23, 29, 17, 760, DateTimeKind.Local).AddTicks(4332) });

            migrationBuilder.CreateIndex(
                name: "IX_User_email",
                table: "User",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
