using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INNOBRA_ASP.DB.Migrations
{
    /// <inheritdoc />
    public partial class Correccion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Unidades",
                newName: "Descripcion");

            migrationBuilder.AddColumn<decimal>(
                name: "Costo",
                table: "Unidades",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Costo",
                table: "Unidades");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Unidades",
                newName: "Codigo");
        }
    }
}
