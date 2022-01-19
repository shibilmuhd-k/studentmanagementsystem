using Microsoft.EntityFrameworkCore.Migrations;

namespace school.dashboard.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    std = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "id", "name", "std" },
                values: new object[] { "1", "test name 1", " test std 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
