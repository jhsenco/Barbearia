using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    public partial class Aula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbearias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barbearias");
        }
    }
}
