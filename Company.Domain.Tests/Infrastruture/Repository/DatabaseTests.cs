using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Company.Domain.DomainModels.OrderAggregate;
using Company.Domain.Infrastructure.Repository;
using Company.Domain.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Company.Domain.Tests.Infrastruture.Repository
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void DatabaseExists()
        {
            var context = new AwesomeStoreContext();
            var order = context.Orders.First();
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void AddLineToOrder()
        {
            var context = new AwesomeStoreContext();
            var customer = context.Customers.FirstOrDefault();
            var order = new Order(customer);
            var line = order.AddLine(10, 1);
            context.Orders.Add(order);
            context.OrderLines.Add(line);
            context.SaveChanges();
        }
    }
}
