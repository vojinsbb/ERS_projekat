using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Servisi;
using Services.AutentifikacioniServisi;


namespace Presentation.AutentifikacijaUI
{
    public class AutentifikacijaUI : IAutentifikacijaUI
    {

        public AutentifikacijaUI() { }

        public void PokreniAutentifikaciju()
        {
            string korisnickoIme = "", lozinka = "";
            Korisnik? prijavljen;
            bool uspesno;
            GreskaUPrijavi? greska;

            IAutentifikacijaServis autentifikacijaServis = new AutentifikacioniServis();

            do
            {
                Console.WriteLine("\n============================ PRIJAVA ============================");
                Console.Write("\tKORISNICKO IME: ");
                korisnickoIme = Console.ReadLine() ?? "".Trim();

                Console.Write("\tLOZINKA: ");
                lozinka = Console.ReadLine() ?? "".Trim();
                Console.WriteLine();

                (uspesno, prijavljen, greska) = autentifikacijaServis.Prijava(korisnickoIme, lozinka);

                Console.WriteLine("Prijavljivanje...");
                Thread.Sleep(500);

                if (!uspesno)
                {
                    if (greska == GreskaUPrijavi.KORISNICKO_IME)
                        Console.WriteLine("\tNEISPRAVNO KORISNICKO IME. POKUSAJTE PONOVO!\n");
                    else if (greska == GreskaUPrijavi.LOZINKA)
                        Console.WriteLine("\tNEISPRAVNA LOZINKA. POKUSAJTE PONOVO!\n");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while (!uspesno);

            Console.WriteLine("\tUSPESNA PRIJAVA KORISNIKA \"" + korisnickoIme + "\"");
            Thread.Sleep(2000);
            Console.Clear();

        }
    }
}
