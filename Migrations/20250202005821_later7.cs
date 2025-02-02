using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnambaRepoApi.Migrations
{
    public partial class later7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ScientificArticle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ResearchProject",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScientificArticle");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ResearchProject");
        }
    }
}
