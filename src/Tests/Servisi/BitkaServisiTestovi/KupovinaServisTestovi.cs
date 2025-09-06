using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Servisi.BitkaServisiTestovi
{
    [TestFixture]
    public class KupovinaServisTestovi
    {
        Mock<IKupovinaServis> kupovinaServis;

        public KupovinaServisTestovi() => kupovinaServis = new Mock<IKupovinaServis>();

        [SetUp]

        public void Setup()
        {
            kupovinaServis = new Mock<IKupovinaServis>();
        }

        [Test]
        [TestCase("Deadpool", 300, 25, 600, "Luk i strela", 250, 55, 3)]
        [TestCase("BatMan", 450, 45, 700, "Mac", 250, 55, 5)]
        [TestCase("Zombi", 450, 33, 500, "Kramp", 250, 55, 1)]
 
        public void UspesnaKupovinaOruzja(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovcica, string nazivPredmeta,  int cena,  int bodoviZaNapad, int dostupnaKolicina)
        {
            Heroj kupac = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, kolicinaZlatnihNovcica);
            Oruzje _predmet = new Oruzje(nazivPredmeta, cena, bodoviZaNapad, dostupnaKolicina);

            kupovinaServis.Setup(x => x.Kupi(kupac, _predmet)).Returns(true);

            bool uspesnaKupovina = kupovinaServis.Object.Kupi(kupac, _predmet);

            Assert.That(uspesnaKupovina, Is.True);

        }

        [Test]
        [TestCase("Deadpool", 300, 25, 600, "III", 250, 55, 3)]
        [TestCase("BatMan", 450, 45, 700, "Magija Vinksa IV", 250, 55, 2)]
        [TestCase("Zombi", 450, 33, 500, "PRVI I", 250, 55, 1)]
 
        public void UspesnaKupovinaNapitka(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovcica, string nazivPredmeta,  int cena,  int bodoviZaNapad, int dostupnaKolicina)
        {
            Heroj kupac = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, kolicinaZlatnihNovcica);
            MagicniNapitak _predmet = new MagicniNapitak(nazivPredmeta, cena, bodoviZaNapad, dostupnaKolicina);

            kupovinaServis.Setup(x => x.Kupi(kupac, _predmet)).Returns(true);

            bool uspesnaKupovina = kupovinaServis.Object.Kupi(kupac, _predmet);

            Assert.That(uspesnaKupovina, Is.True);

        }

        [Test]
        [TestCase("Deadpool", 300, 25, 300, "Luk i strela", 250, 55, 3)]
        [TestCase("BatMan", 450, 45, 700, "Mac", 250, 55, 0)]
        [TestCase("Zombi", 450, 33, 500, "Kramp", 250, 55, 0)]

        public void NespesnaKupovinaOruzja(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovcica, string nazivPredmeta, int cena, int bodoviZaNapad, int dostupnaKolicina)
        {
            Heroj kupac = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, kolicinaZlatnihNovcica);
            MagicniNapitak _predmet = new MagicniNapitak(nazivPredmeta, cena, bodoviZaNapad, dostupnaKolicina);

            kupovinaServis.Setup(x => x.Kupi(kupac, _predmet)).Returns(false);

            bool uspesnaKupovina = kupovinaServis.Object.Kupi(kupac, _predmet);

            Assert.That(uspesnaKupovina, Is.False);

        }

        [Test]
        [TestCase("Deadpool", 300, 25, 300, "III", 250, 55, 3)]
        [TestCase("BatMan", 450, 45, 700, "Magija Vinksa IV", 250, 55, 0)]
        [TestCase("Zombi", 450, 33, 500, "PRVI I", 250, 55, 0)]
        public void NespesnaKupovinaNapitka(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovcica, string nazivPredmeta, int cena, int bodoviZaNapad, int dostupnaKolicina)
        {
            Heroj kupac = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, kolicinaZlatnihNovcica);
            MagicniNapitak _predmet = new MagicniNapitak(nazivPredmeta, cena, bodoviZaNapad, dostupnaKolicina);

            kupovinaServis.Setup(x => x.Kupi(kupac, _predmet)).Returns(false);

            bool uspesnaKupovina = kupovinaServis.Object.Kupi(kupac, _predmet);

            Assert.That(uspesnaKupovina, Is.False);

        }

    }
}
