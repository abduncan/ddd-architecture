using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.DomainModels.Shared;

namespace Company.Domain.DomainModels.CustomerAggregate
{
    class CustomerAddress
    {
        public int Id { get; set; }

        public string City { get; set; }

        public State State { get; set; }

        public string ZipCode { get; set; }
    }
}
