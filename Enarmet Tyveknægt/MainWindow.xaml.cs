using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Enarmet_Tyveknægt
{
    public partial class MainWindow : Window
    {
        #region Variabler til diverse
        // Variabel til autospil
        public bool IsAutoOn = false;

        // Variabler til hold metode og Play metode
        public bool gevinst = true;
        public bool isLessThanTwo = true;
        public bool ligeHold = false;
        public bool isIngame = false;

        public int bet = 5; // Default bet mængde
        public int spin = 40; // Antal gange der skal cycles igennem billeder før den stopper
        public double balance; // Ens balance
        #endregion

        #region Object setup
        LessThanTwo LessThanTwo = new LessThanTwo();
        WinChecker win;
        chance check;
        Random rng = new Random();
        public MainWindow() // Constructor til WinChecker og chance. Det laves således for at give disse klasser adgang til MainWindow resources samt MainWindow knapper, billeder osv.
        {
            win = new WinChecker(this);
            check = new chance(this);
        }
        #endregion

        #region Play
        // Async Task for Play(); som er animationerne og selve gameplayet
        private async Task Play() // Den er async Task for at det er muligt at lave et delay til animationerne. Hvis denne metode ikke har async task så ville der ikke være behov for at skrive "await" i metoden over.
        {
            int delay = 30;

            isIngame = true; // Sætter boolen IsIngame til at være true som betyder at der ikke kan holdes.

            balance -= bet;
            balancee.Text = "Balance: " + balance + " DKK";

            #region Animationer
            // Alle animationerne fungere på samme måde de variere bare efter hvad der holdes. De if sætninger med 2 hold knapper skal kører først for at der ikke sker fejl.
            if (((SolidColorBrush)hold1.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red) && ((SolidColorBrush)hold2.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red)) // Hvis både række 1 og 2 er holdt så sker dette
            {
                // Inden i dem alle sammen er dette.
                Image[] images = { three, six, nine }; // Den laver en array med de knapper som skal ændre deres billede.
                for (int i = 0; i < spin; i++) // Et for loop som står for selve animationen samt tilfældigheden
                {
                    foreach (Image e in images)
                    {
                        check.Chancer(e); // Kalder chancer funktionen og tager alle knapperne som input
                    }
                    await Task.Delay(delay); //Laver et delay
                }
            }
            else if (((SolidColorBrush)hold2.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red) && ((SolidColorBrush)hold3.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red)) // Hvis både række 2 og 3 er holdt så sker dette
            {
                Image[] imagees = { one, four, seven };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in imagees)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
            }
            else if (((SolidColorBrush)hold1.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red) && ((SolidColorBrush)hold3.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red)) // Hvis både række 1 og 3 er holdt så sker dette
            {
                Image[] images = { two, five, eight };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in images)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
            }
            else if (((SolidColorBrush)hold1.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red)) // Hvis række 1 er holdt
            {
                Image[] images = { two, three, five, six, eight, nine };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in images)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
                Image[] imagees = { three, six, nine };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in imagees)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
            }
            else if (((SolidColorBrush)hold2.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red)) // Hvis række 2 er holdt
            {
                Image[] images = { one, three, four, six, seven, nine };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in images)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
                Image[] imagees = { three, six, nine };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in imagees)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
            }
            else if (((SolidColorBrush)hold3.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red)) // Hvis række 3 er holdt
            {
                Image[] images = { one, two, four, five, seven, eight };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in images)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
                Image[] imagees = { two, five, eight };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in imagees)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
            }
            else // Hvis ingen af hold knapperne er på så laver den denne animation hvor den starter med alle knapperne og tager så en række fra ad gangen for at give en god effekt.
            {
                Image[] images = { one, two, three, four, five, six, seven, eight, nine };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in images)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
                Image[] imagees = { two, three, five, six, eight, nine };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in imagees)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
                Image[] imageees = { three, six, nine };
                for (int i = 0; i < spin; i++)
                {
                    foreach (Image e in imageees)
                    {
                        check.Chancer(e);
                    }
                    await Task.Delay(delay);
                }
            }
            #endregion

            #region WinCheck
            if (win.WinCheck() > 0) // Tjekker om der er gevinst (WinCheck() er en double som får 0 som værdi hvis der ikke er værdi).
            {
                balance += win.WinCheck() * bet; // Tilføjer gevinst til balance da WinCheck() returner gevinst X.
                balancee.Text = "Balance: " + balance + " DKK";
            }
            else { gevinst = false; }
            #endregion

            #region Reset af knapper
            // Her resettes alle hold knapperne hvis de har været i brug og hvis de har været i brug så sikre ligeHold variablen at spilleren ikke kan holde igen lige efter.
            if (((SolidColorBrush)hold1.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red) || ((SolidColorBrush)hold2.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red) || ((SolidColorBrush)hold3.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red))
            {
                ligeHold = true;
                BrushConverter bc = new BrushConverter(); // Der laves ny BrushConverter() da jeg arbejder med Hex koder som ikke er programmeret default som white, black osv.
                hold1.Background = (Brush)bc.ConvertFrom(LessThanTwo.normal);
                hold2.Background = (Brush)bc.ConvertFrom(LessThanTwo.normal);
                hold3.Background = (Brush)bc.ConvertFrom(LessThanTwo.normal);
            }
            else { ligeHold = false; } // Hvis der ikke er holdt så kan spilleren holde

            if (IsAutoOn)
            {
                Spil.IsEnabled = false;
                minus.IsEnabled = false;
                plus.IsEnabled = false;
            }
            else
            {
                Spil.IsEnabled = true;
                minus.IsEnabled = true;
                plus.IsEnabled = true;
            }
            #endregion

            isIngame = false; // Spilleren har spillet en runde og derfor kan han igen bruge hold knapper (så længe de andre forhold stadig holder)

            if (IsAutoOn) { await Task.Delay(2000); } // Dette er her så spilleren kan nå at holde imens han har auto på
        }
        #endregion

        #region Hold knap
        //Dette Click event kører når der klikkes på en hold knap.
        private void hold_Click(object sender, RoutedEventArgs e)
        {
            // Sætter hold1-3 til hold1-3 i klassen LessThanTwo.cs så billederne kan bruges der.
            LessThanTwo.hold1 = hold1;
            LessThanTwo.hold2 = hold2;
            LessThanTwo.hold3 = hold3;

            Button button = sender as Button; // Sætter button til at være den knap der er blevet klikket på.
            BrushConverter bc = new BrushConverter();

            if (gevinst || ligeHold || isIngame) { return; } // Sikre at alle forholdene for at der kan holdes er i orden.
            else if (((SolidColorBrush)button.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.red)) //Gør baggrundsfarven af den knap der blev trykket på normal hvis den er rød
            {
                button.Background = (Brush)bc.ConvertFrom(LessThanTwo.normal);
            }
            else if (((SolidColorBrush)button.Background).Color == (Color)ColorConverter.ConvertFromString(LessThanTwo.normal) && LessThanTwo.IsLessThanTwo()) //Gør baggrundsfarven af den knap der blev trykket på rød hvis den er normal og hvis der ikke allerede er markeret to hold knapper
            {
                button.Background = (Brush)bc.ConvertFrom(LessThanTwo.red);
            }
        }
        #endregion

        #region Auto knap
        // Denne click event kører når der klikkes på autoknappen
        private void AutoSpil_Click(object sender, RoutedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            if (IsAutoOn) // Hvis autoknappen allerede er på så slår den fra og ændre farve til normal
            {
                IsAutoOn = false;
                auto.Background = (Brush)bc.ConvertFrom(LessThanTwo.normal);
            }
            else if (!IsAutoOn && !isIngame) // Hvis autoknappen ikke er på så slår den til og sætter dens farve til rød.
            {
                IsAutoOn = true;
                auto.Background = (Brush)bc.ConvertFrom(LessThanTwo.red);
            }
        }
        #endregion

        #region Start knap
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            while (IsAutoOn && balance >= bet) //Hvis autoknappen er til og hvis der er nok penge i balance til at satse int bet så kører dette indtil denne betingelse ikke passer.
            {
                minus.IsEnabled = false; //Slår spil, minus og plus knapperne fra og venter på at Play() metoden er fuldført
                plus.IsEnabled = false;
                Spil.IsEnabled = false;
                await Play(); // Det er vigtigt der ventes på Play() fordi ellers looper dette while loop imens play kører. Der bliver altså kørt rigtig mange forskellige Play() simulationer
            }
            if (!IsAutoOn && balance >= bet) //Hvis autoknappen ikke er på og der er nok penge i banken så kører dette.
            {
                plus.IsEnabled = false; //Slår spil, plus og minus knapperne fra og kører Play(); en gang
                minus.IsEnabled = false;
                Spil.IsEnabled = false;
                Play(); //Her behøver vi ikke await fordi Play() vil altid kun køre en gang samt der er intet kode bagefter Play() i dette clickevent
            }
        }
        #endregion

        #region Knapper til mønter
        // De fire knapper som styrer indsætning af mønter.
        private void one_Click(object sender, RoutedEventArgs e)
        {
            balance++;
            balancee.Text = "Balance: " + balance+" DKK";
        }
        private void five_Click(object sender, RoutedEventArgs e)
        {
            balance += 5; // "balance +=" er det samme som "balance = balance +"
            balancee.Text = "Balance: " + balance + " DKK";
        }
        private void ten_Click(object sender, RoutedEventArgs e)
        {
            balance += 10;
            balancee.Text = "Balance: " + balance + " DKK";
        }
        private void twenty_Click(object sender, RoutedEventArgs e)
        {
            balance += 20;
            balancee.Text = "Balance: " + balance + " DKK";
        }
        #endregion

        #region To ekstra sider
        // Åbner info siden når der klikkes på info knappen
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            Info infowindow = new Info(); // Laver et object ud fra Info

            infowindow.Show();
        }
        // Åbner chancer siden når der klikke på chance knappen
        private void Chancer_Click(object sender, RoutedEventArgs e)
        {
            chancer chancerWindow = new chancer(); // Laver et object ud fra chancer

            chancerWindow.Show();
        }
        #endregion

        #region Plus minus knapper
        // De her to knapper ændre bet i forhold til hvad der klikke på
        private void plus_Click(object sender, RoutedEventArgs e)
        {
            bett.Text = "Current bet: " + bet;
            bet++;
            bett.Text = "Current bet: " + bet;
        }
        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (bet > 1) // her sikres der at der ikke bliver bettet under 1 da det vil give problemer i programmet hvis der bettes med 0 eller minus tal.
            {
                bett.Text = "Current bet: " + bet;
                bet--;
                bett.Text = "Current bet: " + bet;
            }
        }
        #endregion

    }
}
