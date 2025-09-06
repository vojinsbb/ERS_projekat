using Domain.Modeli;

namespace Domain.Repozitorijumi.HerojiRepozitorijum
{
    public class HerojiRepozitorijum : IHerojiRepozitorijum
    {

        private static readonly List<Heroj> svi_heroji;

        static HerojiRepozitorijum()
        {
            svi_heroji = new List<Heroj> {
                new Heroj("Superman", 400, 30, 200),
                new Heroj("BatMan", 450, 45, 200),
                new Heroj("Deadpool", 500, 50, 200),
                new Heroj("Spiderman", 480, 40, 200),
                new Heroj("Iron Man", 320, 50, 200),
                new Heroj("Capetan America", 350, 35, 200),
                new Heroj("Steve", 200, 70, 200),
                new Heroj("Enderman", 300, 30, 200),
                new Heroj("Zombi", 450, 33, 200),
                new Heroj("Diki", 500, 81, 200),
                new Heroj("Vujadin", 500, 82, 200),
                new Heroj("Pas Maks", 550, 69, 200),
                new Heroj("Yugi", 420, 69, 200),
                new Heroj("Kuribo", 300, 25, 200),
                new Heroj("Snupi", 250, 80, 200),
                new Heroj("Vudstok", 400, 30, 200),
                new Heroj("Kuromi", 200, 50, 200),
                new Heroj("Papa Het", 450, 43, 200),
                new Heroj("David Bowie", 500, 35, 200),
                new Heroj("Pera", 360, 63, 200)
            };

        }

        public List<Heroj> spisakHeroja() { return svi_heroji; }
        public static List<Heroj> spisakHerojaTest() { return svi_heroji; } //staticka metoda iskljucivo za testiranje
    }
}
