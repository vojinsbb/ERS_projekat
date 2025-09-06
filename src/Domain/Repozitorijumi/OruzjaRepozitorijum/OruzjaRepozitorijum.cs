using Domain.Modeli;

namespace Domain.Repozitorijumi.OruzjaRepozitorijum
{
    public class OruzjaRepozitorijum : IOruzjaRepozitorijum
    {
        private static readonly List<Predmet> sva_oruzja;

        static OruzjaRepozitorijum()
        {
            sva_oruzja = new List<Predmet>
            {
                new Oruzje("Dijamantski mac", 500, 30, new Random().Next(1, 6)),
                new Oruzje("Zlatna sekira", 251, 20, new Random().Next(1, 6)),
                new Oruzje("Srebrni mac", 250, 20, new Random().Next(1, 6)),
                new Oruzje("Drveni kramp", 100, 15, new Random().Next(1, 6)),
                new Oruzje("Luk i strela", 200, 20, new Random().Next(1, 6)),
                new Oruzje("Metalno koplje", 300, 25, new Random().Next(1, 6)),
                new Oruzje("Trozubac", 350, 25, new Random().Next(1, 6)),
                new Oruzje("Glock 17", 500, 35, new Random().Next(1, 6)),
                new Oruzje("CZ99", 500, 35, new Random().Next(1, 6)),
                new Oruzje("AK47", 500, 40, new Random().Next(1, 6)),
                new Oruzje("M416", 500, 40, new Random().Next(1, 6)),
                new Oruzje("Magicni stapic", 300, 30, new Random().Next(1, 6)),
                new Oruzje("Motorna testera", 400, 20, new Random().Next(1, 6)),
                new Oruzje("Zlatni kramp", 500, 20, new Random().Next(1, 6)),
                new Oruzje("Bomba", 450, 40, new Random().Next(1, 6)),
                new Oruzje("Bojna sekira", 300, 20, new Random().Next(1, 6)),
                new Oruzje("Lakonski stap", 200, 15, new Random().Next(1, 6))
            };
        }

        public List<Predmet> spisakOruzja() { return sva_oruzja; }
        public static List<Predmet> spisakOruzjaTest() { return sva_oruzja; }
    }
}
