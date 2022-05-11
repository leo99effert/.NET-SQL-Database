using RentPlanetNow.PlanetRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow
{
    public class Account
    {
        public AccountType AccountType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> CurrentPlanets { get; set; } = new();
        public List<string> PlanetHistory { get; set; } = new();
        public Account(AccountType accountType, string username, string password)
        {
            AccountType = accountType;
            Username = username;
            Password = password;
        }
    }
}
