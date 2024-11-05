using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSMA_Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarComida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comida",
                columns: table => new
                {
                    IDPlato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plato = table.Column<int>(type: "int", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio_Comida = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comida", x => x.IDPlato);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comida");
        }
    }
}
