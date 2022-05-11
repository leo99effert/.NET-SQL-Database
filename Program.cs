using RentPlanetNow.AccountRelated;
using System;
using System.Collections.Generic;

namespace RentPlanetNow
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////////////////////////////           Setup                    //////////////////////////////////////////////////////////////////////////
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;
            Save.ReadData();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            

            


            ///////////////////////////////         Starting Info                //////////////////////////////////////////////////////////////////////////
            Console.WriteLine("*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.\n" +
                              "*.                                                                                    *.\n" +
                              "*.  You are connected to RentPlanetNow...                                             *.\n" +
                              "*.                                                                                    *.\n" +
                              "*.  You can navigate through our system using the up and down arrows keys and enter.  *.\n" +
                              "*.  Press Enter to continue...                                                        *.\n" +
                              "*.                                                                                    *.\n" +
                              "*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.*.\n");
            while (true) if (Console.ReadKey().Key == ConsoleKey.Enter) break;
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            




            ////////////////////////////////////         Primary Area          ////////////////////////////////////////////////////////////////////////////

            while (true)
            {
                for (int i = 0; i < MenuTracker.MenuList.Count; i++)
                {
                    if (MenuTracker.MenuList[i].Name == MenuTracker.CurrentMenuName)
                    {
                        MenuTracker.CurrentMenuNumber = i;
                    }
                }
                MenuPrinter.DisplayMenu(MenuTracker.MenuList[MenuTracker.CurrentMenuNumber].ButtonTexts);
                ButtonSelector.GetInput(MenuTracker.MenuList[MenuTracker.CurrentMenuNumber].ButtonTexts);
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
