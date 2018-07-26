namespace WebApiCoreDemo.Repositories
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}