using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RunningDiary.Database
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        protected override DbSet<Workout> DbSet => mDbContext.Workouts;

        public WorkoutRepository(RunningDiaryDbContext dbContext) : base(dbContext)
        {
                
        }

        public IEnumerable<Workout> GetAllWorkouts()
        {
            return DbSet/*.Include(x => x.Medicines)*/.Select(x => x);
        }
    }
}
