using RentPlanetNow.AccountRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow.PlanetRelated
{
    public static class PlanetsTracker
    {
        public static Planet CurrentPlanet { get; set; }
        public static List<Planet> AllPlanets { get; set; } = new()
        {
            new Planet("Mercury"), 
            new Planet("Venus"), 
            new Planet("Earth"), 
            new Planet("Mars"), 
            new Planet("Jupiter"), 
            new Planet("Saturn"), 
            new Planet("Uranus"), 
            new Planet("Neptune") 
        };
        public static void Action(Planet planet)
        {
            CurrentPlanet = planet;
            if (AccountsTracker.CurrentUser.AccountType == AccountType.Customer) // Customer handling planets
            {
                if (planet.IsAvailable == true) // Renting a planet
                {
                    AccountsTracker.CurrentUser.CurrentPlanets.Add(planet.Name);
                    planet.IsAvailable = false;
                    planet.CurrentCustomer = AccountsTracker.CurrentUser.Username;
                    Tools.MessageAndPressEnterToReturn("You now have access to " + planet.Name + ". Enjoy!");
                }
                else // Returning a planet
                {
                    AccountsTracker.CurrentUser.CurrentPlanets.Remove(planet.Name);
                    AccountsTracker.CurrentUser.PlanetHistory.Add(planet.Name);
                    planet.IsAvailable = true;
                    planet.CurrentCustomer = null;
                    planet.PreviousCustomers.Add(AccountsTracker.CurrentUser.Username);
                    Tools.MessageAndPressEnterToReturn(planet.Name + " has been returned.");
                }
                MenuTracker.CurrentMenuName = MenuNames.RentPlanetViewReturnPlanetsHistoryLogOut;
            }
            else // Employee handling planets
            {
                string currentCustomer;
                if (planet.IsAvailable) currentCustomer = "AVAILABLE";
                else currentCustomer = planet.CurrentCustomer;
                string message = $"Current customer: " + currentCustomer + "\nHistory:\n";
                foreach (string account in planet.PreviousCustomers)
                {
                    message += account + "\n";
                }
                Tools.MessageAndPressEnterToReturn(message);
                if (planet.IsAvailable) MenuTracker.CurrentMenuName = MenuNames.KeepPlanetRemovePlanet;
                else MenuTracker.CurrentMenuName = MenuNames.ViewRemovePlanetsAddPlanetRestoreSystemLogOut;
            }
            Save.SaveData();
        }
        public static void AddPlanet()
        {
            Tools.ClearConsoleAndMakeTextWhite();
            string newPlanetName = Tools.GetInput("Enter name of planet:");
            foreach (Planet planet in AllPlanets)
            {
                if (planet.Name == newPlanetName)
                {
                    Console.WriteLine("That planet is already in the system");
                    return;
                }
            }
            AllPlanets.Add(new Planet(newPlanetName));
            MenuTracker.MenuList[4].ButtonTexts.Insert(MenuTracker.MenuList[4].ButtonTexts.Count - 1, newPlanetName);
            Tools.MessageAndPressEnterToReturn(newPlanetName + " is now in the system.");
            Save.SaveData();
        }
        public static void LookForPlanetsToRent()
        {
            List<string> availablePlanets = new();
            foreach (Planet planet in AllPlanets)
            {
                if (planet.IsAvailable)
                {
                    availablePlanets.Add(planet.Name);
                }
            }
            if (availablePlanets.Count == 0)
            {
                Tools.MessageAndPressEnterToReturn("There are no available planets.");
            }
            availablePlanets.Add("Back To Customer Menu");
            for (int i = 0; i < MenuTracker.MenuList.Count; i++)
            {
                if (MenuTracker.MenuList[i].Name == MenuNames.AvailablePlanetsBackToCustomerMenu)
                {
                    MenuTracker.MenuList.RemoveAt(i);
                }
            }
            MenuTracker.MenuList.Add(new Menu(MenuNames.AvailablePlanetsBackToCustomerMenu, availablePlanets));
            MenuTracker.CurrentMenuName = MenuNames.AvailablePlanetsBackToCustomerMenu;
        }
        public static void ShowCustomersCurrentPlanets()
        {
            if (AccountsTracker.CurrentUser.CurrentPlanets.Count == 0)
            {
                Tools.MessageAndPressEnterToReturn("You dont have any planets.");
            }
            else
            {
                List<string> currentPlanets = new();
                foreach (Planet planet in AllPlanets)
                {
                    if (planet.IsAvailable == false)
                    {
                        currentPlanets.Add(planet.Name);
                    }
                }
                currentPlanets.Add("Back To Customer Menu");
                for (int i = 0; i < MenuTracker.MenuList.Count; i++)
                {
                    if (MenuTracker.MenuList[i].Name == MenuNames.CurrentPlanetsBackToCustomerMenu)
                    {
                        MenuTracker.MenuList.RemoveAt(i);
                    }
                }
                MenuTracker.MenuList.Add(new Menu(MenuNames.CurrentPlanetsBackToCustomerMenu, currentPlanets));
                MenuTracker.CurrentMenuName = MenuNames.CurrentPlanetsBackToCustomerMenu;
            }           
        }
        public static void ShowCustomersPlanetHistory()
        {
            Console.Clear();
            if (AccountsTracker.CurrentUser.PlanetHistory.Count == 0)
            {
                Tools.MessageAndPressEnterToReturn("You dont have a planet history yet, check out the \"Rent a Planet\"-Menu");
                return;
            }
            string planetHistory = "";
            foreach (string planet in AccountsTracker.CurrentUser.PlanetHistory)
            {
                planetHistory += planet + "\n";
            }
            Tools.MessageAndPressEnterToReturn(planetHistory);
        }
    }
}
