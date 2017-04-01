using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.Infrastructure.Repository;

namespace Company.Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        DbContextTransaction BeginTransaction();
        int SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AwesomeStoreContext _context;

        public UnitOfWork(AwesomeStoreContext context)
        {
            _context = context;
        }

        public DbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
