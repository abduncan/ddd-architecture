using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.DomainModels.Shared
{
    // State is the single entity in the State aggregate.
    // State is the aggregate root.
    class State
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        // A State requires a name and abbreviation.
        // We require the invariants of a the class
        // in the constructor to prevent the class
        // from being created in an invalid state.
        // Keeping the model in a valid state reduces
        // bugs by increasing validation.
        public State(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
