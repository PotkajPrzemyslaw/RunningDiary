using System.Collections.Generic;

namespace RunningDiary.Database
{
    public interface IRunnerRepository : IRepository<Runner>
    {
        IEnumerable<Runner> GetAllRunners();
    }
}
