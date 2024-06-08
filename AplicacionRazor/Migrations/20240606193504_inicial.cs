using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionRazor.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCurso",
                table: "Curso",
                newName: "NombreProducto");

            migrationBuilder.RenameColumn(
                name: "CantidadClases",
                table: "Curso",
                newName: "Stock");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Curso",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Curso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Curso");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Curso",
                newName: "CantidadClases");

            migrationBuilder.RenameColumn(
                name: "NombreProducto",
                table: "Curso",
                newName: "NombreCurso");

            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "Curso",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
