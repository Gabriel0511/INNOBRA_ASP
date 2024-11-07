using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INNOBRA_ASP.DB.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicioPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Obra_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presupuestos_Obras_Obra_Id",
                        column: x => x.Obra_Id,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unidad_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTipos_Unidades_Unidad_Id",
                        column: x => x.Unidad_Id,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Unidad_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recursos_Unidades_Unidad_Id",
                        column: x => x.Unidad_Id,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tiempo_estimado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Material_estimado = table.Column<int>(type: "int", nullable: false),
                    Item_Tipos_Id = table.Column<int>(type: "int", nullable: false),
                    Presupuesto_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemTipos_Item_Tipos_Id",
                        column: x => x.Item_Tipos_Id,
                        principalTable: "ItemTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Presupuestos_Presupuesto_Id",
                        column: x => x.Presupuesto_Id,
                        principalTable: "Presupuestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTipoRenglones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Tipos_Id = table.Column<int>(type: "int", nullable: false),
                    Recurso_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTipoRenglones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTipoRenglones_ItemTipos_Item_Tipos_Id",
                        column: x => x.Item_Tipos_Id,
                        principalTable: "ItemTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemTipoRenglones_Recursos_Recurso_Id",
                        column: x => x.Recurso_Id,
                        principalTable: "Recursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaterialEjecutado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaFinalizacionReal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Recurso_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avances_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avances_Recursos_Recurso_Id",
                        column: x => x.Recurso_Id,
                        principalTable: "Recursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemRenglones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialPrevisto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Recursos_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRenglones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRenglones_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemRenglones_Recursos_Recursos_Id",
                        column: x => x.Recursos_Id,
                        principalTable: "Recursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avances_Item_Id",
                table: "Avances",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Avances_Recurso_Id",
                table: "Avances",
                column: "Recurso_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRenglones_Item_Id",
                table: "ItemRenglones",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRenglones_Recursos_Id",
                table: "ItemRenglones",
                column: "Recursos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Item_Tipos_Id",
                table: "Items",
                column: "Item_Tipos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Presupuesto_Id",
                table: "Items",
                column: "Presupuesto_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTipoRenglones_Item_Tipos_Id",
                table: "ItemTipoRenglones",
                column: "Item_Tipos_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTipoRenglones_Recurso_Id",
                table: "ItemTipoRenglones",
                column: "Recurso_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTipos_Unidad_Id",
                table: "ItemTipos",
                column: "Unidad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_Obra_Id",
                table: "Presupuestos",
                column: "Obra_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_Unidad_Id",
                table: "Recursos",
                column: "Unidad_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avances");

            migrationBuilder.DropTable(
                name: "ItemRenglones");

            migrationBuilder.DropTable(
                name: "ItemTipoRenglones");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Recursos");

            migrationBuilder.DropTable(
                name: "ItemTipos");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Obras");
        }
    }
}
