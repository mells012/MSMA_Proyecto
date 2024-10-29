﻿// <auto-generated />
using MSMA_Proyecto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MSMA_Proyecto.Migrations
{
    [DbContext(typeof(MSMA_ProyectoContext))]
    [Migration("20241029230330_TablacreadaPrecioTamañoFinal")]
    partial class TablacreadaPrecioTamañoFinal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MSMA_Proyecto.Models.Cervezas", b =>
                {
                    b.Property<int>("IDCerveza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCerveza"));

                    b.Property<double>("AVC")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<int>("Tamaño")
                        .HasColumnType("int");

                    b.HasKey("IDCerveza");

                    b.ToTable("Cervezas");
                });
#pragma warning restore 612, 618
        }
    }
}
