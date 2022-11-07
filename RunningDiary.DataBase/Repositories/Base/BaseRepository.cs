using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace RunningDiary.Database
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity //trzeba dodać, żeby utworzyć properties "protected abstract"
    {
        protected RunningDiaryDbContext mDbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(RunningDiaryDbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
                list.Add(entity);

            return list;
        }


        public void AddNew(Entity entity)
        {
            DbSet.Add(entity);

            SaveChanges();
        }

        public void Edit(Entity entity)
        {
            DbSet.Update(entity);

            SaveChanges();
        }

        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);

                return SaveChanges();
            }

            return false;
        }

        public bool SaveChanges()
        {
            return mDbContext.SaveChanges() > 0;
        }
    }
}
