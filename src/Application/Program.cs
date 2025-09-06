using Domain.Modeli;
using Domain.Repozitorijumi.TestMapeSaPodacimaRepozitorijum;
using Presentation.AutentifikacijaUI;
using Presentation.AutomatskiUnosUI;
using Presentation.BitkaUI;
using Presentation.KorisnickiUnosUI;
using Presentation.PocetniMeniUI;
using Presentation.StatistikaUI;

namespace ers_e03_tim_02
{
    public class Program
    {

        //    PREDMET: Elementi Razvoja Softvera
        //    TIM 02: Dimitrije Stanković PR 81/2022
        //            Vojin Jovanović PR 82/2022
        //    ŠKOLSKA 2024/25. godina

        public static void Main()
        {
            while (true)
            {   
                
                Mapa _mapa = new Mapa();

                #region USER INTERFACE
                IAutentifikacijaUI autentifikacija = new AutentifikacijaUI();
                IPocetniMeniUI pocetniMeni = new PocetniMeniUI();
                IKorisnickiUnosUI korisnickiUnos = new KorisnickiUnosUI();
                IAutomatskiUnosUI automatskiUnos = new AutomatskiUnosUI();
                IBitkaUI bitka = new BitkaUI();
                IStatistikaUI statistika = new StatistikaUI();
                #endregion

                autentifikacija.PokreniAutentifikaciju();

                int komanda = pocetniMeni.PrikaziPocetniMeni();

                if (komanda == 1) //ako je izabran korisnicki unos
                    _mapa = korisnickiUnos.PokreniKorisnickiUnos();

                else if (komanda == 2) //ako je izabran automatski unos
                    _mapa = automatskiUnos.PokreniAutomatskiUnos();

                else if (komanda == 3) //ako je izabrano odjavljivanje
                {
                    Console.WriteLine();
                    Console.WriteLine("Odjavljivanje...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }

                else if (komanda == 4) //ako je izabran izlaz iz aplikacije
                {
                    Console.WriteLine();
                    Console.WriteLine("Izlaz...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                }

                //ispis podataka o mapi
                Console.WriteLine(_mapa);
                Console.WriteLine(_mapa.PlaviTim);
                Console.WriteLine(_mapa.CrveniTim);
                Console.WriteLine("\n");
                Console.WriteLine("ZAPOCNI BITKU...");
                Console.ReadLine();

                //ako postoji greska prilikom zapocinjanja bitke
                if (!bitka.ZapocniBitku(_mapa))
                {
                    Console.WriteLine("GREŠKA PRILIKOM POKRETANJA BITKE!");
                    Console.WriteLine("PONOVO POKRECEM PROGRAM...");
                    if (komanda == 1) korisnickiUnos.ClearAll();
                    else if (komanda == 2) automatskiUnos.ClearAll();
                    Thread.Sleep(2000);
                    Console.Clear();
                    break;
                }

                Console.WriteLine("PRIKAZI STATISTIKU...");//nakon zavrsetka bitke
                Console.ReadLine();
                Console.Clear();

                statistika.PrikaziStatistiku(_mapa);

                Console.ReadLine();
                Console.Clear();

                if (komanda == 1) korisnickiUnos.ClearAll();
                else if (komanda == 2) automatskiUnos.ClearAll();

            }
        }
    }
}