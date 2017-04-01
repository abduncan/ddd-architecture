using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.DomainModels.CustomerAggregate;
using Company.Domain.DomainModels.OrderAggregate;
using Company.Domain.DomainModels.ProductAggregate;
using Company.Domain.Migrations;

namespace Company.Domain.Infrastructure.Repository
{
    public class AwesomeStoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public AwesomeStoreContext()
            : base("AwesomeStore")
        {
            Database.SetInitializer<AwesomeStoreContext>(new CreateDatabaseIfNotExists<AwesomeStoreContext>());
        }
    }
}
