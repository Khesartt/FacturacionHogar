using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturacionHogar.infraestructure.Migrations
{
    public partial class addLeaseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClientId",
                table: "historiaDeLecturas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "LeaseReceiptType",
                table: "Facturas",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "historiaDeLecturas");

            migrationBuilder.DropColumn(
                name: "LeaseReceiptType",
                table: "Facturas");
        }
    }
}
