using Domain.Modeli;
using Domain.Repozitorijumi.OruzjaRepozitorijum;

namespace Domain.PomocneMetode.Oruzje
{
    public class OdabirNasumicnogOruzja
    {
        public static List<Predmet> NasumicanIzbor(int broj)
        {
            List<Predmet> izabranaOruzja = [];
            List<Predmet> svaOruzja = new OruzjaRepozitorijum().spisakOruzja();
            int i = 0;
            Random r = new();

            while (i < broj)
            {
                int j = r.Next(0, svaOruzja.Count());
                try
                {
                    if (!izabranaOruzja.Contains(svaOruzja[j]))
                    {
                        izabranaOruzja.Add(svaOruzja[j]);
                        i++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("GRESKA U ODABIRU ORUZJA: " + ex.Message);
                }
            }

            return izabranaOruzja;
        }
    }
}
