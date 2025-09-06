using Domain.Modeli;

namespace Domain.Repozitorijumi.MagicniNapiciRepozitorijum
{
    public class MagicniNapiciRepozitorijum : IMagicniNapiciRepozitorijum
    {
        private static readonly List<Predmet> svi_napici;

        static MagicniNapiciRepozitorijum()
        {
            svi_napici = new List<Predmet>
            {
                new MagicniNapitak("PRVI I", 100, 20, new Random().Next(1, 4)),
                new MagicniNapitak("Duplikat II", 500, 50, new Random().Next(1, 4)),
                new MagicniNapitak("III", 300, 30, new Random().Next(1, 4)),
                new MagicniNapitak("Čelični napad V", 250, 25, new Random().Next(1, 4)),
                new MagicniNapitak("Magija Vinksa IV", 400, 35, new Random().Next(1, 4)),
            };
        }

        public List<Predmet> SpisakMagicnihNapitaka() { return svi_napici; }
        public static List<Predmet> SpisakMagicnihNapitakaTest() { return svi_napici; }
    }
}
