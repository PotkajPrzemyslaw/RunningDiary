using Microsoft.EntityFrameworkCore.Migrations;

namespace RunningDiary.Database.Migrations
{
    public partial class typeOfWorkoutAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfWorkout",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfWorkout",
                table: "Workouts");
        }
    }
}
