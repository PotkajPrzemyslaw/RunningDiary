using System.Collections.Generic;

namespace RunningDiary.Database
{
    public interface IWorkoutRepository : IRepository<Workout>
    {
        IEnumerable<Workout> GetAllWorkouts();
    }
}
