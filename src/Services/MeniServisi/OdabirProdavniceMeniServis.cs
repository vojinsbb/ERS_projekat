using Domain.Modeli;
using Domain.Servisi;

namespace Services.MeniServisi
{
    public class OdabirProdavniceMeniServis : IOdabirProdavniceServis
    {
        public Prodavnica Odaberi(List<Prodavnica> sve_prodavnice)
        {
            int k = 0;
            Prodavnica p = new Prodavnica(sve_prodavnice[0]);

            int i = 1;

            Console.WriteLine("IZABERITE PRODAVNICU: ");

            foreach (Prodavnica _p in sve_prodavnice)
                Console.WriteLine("\t" + i++ + ". " + _p.NazivProdavnice);

            do
            {
                try
                {
                    Console.Write("KOMANDA: ");
                    k = Convert.ToInt32(Console.ReadLine());

                    if (k < 1 || k > sve_prodavnice.Count)
                        Console.WriteLine("NEISPRAVAN UNOS. POKUSAJTE PONOVO.");
                    else
                        p = new Prodavnica(sve_prodavnice[k - 1]);
                }
                catch (Exception)
                {
                    Console.WriteLine("NEISPRAVAN UNOS. POKUSAJTE PONOVO.");
                }
            } while (k < 1 || k > sve_prodavnice.Count);

            return p;
        }
    }
}
