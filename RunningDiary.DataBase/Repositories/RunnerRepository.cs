using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RunningDiary.Database
{
    public class RunnerRepository : BaseRepository<Runner>, IRunnerRepository
    {
        protected override DbSet<Runner> DbSet => mDbContext.Runners;

        public RunnerRepository(RunningDiaryDbContext dbContext) : base(dbContext)
        {
                
        }

        public IEnumerable<Runner> GetAllRunners()
        {
            return DbSet/*.Include(x => x.Prescriptions).ThenInclude(x => x.Medicines)*/.Select(x => x);
        }

    }
}
