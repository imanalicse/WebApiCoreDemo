using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
