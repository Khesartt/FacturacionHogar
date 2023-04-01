﻿// <auto-generated />
using System;
using FacturacionHogar.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FacturacionHogar.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FacturacionHogar.Dominio.modelos.Cliente", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cedula")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("celular")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("correo")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("fechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<string>("nombres")
                        .HasColumnType("varchar(500)");

                    b.HasKey("id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("FacturacionHogar.Dominio.modelos.Parametric", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<string>("tipo")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("valor")
                        .HasColumnType("varchar(500)");

                    b.HasKey("id");

                    b.ToTable("parametric");
                });

            modelBuilder.Entity("FacturacionHogar.Dominio.modelos.ReciboArrendamiento", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descripcionArrendamiento")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("direccionArrendamiento")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("fechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("fechaFinal")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("fechaInicial")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("fechaRecibo")
                        .HasColumnType("datetime");

                    b.Property<long>("idCliente")
                        .HasColumnType("bigint");

                    b.Property<string>("nombreCliente")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("numeroRecibo")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("valorArrendamiento")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("valorArrendamientoLetra")
                        .HasColumnType("varchar(500)");

                    b.HasKey("id");

                    b.HasIndex("idCliente");

                    b.ToTable("reciboArrendamiento");
                });

            modelBuilder.Entity("FacturacionHogar.Dominio.modelos.Servicio", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("fechaActualizacion")
                        .HasColumnType("datetime");

                    b.Property<long>("idCliente")
                        .HasColumnType("bigint");

                    b.Property<long>("idParametric")
                        .HasColumnType("bigint");

                    b.Property<string>("medicionActual")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("medicionAnterior")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("medicionBackUp")
                        .HasColumnType("varchar(500)");

                    b.HasKey("id");

                    b.HasIndex("idCliente");

                    b.HasIndex("idParametric");

                    b.ToTable("servicio");
                });

            modelBuilder.Entity("FacturacionHogar.Dominio.modelos.ReciboArrendamiento", b =>
                {
                    b.HasOne("FacturacionHogar.Dominio.modelos.Cliente", null)
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .HasConstraintName("FK_reciboCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FacturacionHogar.Dominio.modelos.Servicio", b =>
                {
                    b.HasOne("FacturacionHogar.Dominio.modelos.Cliente", null)
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .HasConstraintName("FK_servicioCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacturacionHogar.Dominio.modelos.Parametric", null)
                        .WithMany()
                        .HasForeignKey("idParametric")
                        .HasConstraintName("FK_servicioParametric")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
