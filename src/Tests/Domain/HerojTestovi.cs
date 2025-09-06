using Domain.Modeli;
using Domain.Repozitorijumi.HerojiRepozitorijum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class HerojTestovi
    {
        [Test]
        [TestCase("Superman", 400, 30, 200)]
        [TestCase("BatMan", 450, 45, 200)]
        [TestCase("Deadpool", 500, 50, 200)]
        [TestCase("Spiderman", 480, 40, 200)]
        [TestCase("Iron Man", 320, 50, 200)]
        [TestCase("Capetan America", 350, 35, 200)]
        [TestCase("Steve", 200, 70, 200)]
        [TestCase("Enderman", 300, 30, 200)]
        [TestCase("Zombi", 450, 33, 200)]
        [TestCase("Diki", 500, 81, 200)]
        [TestCase("Vujadin", 500, 82, 200)]
        [TestCase("Pas Maks", 550, 69, 200)]
        [TestCase("Yugi", 420, 69, 200)]
        [TestCase("Kuribo", 300, 25, 200)]
        [TestCase("Snupi", 250, 80, 200)]
        [TestCase("Vudstok", 400, 30, 200)]
        [TestCase("Kuromi", 200, 50, 200)]
        [TestCase("Papa Het", 450, 43, 200)]
        [TestCase("David Bowie", 500, 35, 200)]
        [TestCase("Pera", 360, 63, 200)]

        public void Konstruktor_saParametrima_OK(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovica)
        {
            Heroj h = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, kolicinaZlatnihNovica);

            Assert.That(h, Is.Not.Null);
            Assert.That(h.Naziv, Is.EqualTo(nazivHeroja));
            Assert.That(h.ZivotniPoeni, Is.EqualTo(zivotniPoeni));
            Assert.That(h.JacinaNapada, Is.EqualTo(jacinaNapada));
            Assert.That(h.KolicinaZlatnihNovcica, Is.EqualTo(kolicinaZlatnihNovica));
        }

        [Test]
        [TestCaseSource(typeof(HerojiRepozitorijum), nameof(HerojiRepozitorijum.spisakHerojaTest))]

        public void Konstruktor_kopijeOK(Heroj _heroj)
        {
            Heroj h = new Heroj(_heroj);

            Assert.That(h, Is.Not.Null);
            Assert.That(h.Naziv, Is.EqualTo(_heroj.Naziv));
            Assert.That(h.ZivotniPoeni, Is.EqualTo(_heroj.ZivotniPoeni));
            Assert.That(h.JacinaNapada, Is.EqualTo(_heroj.JacinaNapada));
            Assert.That(h.KolicinaZlatnihNovcica, Is.EqualTo(_heroj.KolicinaZlatnihNovcica));
        }


    }
}
