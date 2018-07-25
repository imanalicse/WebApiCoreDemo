namespace WebApiCoreDemo.Repositories
{
    public interface IUnitOfWork
    {
        int SaveChanges();       
    }
}