using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barbearia.Migrations
{
    public partial class taltal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", maxLength: 128, nullable: false),
                    ClienteId = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    BarbeariaId = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    BarbeiroId = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    ServicoId = table.Column<int>(type: "int", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");
        }
    }
}
