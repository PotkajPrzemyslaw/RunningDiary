namespace RunningDiary.Database
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        void AddNew(Entity entity);
        void Edit(Entity entity);

        bool Delete(Entity entity);
    }
}
