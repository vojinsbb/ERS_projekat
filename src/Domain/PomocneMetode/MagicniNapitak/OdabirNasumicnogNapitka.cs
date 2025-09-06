using Domain.Modeli;
using Domain.Repozitorijumi.MagicniNapiciRepozitorijum;

namespace Domain.PomocneMetode.MagicniNapitak
{
    public class OdabirNasumicnogNapitka
    {
        public static List<Predmet> NasumicanOdabir(int broj)
        {
            List<Predmet> izabraniNapici = [];
            List<Predmet> sviNapici = new MagicniNapiciRepozitorijum().SpisakMagicnihNapitaka();
            int i = 0;
            Random r = new();

            while (i < broj)
            {
                int j = r.Next(0, sviNapici.Count);
                try
                {
                    if (!izabraniNapici.Contains(sviNapici[j]))
                    {
                        izabraniNapici.Add(sviNapici[j]);
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GRESKA U ODABIRU NAPITAKA: " + ex.Message);
                }
            }

            return izabraniNapici;
        }
    }
}
