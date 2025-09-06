using Domain.Modeli;
using Domain.Servisi;

namespace Services.MeniServisi
{
    public class OdabirMapeMeniServis : IOdabirMapeServis
    {
        public Mapa Odaberi(List<Mapa> sve_mape)
        {
            int k = 0;
            Mapa m = new Mapa(sve_mape[0]);

            Console.WriteLine("IZABERITE MAPU: ");

            int i = 1;
            foreach (Mapa _m in sve_mape)
                Console.WriteLine("\t" + i++ + ". " + _m.NazivMape);

            do
            {
                Console.Write("KOMANDA: ");

                try
                {
                    k = Convert.ToInt32(Console.ReadLine());

                    if (k < 1 || k > sve_mape.Count)
                        Console.WriteLine("NEISPRAVAN UNOS. POKUSAJTE PONOVO.");
                    else
                        m = new Mapa(sve_mape[k - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("NEISPRAVAN UNOS. POKUSAJTE PONOVO.");
                }

            } while (k < 1 || k > sve_mape.Count);

            return m;

        }
    }
}
