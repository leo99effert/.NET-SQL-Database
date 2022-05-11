using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentPlanetNow
{
    public static class MenuPrinter
    {
        public const int lengthOfButtons = 100; // Size for the buttons
        public static void SetTextColor(int optionNumber)
        {
            if (ButtonSelector.CurrentButton == optionNumber) Console.ForegroundColor = ConsoleColor.Blue;
            else Console.ForegroundColor = ConsoleColor.White;
        }
        public static void CalculateSpacesBetweenButtonTextAndEdges(string option, out int spaceBeforeOption, out int spaceAfterOption)
        {
            spaceBeforeOption = (lengthOfButtons - option.Length) / 2;
            spaceAfterOption = spaceBeforeOption;
            if ((lengthOfButtons - option.Length) % 2 != 0)
            {
                spaceAfterOption++;
            }
        }
        public static void CreateTopOrBottomEdgeOfButton(Edge edgeType)
        {
            for (int i = 0; i < lengthOfButtons; i++)
            {
                     if (i == 0 && edgeType == Edge.Top) Console.Write("┌");
                else if (i == 0 && edgeType == Edge.Bottom) Console.Write("└");
                else if (i == lengthOfButtons - 1 && edgeType == Edge.Top) Console.Write("┐");
                else if (i == lengthOfButtons - 1 && edgeType == Edge.Bottom) Console.Write("┘");
                else Console.Write("─");
            }
            Console.WriteLine();
        }
        public static void CreateSpacesToCentraliseButtonText(Edge edgeType, int spaces)
        {
            for (int i = 0; i < spaces; i++)
            {
                if (i == 0 && edgeType == Edge.Left || i == spaces - 1 && edgeType == Edge.Right) Console.Write("│");
                else Console.Write(" ");
            }
        }
        public static void DisplayMenu(List<string> options)
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                SetTextColor(i);

                // Create top of button
                CreateTopOrBottomEdgeOfButton(Edge.Top);

                // Create middle section including the text
                CalculateSpacesBetweenButtonTextAndEdges(options[i], out int spacesBeforeButtonText, out int spacesAfterButtonText);
                CreateSpacesToCentraliseButtonText(Edge.Left, spacesBeforeButtonText);
                Console.Write(options[i]);
                CreateSpacesToCentraliseButtonText(Edge.Right, spacesAfterButtonText);
                Console.WriteLine();

                // Create bottom
                CreateTopOrBottomEdgeOfButton(Edge.Bottom);
            }
        }
    }
}
