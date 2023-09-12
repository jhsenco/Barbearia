using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    public partial class VinculoBarbeiroServico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarbeiroId",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_BarbeiroId",
                table: "Servicos",
                column: "BarbeiroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Barbeiros_BarbeiroId",
                table: "Servicos",
                column: "BarbeiroId",
                principalTable: "Barbeiros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Barbeiros_BarbeiroId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_BarbeiroId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "BarbeiroId",
                table: "Servicos");
        }
    }
}
