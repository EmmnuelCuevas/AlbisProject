using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class newentityncfadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NCFs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    GobNCF = table.Column<string>(type: "text", nullable: false),
                    NormalNCF = table.Column<string>(type: "text", nullable: false),
                    ActualNCF = table.Column<int>(type: "integer", nullable: false),
                    StartNCF = table.Column<int>(type: "integer", nullable: false),
                    EndNCF = table.Column<int>(type: "integer", nullable: false),
                    ActualGobNCF = table.Column<int>(type: "integer", nullable: false),
                    StartGobNCF = table.Column<int>(type: "integer", nullable: false),
                    EndGobNCF = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCFs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NCFs");
        }
    }
}
