using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSMA_Proyecto.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCocteles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cocteles",
                columns: table => new
                {
                    IDCocteles = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coctel = table.Column<int>(type: "int", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio_Coctel = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocteles", x => x.IDCocteles);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cocteles");
        }
    }
}
