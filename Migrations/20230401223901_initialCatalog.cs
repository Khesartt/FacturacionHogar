using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FacturacionHogar.Migrations
{
    public partial class initialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "varchar(500)", nullable: true),
                    cedula = table.Column<string>(type: "varchar(500)", nullable: true),
                    celular = table.Column<string>(type: "varchar(500)", nullable: true),
                    correo = table.Column<string>(type: "varchar(500)", nullable: true),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parametric",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "varchar(500)", nullable: true),
                    valor = table.Column<string>(type: "varchar(500)", nullable: true),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parametric", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reciboArrendamiento",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valorArrendamiento = table.Column<string>(type: "varchar(500)", nullable: true),
                    numeroRecibo = table.Column<string>(type: "varchar(500)", nullable: true),
                    fechaRecibo = table.Column<DateTime>(type: "datetime", nullable: false),
                    nombreCliente = table.Column<string>(type: "varchar(500)", nullable: true),
                    valorArrendamientoLetra = table.Column<string>(type: "varchar(500)", nullable: true),
                    descripcionArrendamiento = table.Column<string>(type: "varchar(500)", nullable: true),
                    direccionArrendamiento = table.Column<string>(type: "varchar(500)", nullable: true),
                    fechaInicial = table.Column<DateTime>(type: "datetime", nullable: false),
                    fechaFinal = table.Column<DateTime>(type: "datetime", nullable: false),
                    idCliente = table.Column<long>(type: "bigint", nullable: false),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reciboArrendamiento", x => x.id);
                    table.ForeignKey(
                        name: "FK_reciboCliente",
                        column: x => x.idCliente,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicio",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medicionBackUp = table.Column<string>(type: "varchar(500)", nullable: true),
                    medicionAnterior = table.Column<string>(type: "varchar(500)", nullable: true),
                    medicionActual = table.Column<string>(type: "varchar(500)", nullable: true),
                    idCliente = table.Column<long>(type: "bigint", nullable: false),
                    idParametric = table.Column<long>(type: "bigint", nullable: false),
                    fechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicio", x => x.id);
                    table.ForeignKey(
                        name: "FK_servicioCliente",
                        column: x => x.idCliente,
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_servicioParametric",
                        column: x => x.idParametric,
                        principalTable: "parametric",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_reciboArrendamiento_idCliente",
                table: "reciboArrendamiento",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_servicio_idCliente",
                table: "servicio",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_servicio_idParametric",
                table: "servicio",
                column: "idParametric");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reciboArrendamiento");

            migrationBuilder.DropTable(
                name: "servicio");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "parametric");
        }
    }
}
