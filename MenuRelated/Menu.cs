using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow
{
    public class Menu
    {
        public MenuNames Name { get; set; }
        public List<string> ButtonTexts { get; set; }
        public Menu(MenuNames name, List<string> buttonTexts)
        {
            Name = name;
            ButtonTexts = buttonTexts;
        }
    }
}
