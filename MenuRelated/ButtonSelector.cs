using RentPlanetNow.AccountRelated;
using RentPlanetNow.PlanetRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow
{
    public static class ButtonSelector
    {
        public static int CurrentButton { get; set; } = 0; // If Enter is pressed; this option will be excecuted

        public static void GetInput(List<string> currentMenu)
        {
            while (Console.KeyAvailable) Console.ReadKey(false); //  ← This line removes any qued up input,
                                                                 //  so you cant give input before the menu is updated
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.UpArrow && CurrentButton > 0)
            {
                CurrentButton--;
            }
            else if (input.Key == ConsoleKey.DownArrow && CurrentButton < currentMenu.Count - 1)
            {
                CurrentButton++;
            }
            else if (input.Key == ConsoleKey.Enter)
            {
                switch (currentMenu[CurrentButton])
                {
                    case "Save and Exit":
                        Save.SaveData();
                        Environment.Exit(0);
                        break;
                    case "Create Account":
                        MenuTracker.CurrentMenuName = MenuNames.CustomerEmployee;
                        break;
                    case "Customer":
                        AccountsTracker.CreateAccount(AccountType.Customer);
                        break;
                    case "Employee":
                        AccountsTracker.CreateAccount(AccountType.Admin);
                        break;
                    case "Log In":
                        AccountsTracker.LogIn();
                        break;
                    case "Log Out":
                        MenuTracker.CurrentMenuName = MenuNames.LogInCreateAccountExit;
                        break;
                    case "Rent a Planet":
                        PlanetsTracker.LookForPlanetsToRent();
                        break;
                    case "View/Return Planets":
                        PlanetsTracker.ShowCustomersCurrentPlanets();
                        break;
                    case "History":
                        PlanetsTracker.ShowCustomersPlanetHistory();
                        break;
                    case "Back To Customer Menu":
                        MenuTracker.CurrentMenuName = MenuNames.RentPlanetViewReturnPlanetsHistoryLogOut;
                        break;
                    case "Back To Employee Menu":
                        MenuTracker.CurrentMenuName = MenuNames.ViewRemovePlanetsAddPlanetRestoreSystemLogOut;
                        break;
                    case "View/Remove Planets":
                        MenuTracker.CurrentMenuName = MenuNames.PlanetInfoOrRemoval;
                        break;
                    case "Keep Planet":
                        MenuTracker.CurrentMenuName = MenuNames.ViewRemovePlanetsAddPlanetRestoreSystemLogOut;
                        break;
                    case "Remove Planet":
                        PlanetsTracker.AllPlanets.Remove(PlanetsTracker.CurrentPlanet);
                        MenuTracker.MenuList[4].ButtonTexts.Remove(PlanetsTracker.CurrentPlanet.Name.ToString());
                        MenuTracker.CurrentMenuName = MenuNames.ViewRemovePlanetsAddPlanetRestoreSystemLogOut;
                        break;
                    case "Add Planet":
                        PlanetsTracker.AddPlanet();
                        break;
                    case "Restore System":
                        Tools.ClearSystem();
                        break;
                    default: // planet options
                        string planet = currentMenu[CurrentButton].ToString();
                        for (int i = 0; i < PlanetsTracker.AllPlanets.Count; i++)
                        {
                            if (PlanetsTracker.AllPlanets[i].Name == planet) PlanetsTracker.Action(PlanetsTracker.AllPlanets[i]);
                        }                                          
                        break;
                }
                CurrentButton = 0; // Always set the defualt button to the top button
            }
        }
    }
}
