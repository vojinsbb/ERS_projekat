using Domain.Modeli;

namespace Domain.Repozitorijumi.ProdavniceRepozitorijum
{
    public class ProdavniceRepozitorijum : IProdavniceRepozitorijum
    {
        private static readonly List<Prodavnica> sve_prodavnice;

        static ProdavniceRepozitorijum()
        {
            sve_prodavnice = new List<Prodavnica>
            {
                new Prodavnica(1455, "Beli Dren", new Oruzje().NasumicanPredmet(5), new MagicniNapitak().NasumicanPredmet(3), 0),
                new Prodavnica(2613, "Mirko Market", new Oruzje().NasumicanPredmet(5), new MagicniNapitak().NasumicanPredmet(3), 0),
                new Prodavnica(34829, "Interex", new Oruzje().NasumicanPredmet(5), new MagicniNapitak().NasumicanPredmet(3), 0),
                new Prodavnica(4243, "KINEZI", new Oruzje().NasumicanPredmet(5), new MagicniNapitak().NasumicanPredmet(3), 0),
                new Prodavnica(501, "Trafika", new Oruzje().NasumicanPredmet(5), new MagicniNapitak().NasumicanPredmet(3), 0),
            };
        }

        public List<Prodavnica> SpisakProdavnica() { return sve_prodavnice;  }
        public static List<Prodavnica> SpisakProdavnicaTest() { return sve_prodavnice;  }
    }
}
