using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturacionHogar.infraestructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(500)", nullable: true),
                    Identification = table.Column<string>(type: "varchar(500)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(500)", nullable: true),
                    Email = table.Column<string>(type: "varchar(500)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "historiaDeLecturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "varchar(500)", nullable: false),
                    SampleDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sample = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiaDeLecturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "varchar(500)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<long>(type: "bigint", nullable: false),
                    LeaseAmount = table.Column<string>(type: "varchar(500)", nullable: true),
                    ReceiptNumber = table.Column<string>(type: "varchar(500)", nullable: true),
                    LeaseAmountInWords = table.Column<string>(type: "varchar(500)", nullable: true),
                    LeaseDescription = table.Column<string>(type: "varchar(500)", nullable: true),
                    LeaseAddress = table.Column<string>(type: "varchar(500)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdClientByLeaseReceipt",
                        column: x => x.IdClient,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturasPorServicio",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastSample = table.Column<decimal>(type: "decimal", nullable: false),
                    CurrentSample = table.Column<decimal>(type: "decimal", nullable: false),
                    IdClient = table.Column<long>(type: "bigint", nullable: false),
                    IdService = table.Column<long>(type: "bigint", nullable: false),
                    CurrentDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturasPorServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdClientBySample",
                        column: x => x.IdClient,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdServiceBySample",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_IdClient",
                table: "Facturas",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_LecturasPorServicio_IdClient",
                table: "LecturasPorServicio",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_LecturasPorServicio_IdService",
                table: "LecturasPorServicio",
                column: "IdService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "historiaDeLecturas");

            migrationBuilder.DropTable(
                name: "LecturasPorServicio");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}
