using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiControleFinanceiro.Migrations
{
    public partial class AjustandoCategoria02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_subcategoria_id",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_subcategoria_categoria_id",
                table: "subcategoria");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "subcategoria",
                newName: "idsubcategoria");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "lancamento",
                newName: "idlancamento");

            migrationBuilder.AlterColumn<long>(
                name: "idsubcategoria",
                table: "subcategoria",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "idlancamento",
                table: "lancamento",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "idcategoria",
                table: "categoria",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_subcategoria_idlancamento",
                table: "lancamento",
                column: "idlancamento",
                principalTable: "subcategoria",
                principalColumn: "idsubcategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subcategoria_categoria_idsubcategoria",
                table: "subcategoria",
                column: "idsubcategoria",
                principalTable: "categoria",
                principalColumn: "idcategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lancamento_subcategoria_idlancamento",
                table: "lancamento");

            migrationBuilder.DropForeignKey(
                name: "FK_subcategoria_categoria_idsubcategoria",
                table: "subcategoria");

            migrationBuilder.RenameColumn(
                name: "idsubcategoria",
                table: "subcategoria",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "idlancamento",
                table: "lancamento",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "subcategoria",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "lancamento",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "idcategoria",
                table: "categoria",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_lancamento_subcategoria_id",
                table: "lancamento",
                column: "id",
                principalTable: "subcategoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subcategoria_categoria_id",
                table: "subcategoria",
                column: "id",
                principalTable: "categoria",
                principalColumn: "idcategoria",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
