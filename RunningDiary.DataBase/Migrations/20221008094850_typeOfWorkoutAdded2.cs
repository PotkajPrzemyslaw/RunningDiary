using Microsoft.EntityFrameworkCore.Migrations;

namespace RunningDiary.Database.Migrations
{
    public partial class typeOfWorkoutAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Workouts",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Workouts",
                newName: "Name");
        }
    }
}
