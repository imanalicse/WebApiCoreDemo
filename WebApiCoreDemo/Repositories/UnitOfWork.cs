using WebApiCoreDemo.Data;

namespace WebApiCoreDemo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var repo = new Repository<TEntity>(_context);
            return repo;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
