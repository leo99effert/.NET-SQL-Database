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
    public static class AccountsTracker
    {
        public static Account CurrentUser { get; set; }
        public static List<Account> AllAccounts { get; set; } = new();       
        public static void CreateAccount(AccountType accountType)
        {
            Tools.ClearConsoleAndMakeTextWhite();
            string username = Tools.GetInput("Create a username:");
            foreach (Account account in AllAccounts)
            {
                if (username == account.Username)
                {
                    Tools.MessageAndPressEnterToReturn("That username is already in use.");
                    MenuTracker.CurrentMenuName = MenuNames.LogInCreateAccountExit;
                    return;
                }
            }
            string password = Tools.GetInput("Create a password:");
            AllAccounts.Add(new Account(accountType, username, password));
            MenuTracker.CurrentMenuName = MenuNames.LogInCreateAccountExit;
            Tools.MessageAndPressEnterToReturn("Your account is saved.");
            Save.SaveData();
        }
        public static void LogIn()
        {
            Tools.ClearConsoleAndMakeTextWhite();
            string usernameRecieved = Tools.GetInput("Enter your username:");
            foreach (Account account in AllAccounts)
            {
                if (usernameRecieved == account.Username)
                {
                    string passwordRecieved = Tools.GetInput("Enter your password");
                    if (passwordRecieved == account.Password)
                    {
                        CurrentUser = account;
                        if (account.AccountType == AccountType.Customer)
                        {
                            MenuTracker.CurrentMenuName = MenuNames.RentPlanetViewReturnPlanetsHistoryLogOut;
                        }
                        else
                        {
                            MenuTracker.CurrentMenuName = MenuNames.ViewRemovePlanetsAddPlanetRestoreSystemLogOut;
                        }
                        Tools.MessageAndPressEnterToReturn("Logging in...");
                        return;
                    }
                    else
                    {
                        MenuTracker.CurrentMenuName = MenuNames.LogInCreateAccountExit;
                        Tools.MessageAndPressEnterToReturn("The password is incorrect.");
                        return;
                    }
                }
            }
            MenuTracker.CurrentMenuName = MenuNames.LogInCreateAccountExit;
            Tools.MessageAndPressEnterToReturn("User not found.");
        }
        
    }
}
