using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INNOBRA_ASP.DB.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidad_Id",
                table: "Recursos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unidad_Id",
                table: "Recursos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
