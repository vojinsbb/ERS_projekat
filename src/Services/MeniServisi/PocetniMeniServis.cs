using Domain.Servisi;

namespace Services.MeniServisi
{
    public class PocetniMeniServis : IMeniServis
    {
        public PocetniMeniServis()
        {
        }

        public int Meni()
        {
            int komanda = -1;
            do
            {
                Console.WriteLine("\n========================= POCETNI MENI =========================");
                Console.WriteLine("\t1. UNESI PODATKE");
                Console.WriteLine("\t2. POKRENI AUTOMATSKI UNOS PODATAKA");
                Console.WriteLine("\t3. PROMENI KORISNIKA");
                Console.WriteLine("\t4. IZADJI");
                Console.Write("\tKOMANDA: ");

                try
                {
                    komanda = Convert.ToInt32(Console.ReadLine());


                    if (komanda > 4 || komanda <= 0)
                    {
                        Console.WriteLine("POGRESAN UNOS. UNESITE PONOVO!");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("POGRESAN UNOS. UNESITE PONOVO!");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while (komanda > 4 || komanda <= 0);

            return komanda;
        }
    }
}
