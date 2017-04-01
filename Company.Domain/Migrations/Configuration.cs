using Company.Domain.DomainModels.OrderAggregate;
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
            var order1 = new Order(1);
            var order2 = new Order(2);

            context.Orders.AddOrUpdate(
                o => o.Id,
                order1,
                order2);

            context.OrderLines.AddOrUpdate(
                ol => ol.Id,
                new OrderLine(1, 1, order1),
                new OrderLine(1, 10, order1));
        }
    }
}
