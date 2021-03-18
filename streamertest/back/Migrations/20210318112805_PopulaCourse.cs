using Microsoft.EntityFrameworkCore.Migrations;

namespace SS_API.Migrations
{
    public partial class PopulaCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Courses (name) VALUES('Portugues')");
            migrationBuilder.Sql("INSERT INTO Courses (name) VALUES('Física')");
            migrationBuilder.Sql("INSERT INTO Courses (name) VALUES('Matemática')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Courses");
        }
    }
}
