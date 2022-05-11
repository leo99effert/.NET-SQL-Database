using RentPlanetNow.AccountRelated;
using RentPlanetNow.PlanetRelated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow
{
    public static class Tools
    {
        public static void ClearConsoleAndMakeTextWhite()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void MessageAndPressEnterToReturn(string message = "")
        {
            ClearConsoleAndMakeTextWhite();
            Console.WriteLine(message + "\nPress Enter to continue...");
            while (true) if (Console.ReadKey().Key == ConsoleKey.Enter) return;
        }
        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        
        public static void ClearSystem()
        {
            ClearConsoleAndMakeTextWhite();
            AccountsTracker.AllAccounts.Clear();
            PlanetsTracker.AllPlanets.Clear();
            PlanetsTracker.AllPlanets = new()
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
            MenuTracker.MenuList[4].ButtonTexts.Clear();
            MenuTracker.MenuList[4].ButtonTexts = new()
            {
                "Mercury",
                "Venus",
                "Earth",
                "Mars",
                "Jupiter",
                "Saturn",
                "Uranus",
                "Neptune",
                "Back To Employee Menu"
            };
            for (int i = 0; i < 100; i++)
            {
                string fileName = $"account{i}.json";
                if (File.Exists(fileName)) File.Delete(fileName);
            }
            for (int i = 0; i < 100; i++)
            {
                string fileName = $"planet{i}.json";
                if (File.Exists(fileName)) File.Delete(fileName);
            }
            MenuTracker.CurrentMenuName = MenuNames.LogInCreateAccountExit;
            Save.SaveData();
            Tools.MessageAndPressEnterToReturn("All data is deleted.");
        }
    }
}
