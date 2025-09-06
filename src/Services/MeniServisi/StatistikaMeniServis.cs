using Domain.Servisi;

namespace Services.MeniServisi
{
    public class StatistikaMeniServis : IStatistikaMeniServis
    {
        public int StatistikaMeni()
        {
            int komanda = -1;
            do
            {
                Console.WriteLine("\n========================= IZBOR STATISTIKE =========================");
                Console.WriteLine("\t1. ISPISI NA EKRANU");
                Console.WriteLine("\t2. SACUVAJ NA DESKTOP-u");
                Console.Write("\tKOMANDA: ");
                try
                {
                    komanda = Convert.ToInt32(Console.ReadLine());

                    if (komanda > 2 || komanda <= 0)
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
            } while (komanda > 2 || komanda <= 0);

            return komanda;
        }
    }
}
