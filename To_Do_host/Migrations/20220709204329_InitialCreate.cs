using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_wpfweb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "To_Do_DataBase_List",
                columns: table => new
                {
                    TitleId = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Plan = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_To_Do_DataBase_List", x => x.TitleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "To_Do_DataBase_List");
        }
    }
}
