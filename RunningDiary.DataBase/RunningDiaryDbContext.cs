using Microsoft.EntityFrameworkCore;

namespace RunningDiary.Database
{
    public class RunningDiaryDbContext : DbContext
    {

        public DbSet<Runner> Runners { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public RunningDiaryDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
