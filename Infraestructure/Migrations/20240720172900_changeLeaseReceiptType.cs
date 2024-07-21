using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturacionHogar.infraestructure.Migrations
{
    public partial class changeLeaseReceiptType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "LeaseAmount",
                table: "Facturas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LeaseAmount",
                table: "Facturas",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
