using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class gobadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientID",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Projects_ProjectID",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProjectID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "Invoices");

            migrationBuilder.AddColumn<float>(
                name: "GobPrice",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "ClientID",
                table: "Invoices",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGob",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientID",
                table: "Invoices",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Clients_ClientID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "GobPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsGob",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "ClientID",
                table: "Invoices",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ProjectID",
                table: "Invoices",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    ClientID = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PersonInCharge = table.Column<string>(type: "text", nullable: false),
                    PersonInChargePhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectID",
                table: "Invoices",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Clients_ClientID",
                table: "Invoices",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Projects_ProjectID",
                table: "Invoices",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ID");
        }
    }
}
