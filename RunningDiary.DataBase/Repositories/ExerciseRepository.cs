using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RunningDiary.Database
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        protected override DbSet<Exercise> DbSet => mDbContext.Exercises;

        public ExerciseRepository(RunningDiaryDbContext dbContext) : base(dbContext)
        {
                
        }

        public List<Exercise> GetAllExercises()
        {
            var result = DbSet.Select(x => x).ToList();
            return result;
        }

    }
}
