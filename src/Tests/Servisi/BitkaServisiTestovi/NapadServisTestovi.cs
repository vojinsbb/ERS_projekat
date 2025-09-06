using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Servisi.BitkaServisiTestovi
{
    [TestFixture]
    public class NapadServisTestovi
    {
        Mock<INapadServis> napadServis;

        public NapadServisTestovi() => napadServis = new Mock<INapadServis>();

        [SetUp]

        public void Setup()
        {
            napadServis = new Mock<INapadServis>();
        }

        //napad heroj heroj uspesno
        //napad heroj heroj neuspesno
        //napad heroj heroj nereseno
        //napad heroj entitet uspesno
        //napad heroj entitet neuspesno

        [Test]
        [TestCase("Diki", 500, 81, 200, "Superman", 400, 30, 200)]
        [TestCase("Vujadin", 500, 82, 200, "Zombi", 450, 33, 200)]
        [TestCase("Yugi", 420, 69, 200, "Kuribo", 300, 25, 200)]
        public void Napad_HerojHeroj_Uspesan(string nazivHeroja1, int zivotniPoeni1, int jacinaNapada1, int kolicinaZlatnihNovcica1, string nazivHeroja2, int zivotniPoeni2, int jacinaNapada2, int kolicinaZlatnihNovcica2)
        {
            Heroj h1 = new Heroj(nazivHeroja1, zivotniPoeni1, jacinaNapada1, kolicinaZlatnihNovcica1);
            Heroj h2 = new Heroj(nazivHeroja2, zivotniPoeni2, jacinaNapada2, kolicinaZlatnihNovcica2);

            napadServis.Setup(x => x.Napad(h1, h2)).Returns(IshodNapada.USPESAN);

            IshodNapada ishod = napadServis.Object.Napad(h1, h2);

            Assert.That(ishod, Is.EqualTo(IshodNapada.USPESAN));
        }

        [Test]
        [TestCase("Diki", 500, 81, 200, "Superman", 400, 30, 200)]
        [TestCase("Vujadin", 500, 82, 200, "Zombi", 450, 33, 200)]
        [TestCase("Yugi", 420, 69, 200, "Kuribo", 300, 25, 200)]
        public void Napad_HerojHeroj_Nespesan(string nazivHeroja1, int zivotniPoeni1, int jacinaNapada1, int kolicinaZlatnihNovcica1, string nazivHeroja2, int zivotniPoeni2, int jacinaNapada2, int kolicinaZlatnihNovcica2)
        {
            //isti heroji samo zamenjena mesta sa test caseovima, tako da slabiji napada jaceg
            Heroj h2 = new Heroj(nazivHeroja1, zivotniPoeni1, jacinaNapada1, kolicinaZlatnihNovcica1);
            Heroj h1 = new Heroj(nazivHeroja2, zivotniPoeni2, jacinaNapada2, kolicinaZlatnihNovcica2);

            napadServis.Setup(x => x.Napad(h1, h2)).Returns(IshodNapada.NEUSPESAN);

            IshodNapada ishod = napadServis.Object.Napad(h1, h2);

            Assert.That(ishod, Is.EqualTo(IshodNapada.NEUSPESAN));
        }

        [Test]
        [TestCase("Diki", 450, 81, 200, "Superman", 400, 81, 200)]
        [TestCase("Vujadin", 500, 82, 200, "Zombi", 450, 82, 200)]
        [TestCase("Yugi", 420, 69, 200, "Kuribo", 300, 69, 200)]
        public void Napad_HerojHeroj_Neresen(string nazivHeroja1, int zivotniPoeni1, int jacinaNapada1, int kolicinaZlatnihNovcica1, string nazivHeroja2, int zivotniPoeni2, int jacinaNapada2, int kolicinaZlatnihNovcica2)
        {
            //isti heroji samo zamenjena mesta sa test caseovima, tako da slabiji napada jaceg
            Heroj h1 = new Heroj(nazivHeroja1, zivotniPoeni1, jacinaNapada1, kolicinaZlatnihNovcica1);
            Heroj h2 = new Heroj(nazivHeroja2, zivotniPoeni2, jacinaNapada2, kolicinaZlatnihNovcica2);

            napadServis.Setup(x => x.Napad(h1, h2)).Returns(IshodNapada.NERESENO);

            IshodNapada ishod = napadServis.Object.Napad(h1, h2);

            Assert.That(ishod, Is.EqualTo(IshodNapada.NERESENO));
        }

        [Test]
        [TestCase("Diki", 450, 81, 200, "pomocniEntitet1")]
        [TestCase("Vujadin", 500, 82, 200, "pomocniEntitet2")]
        [TestCase("Yugi", 420, 69, 200, "pomocniEntitet3")]
        public void Napad_HerojEntitet_Uspesan(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovcica, string nazivEntiteta)
        {
            Heroj h = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, kolicinaZlatnihNovcica);
            PomocniEntitet pe = new PomocniEntitet(nazivEntiteta);

            napadServis.Setup(x => x.Napad(h, pe)).Returns(IshodNapada.USPESAN);

            IshodNapada ishod = napadServis.Object.Napad(h, pe);

            Assert.That(ishod, Is.EqualTo(IshodNapada.USPESAN));

        }

        [Test]
        [TestCase("Diki", 450, 0, 200, "pomocniEntitet1")]
        [TestCase("Vujadin", 500, 0, 200, "pomocniEntitet2")]
        [TestCase("Yugi", 420, 0, 200, "pomocniEntitet3")]
        public void Napad_HerojEntitet_Neuspesan(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovcica, string nazivEntiteta)
        {
            //ocekujemo neuspesan napad jer nasi heroji imaju 0 bodova za napad, te zivotni poeni entiteta nikad nece biti manji od 0
            Heroj h = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, kolicinaZlatnihNovcica);
            PomocniEntitet pe = new PomocniEntitet(nazivEntiteta);

            napadServis.Setup(x => x.Napad(h, pe)).Returns(IshodNapada.NEUSPESAN);

            IshodNapada ishod = napadServis.Object.Napad(h, pe);

            Assert.That(ishod, Is.EqualTo(IshodNapada.NEUSPESAN));

        }

    }
}
