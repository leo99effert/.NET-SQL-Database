using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow.PlanetRelated
{
    public class Planet
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string CurrentCustomer { get; set; }
        public List<string> PreviousCustomers { get; set; } = new();
        public Planet(string name)
        {
            Name = name;
        }
    }
}
