using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Enarmet_Tyveknægt
{
    class chance
    {
        private string Common = "40%";
        private string Uncommon = "28%";
        private string Rare = "15%";
        private string VeryRare = "10%";
        private string Epic = "5%";
        private string Legendary = "2%";
        Random rng = new Random();

        MainWindow main;
        public chance(MainWindow main) // Denne constructor gør så jeg kan bruge resources osv fra MainWindow
        {
            this.main = main;
        }
        private void Chancer(Image i) // Metoden for Chancer tager billeder ind som i og bruger dem til at ændre på det 3x3 grid med billeder.
        {
            int random = rng.Next(1, 101);
            if (random <= 24) //24% Chance
            {
                i.Source = (ImageSource)main.Resources[Common];
            }
            else if (random >= 25 && random <= 45) //21% Chance
            {
                i.Source = (ImageSource)main.Resources[Uncommon];
            }
            else if (random >= 46 && random <= 64) //19% Chance
            {
                i.Source = (ImageSource)main.Resources[Rare];
            }
            else if (random >= 65 && random <= 81) //17% Chance
            {
                i.Source = (ImageSource)main.Resources[VeryRare];
            }
            else if (random >= 82 && random <= 93) //12% Chance
            {
                i.Source = (ImageSource)main.Resources[Epic];
            }
            else if (random >= 94 && random <= 100) //7 % Chance
            {
                i.Source = (ImageSource)main.Resources[Legendary];
            }
        }
        public async Task Animationer(Image[] images)
        {
            int spin = 40; // Antal gange der skal cycles igennem billeder før den stopper
            int delay = 40;

            for (int i = 0; i < spin; i++) // Et for loop som står for selve animationen samt tilfældigheden
            {
                foreach (Image e in images)
                {
                    Chancer(e); // Kalder chancer funktionen og tager alle knapperne som input
                }
            await Task.Delay(delay); //Laver et delay
            }
        }

    }
}
