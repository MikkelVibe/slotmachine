using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Enarmet_Tyveknægt
{
    class LessThanTwo
    {
        // Hex koder til farver
        public string red = "#ffaf2d2d";
        public string normal = "#798190";

        // De tre knapper der er i brug. Disse skal defineret i MainWindow fordi MainWindow ikke har adgang til denne klasse
        public Button hold1;
        public Button hold2;
        public Button hold3;
        public bool IsLessThanTwo() // Tjekker ved brug af en if sætning om der er markeret to hold knapper. Hvis der er markeret to knapper så sender den false tilbage.
        {
            if (((SolidColorBrush)hold1.Background).Color == (Color)ColorConverter.ConvertFromString(red) && ((SolidColorBrush)hold2.Background).Color == (Color)ColorConverter.ConvertFromString(red))
            {
                return false;
            }
            else if (((SolidColorBrush)hold2.Background).Color == (Color)ColorConverter.ConvertFromString(red) && ((SolidColorBrush)hold3.Background).Color == (Color)ColorConverter.ConvertFromString(red))
            {
                return false;
            }
            else if (((SolidColorBrush)hold1.Background).Color == (Color)ColorConverter.ConvertFromString(red) && ((SolidColorBrush)hold3.Background).Color == (Color)ColorConverter.ConvertFromString(red))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
