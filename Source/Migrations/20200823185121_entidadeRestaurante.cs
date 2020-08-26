using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class entidadeRestaurante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RestauranteId",
                table: "Usuario",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Endereco = table.Column<string>(nullable: true),
                    Votos = table.Column<int>(nullable: true),
                    Escolhido = table.Column<bool>(nullable: true),
                    DataUltimaEscolha = table.Column<DateTime>(nullable: true),
                    VotadoNaSemana = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RestauranteId",
                table: "Usuario",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Restaurante_RestauranteId",
                table: "Usuario",
                column: "RestauranteId",
                principalTable: "Restaurante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Restaurante_RestauranteId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_RestauranteId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RestauranteId",
                table: "Usuario");
        }
    }
}
