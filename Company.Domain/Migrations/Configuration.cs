using Company.Domain.DomainModels.CustomerAggregate;
using Company.Domain.DomainModels.OrderAggregate;
using Company.Domain.DomainModels.ProductAggregate;
using Company.Domain.Infrastructure.Repository;

namespace Company.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<AwesomeStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AwesomeStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var product = SeedProduct(context);

            var customer = SeedCustomers(context);
            SeedOrders(context, customer, product);
        }

        private Product SeedProduct(AwesomeStoreContext context)
        {
            var product = new Product("Arduino", 10);
            context.Products.AddOrUpdate(
                p => p.Id,
                product);
            return product;
        }

        private static Customer SeedCustomers(AwesomeStoreContext context)
        {
            var customer = new Customer("Andrew", "Duncan");
            context.Customers.AddOrUpdate(
                            c => c.Id,
                            customer);
            return customer;
        }

        private static void SeedOrders(AwesomeStoreContext context, Customer customer, Product product)
        {
            var order1 = new Order(customer);
            var order2 = new Order(customer);

            context.Orders.AddOrUpdate(
                o => o.Id,
                order1,
                order2);

            context.OrderLines.AddOrUpdate(
                ol => ol.Id,
                new OrderLine(1, product, order1),
                new OrderLine(1, product, order1));
        }
    }
}
