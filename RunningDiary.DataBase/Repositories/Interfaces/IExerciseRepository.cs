using System.Collections.Generic;

namespace RunningDiary.Database
{
    public interface IExerciseRepository : IRepository<Exercise>
    {
        List<Exercise> GetAllExercises();
    }
}
