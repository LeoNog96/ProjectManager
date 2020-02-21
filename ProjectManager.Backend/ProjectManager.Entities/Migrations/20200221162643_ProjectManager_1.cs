using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjectManager.Entities.Migrations
{
    public partial class ProjectManager_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 250, nullable: false),
                    initial_date = table.Column<DateTime>(nullable: false),
                    final_date = table.Column<DateTime>(nullable: false),
                    percent_complete = table.Column<double>(nullable: false),
                    late = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "activity",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 250, nullable: false),
                    initial_date = table.Column<DateTime>(nullable: false),
                    final_date = table.Column<DateTime>(nullable: false),
                    running = table.Column<bool>(nullable: true, defaultValueSql: "false"),
                    finished = table.Column<bool>(nullable: true, defaultValueSql: "false"),
                    project_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity", x => x.id);
                    table.ForeignKey(
                        name: "project_activity_id",
                        column: x => x.project_id,
                        principalTable: "project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_project_id",
                table: "activity",
                column: "project_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity");

            migrationBuilder.DropTable(
                name: "project");
        }
    }
}
