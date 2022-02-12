using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiControleFinanceiro.Migrations
{
    public partial class AjustandoCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_categoria_nome",
                table: "categoria",
                column: "nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_categoria_nome",
                table: "categoria");
        }
    }
}
