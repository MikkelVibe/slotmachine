using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Enarmet_Tyveknægt
{
    class WinChecker
    {
        // Alle billede navne
        public string Common = "40%";
        public string Uncommon = "28%";
        public string Rare = "15%";
        public string VeryRare = "10%";
        public string Epic = "5%";
        public string Legendary = "2%";

        MainWindow main;
        public WinChecker(MainWindow main) // Denne constructor gør så jeg kan bruge billeder osv fra MainWindow
        {
            this.main = main; // gør så jeg kan referere MainWindow med "main".
        }
        public double WinCheck() // Wincheck starter med dem der har tre af det samme billede, derefter tager den dem der har to og til sidst tager den den der har en i et bestemt felt. Den sender derefter det et tal tilbage som matcher det bette skal ganges med.
        {
            if (main.four.Source == (ImageSource)main.Resources[Legendary] && main.five.Source == (ImageSource)main.Resources[Legendary] && main.six.Source == (ImageSource)main.Resources[Legendary]) // Jackpot giver 100x gevinst
            {
                return 100;
            }
            else if (main.four.Source == (ImageSource)main.Resources[Epic] && main.five.Source == (ImageSource)main.Resources[Epic] && main.six.Source == (ImageSource)main.Resources[Epic]) // Giver 20x gevinst
            {
                return 20;
            }
            else if (main.four.Source == (ImageSource)main.Resources[VeryRare] && main.five.Source == (ImageSource)main.Resources[VeryRare] && main.six.Source == (ImageSource)main.Resources[VeryRare]) // Giver 10x gevinst
            {
                return 10;
            }
            else if (main.four.Source == (ImageSource)main.Resources[Rare] && main.five.Source == (ImageSource)main.Resources[Rare] && main.six.Source == (ImageSource)main.Resources[Rare]) // Giver 4x gevinst
            {
                return 4;
            }
            else if (main.four.Source == (ImageSource)main.Resources[Uncommon] && main.five.Source == (ImageSource)main.Resources[Uncommon] && main.six.Source == (ImageSource)main.Resources[Uncommon]) // Giver 3x gevinst
            {
                return 3;
            }
            else if (main.four.Source == (ImageSource)main.Resources[Common] && main.five.Source == (ImageSource)main.Resources[Common] && main.six.Source == (ImageSource)main.Resources[Common]) // Giver 2x gevinst
            {
                return 2;
            }
            else if (main.four.Source == (ImageSource)main.Resources[Common] && main.five.Source == (ImageSource)main.Resources[Common]) // Gratis spin 
            {
                return 1;
            }
            else if (main.four.Source == (ImageSource)main.Resources[Common]) // Giver 0.4x gevinst (Scam much)
            {
                return 0.4;
            }
            else { return 0; } // Og hvis der ikke er gevinst så sker dette
        }
    }
}
