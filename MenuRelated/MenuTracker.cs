using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow
{
    public static class MenuTracker
    {
        public static MenuNames CurrentMenuName { get; set; } = MenuNames.LogInCreateAccountExit;
        public static int CurrentMenuNumber { get; set; }
        public static List<Menu> MenuList { get; set; } = new() 
        { 
            new Menu(MenuNames.LogInCreateAccountExit, new List<string> 
            { "Log In", "Create Account", "Save and Exit" }),
            new Menu(MenuNames.CustomerEmployee, new List<string> 
            { "Customer", "Employee" }),
            new Menu(MenuNames.RentPlanetViewReturnPlanetsHistoryLogOut, new List<string> 
            { "Rent a Planet", "View/Return Planets", "History", "Log Out"}),
            new Menu(MenuNames.ViewRemovePlanetsAddPlanetRestoreSystemLogOut, new List<string> 
            { "View/Remove Planets", "Add Planet", "Restore System", "Log Out" }),
            new Menu(MenuNames.PlanetInfoOrRemoval, new List<string>
            { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Back To Employee Menu" }),
            new Menu(MenuNames.KeepPlanetRemovePlanet, new List<string>
            { "Keep Planet", "Remove Planet" })
        };
    }
}
