using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.DomainModels.CustomerAggregate
{
    public class Customer
    {
        // This property can / should have a private
        // setter because it shouldn't be modified
        // other than by EntityFramekwork, which can
        // handle mapping to private properites.
        public int Id { get; private set; } = 0;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        private Customer() { }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
