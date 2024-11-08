﻿// <auto-generated />
using System;
using INNOBRA_ASP.DB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace INNOBRA_ASP.DB.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Avance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFinalizacionReal")
                        .HasColumnType("datetime2");

                    b.Property<int>("Item_Id")
                        .HasColumnType("int");

                    b.Property<string>("MaterialEjecutado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Recurso_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Item_Id");

                    b.HasIndex("Recurso_Id");

                    b.ToTable("Avances");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Item_Tipos_Id")
                        .HasColumnType("int");

                    b.Property<int>("Material_estimado")
                        .HasColumnType("int");

                    b.Property<int>("Presupuesto_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tiempo_estimado")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Item_Tipos_Id");

                    b.HasIndex("Presupuesto_Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.ItemRenglon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cantidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Items_idItems")
                        .HasColumnType("int");

                    b.Property<string>("MaterialPrevisto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Recursos_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Items_idItems");

                    b.HasIndex("Recursos_Id");

                    b.ToTable("ItemRenglones");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.ItemTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Unidad_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Unidad_Id");

                    b.ToTable("ItemTipos");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.ItemTipoRenglon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Item_Tipos_Id")
                        .HasColumnType("int");

                    b.Property<int>("Recurso_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Item_Tipos_Id");

                    b.HasIndex("Recurso_Id");

                    b.ToTable("ItemTipoRenglones");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Obra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Presupuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaFinPrevista")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioPrevista")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Obra_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Obra_Id");

                    b.ToTable("Presupuestos");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Recurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cantidad")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("Unidad_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Unidad_Id");

                    b.ToTable("Recursos");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Unidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Avance", b =>
                {
                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Item", "Item")
                        .WithMany("Avances")
                        .HasForeignKey("Item_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Recurso", "Recurso")
                        .WithMany("Avances")
                        .HasForeignKey("Recurso_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Item", b =>
                {
                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.ItemTipo", "ItemTipo")
                        .WithMany("Items")
                        .HasForeignKey("Item_Tipos_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Presupuesto", "Presupuesto")
                        .WithMany("Items")
                        .HasForeignKey("Presupuesto_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemTipo");

                    b.Navigation("Presupuesto");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.ItemRenglon", b =>
                {
                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Item", "Item")
                        .WithMany("ItemRenglons")
                        .HasForeignKey("Items_idItems")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Recurso", "Recurso")
                        .WithMany("ItemRenglons")
                        .HasForeignKey("Recursos_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.ItemTipo", b =>
                {
                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Unidad", "Unidad")
                        .WithMany("ItemTipos")
                        .HasForeignKey("Unidad_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Unidad");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.ItemTipoRenglon", b =>
                {
                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.ItemTipo", "ItemTipo")
                        .WithMany("ItemTipoRenglons")
                        .HasForeignKey("Item_Tipos_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Recurso", "Recurso")
                        .WithMany("ItemTipoRenglons")
                        .HasForeignKey("Recurso_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemTipo");

                    b.Navigation("Recurso");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Presupuesto", b =>
                {
                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Obra", "Obra")
                        .WithMany("Presupuestos")
                        .HasForeignKey("Obra_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Recurso", b =>
                {
                    b.HasOne("INNOBRA_ASP.DB.Data.Entity.Unidad", "Unidad")
                        .WithMany("Recursos")
                        .HasForeignKey("Unidad_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Unidad");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Item", b =>
                {
                    b.Navigation("Avances");

                    b.Navigation("ItemRenglons");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.ItemTipo", b =>
                {
                    b.Navigation("ItemTipoRenglons");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Obra", b =>
                {
                    b.Navigation("Presupuestos");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Presupuesto", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Recurso", b =>
                {
                    b.Navigation("Avances");

                    b.Navigation("ItemRenglons");

                    b.Navigation("ItemTipoRenglons");
                });

            modelBuilder.Entity("INNOBRA_ASP.DB.Data.Entity.Unidad", b =>
                {
                    b.Navigation("ItemTipos");

                    b.Navigation("Recursos");
                });
#pragma warning restore 612, 618
        }
    }
}
