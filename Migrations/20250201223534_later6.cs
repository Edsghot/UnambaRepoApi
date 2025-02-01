using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnambaRepoApi.Migrations
{
    public partial class later6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Concytec",
                table: "Teacher",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Dni",
                table: "Teacher",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Orcid",
                table: "Teacher",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "School",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Scopus",
                table: "Teacher",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concytec",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Orcid",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "School",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Scopus",
                table: "Teacher");
        }
    }
}
