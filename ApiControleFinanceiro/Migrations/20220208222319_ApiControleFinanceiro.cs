using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiControleFinanceiro.Migrations
{
    public partial class ApiControleFinanceiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    idcategoria = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    id = table.Column<int>(nullable: false),
                    nome = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategoria", x => x.id);
                    table.ForeignKey(
                        name: "FK_subcategoria_categoria_id",
                        column: x => x.id,
                        principalTable: "categoria",
                        principalColumn: "idcategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lancamento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    valor = table.Column<double>(nullable: false),
                    data = table.Column<DateTime>(type: "date", nullable: false),
                    comentario = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lancamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_lancamento_subcategoria_id",
                        column: x => x.id,
                        principalTable: "subcategoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
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
