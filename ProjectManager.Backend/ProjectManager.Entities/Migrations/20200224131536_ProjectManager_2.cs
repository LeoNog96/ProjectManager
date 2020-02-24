using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Entities.Migrations
{
    public partial class ProjectManager_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "removed",
                table: "project",
                nullable: true,
                defaultValueSql: "false");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "removed",
                table: "project");
        }
    }
}
