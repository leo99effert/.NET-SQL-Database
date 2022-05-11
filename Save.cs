using RentPlanetNow.PlanetRelated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RentPlanetNow.AccountRelated
{
    public static class Save
    {
        public static void SaveData()
        {
            SaveAccounts();
            SavePlanets();
        }  
        public static void SaveAccounts()
        {
            for (int i = 0; i < 100; i++)
            {
                string fileName = $"account{i}.json";
                if (File.Exists(fileName)) File.Delete(fileName);
            }
            for (int i = 0; i < AccountsTracker.AllAccounts.Count; i++)
            {
                string account = JsonSerializer.Serialize(AccountsTracker.AllAccounts[i]);
                string fileName = $"account{i}.json";
                File.WriteAllText(fileName, account);
            }
        }
        public static void SavePlanets()
        {
            for (int i = 0; i < 100; i++)
            {
                string fileName = $"planet{i}.json";
                if (File.Exists(fileName)) File.Delete(fileName);
            }
            for (int i = 0; i < PlanetsTracker.AllPlanets.Count; i++)
            {
                string planet = JsonSerializer.Serialize(PlanetsTracker.AllPlanets[i]);
                string fileName = $"planet{i}.json";
                File.WriteAllText(fileName, planet);
            }
        }
        public static void ReadData()
        {
            ReadAccounts();
            ReadPlanets();
        }
        public static void ReadAccounts()
        {
            AccountsTracker.AllAccounts.Clear();
            for (int i = 0; i < 100; i++)
            {
                string fileName = $"account{i}.json";
                if (File.Exists(fileName))
                {
                    string json = File.ReadAllText(fileName);
                    AccountsTracker.AllAccounts.Add(JsonSerializer.Deserialize<Account>(json));
                }
            }
        }
        public static void ReadPlanets()
        {
            PlanetsTracker.AllPlanets.Clear();
            for (int i = 0; i < 100; i++)
            {
                string fileName = $"planet{i}.json";               
                if (File.Exists(fileName))
                {
                    string json = File.ReadAllText(fileName);
                    PlanetsTracker.AllPlanets.Add(JsonSerializer.Deserialize<Planet>(json));
                }
            }
        }
    }
}
