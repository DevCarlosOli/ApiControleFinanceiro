using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiControleFinanceiro.Migrations
{
    public partial class AjustandoEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    idcategoria = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.idcategoria);
                });

            migrationBuilder.CreateTable(
                name: "subcategoria",
                columns: table => new
                {
                    idsubcategoria = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(maxLength: 100, nullable: true),
                    IdCategoria = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategoria", x => x.idsubcategoria);
                    table.ForeignKey(
                        name: "FK_subcategoria_categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "categoria",
                        principalColumn: "idcategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lancamento",
                columns: table => new
                {
                    idlancamento = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    valor = table.Column<double>(nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    IdSubcategoria = table.Column<long>(nullable: false),
                    comentario = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamento", x => x.idlancamento);
                    table.ForeignKey(
                        name: "FK_lancamento_subcategoria_IdSubcategoria",
                        column: x => x.IdSubcategoria,
                        principalTable: "subcategoria",
                        principalColumn: "idsubcategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoria_nome",
                table: "categoria",
                column: "nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_lancamento_IdSubcategoria",
                table: "lancamento",
                column: "IdSubcategoria");

            migrationBuilder.CreateIndex(
                name: "IX_subcategoria_IdCategoria",
                table: "subcategoria",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lancamento");

            migrationBuilder.DropTable(
                name: "subcategoria");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
