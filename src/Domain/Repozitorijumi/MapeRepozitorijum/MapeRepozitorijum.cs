using Domain.Enumeracije;
using Domain.Modeli;

namespace Domain.Repozitorijumi.MapeRepozitorijum
{
    public class MapeRepozitorijum : IMapeRepozitorijum
    {

        private static readonly List<Mapa> sve_mape;

        static MapeRepozitorijum()
        {
            sve_mape = new List<Mapa>
            {
                new Mapa("Dust 2", TipMape.LETNJA, 10, 8),
                new Mapa("Bikini Bottom", TipMape.ZIMSKA, 8, 10),
                new Mapa("Fakultet Tehničkih Nauka", TipMape.ZIMSKA, 12, 12),
                new Mapa("Novi Sad", TipMape.LETNJA, 10, 9),
                new Mapa("Zajecar", TipMape.LETNJA, 14, 7),
                new Mapa("Sombor", TipMape.ZIMSKA, 8, 5),
                new Mapa("Zemlja Dembelija", TipMape.LETNJA, 10, 10),
                new Mapa("Kupusijada Futog", TipMape.LETNJA, 6, 7),
                new Mapa("Jugoslavija", TipMape.ZIMSKA, 16, 9),
                new Mapa("Lyoko", TipMape.ZIMSKA, 10, 7),
                new Mapa("Atomsko Skloniste", TipMape.LETNJA, 8, 8)
            };
        }

        public List<Mapa> SpisakMapa() { return sve_mape; }
        public static List<Mapa> SpisakMapaTest() { return sve_mape; }
    }
}
