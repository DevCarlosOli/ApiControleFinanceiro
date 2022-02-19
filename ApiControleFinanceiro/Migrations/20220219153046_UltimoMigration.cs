using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiControleFinanceiro.Migrations
{
    public partial class UltimoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    idcategoria = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nome = table.Column<string>(maxLength: 30, nullable: false)
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nome = table.Column<string>(maxLength: 30, nullable: false),
                    CategoriaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategoria", x => x.idsubcategoria);
                    table.ForeignKey(
                        name: "FK_subcategoria_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "idcategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lancamento",
                columns: table => new
                {
                    idlancamento = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    valor = table.Column<decimal>(nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    SubcategoriaId = table.Column<long>(nullable: false),
                    comentario = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamento", x => x.idlancamento);
                    table.ForeignKey(
                        name: "FK_lancamento_subcategoria_SubcategoriaId",
                        column: x => x.SubcategoriaId,
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
                name: "IX_lancamento_SubcategoriaId",
                table: "lancamento",
                column: "SubcategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_subcategoria_CategoriaId",
                table: "subcategoria",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_subcategoria_nome",
                table: "subcategoria",
                column: "nome",
                unique: true);
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
