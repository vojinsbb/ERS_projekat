using Domain.Modeli;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class TimTestovi
    {
        [Test]
        [TestCase(new int[] {1, 3, 7, 9, 2}, new int[] {2, 7, 8, 9, 4}, "kupus")]
        [TestCase(new int[] {3, 4, 2, 1}, new int[] {7, 8, 9, 2}, "pecenje")]
        [TestCase(new int[] {3, 4, 2, 1, 5, 18}, new int[] {7, 8, 9, 2, 10, 5}, "slatkoPomirenje")]
        public void Konstruktor_OK(int[] mestaIgraca, int[] mestaHeroja, string nazivTima)
        {
            Tim t = new Tim(mestaIgraca, mestaHeroja, nazivTima);

            Assert.That(t, Is.Not.Null);
            Assert.That(t.igraciUTimu, Is.Not.Null); //tvrdim da postoji lista igraca i da su svi igraci ubaceni u listu
            Assert.That(t.igraciUTimu.Count, Is.EqualTo(mestaIgraca.Count()));
            Assert.That(t.herojiUTimu, Is.Not.Null); ////tvrdim da postoji lista heroja i da su svi heroji ubaceni u listu
            Assert.That(t.herojiUTimu.Count, Is.EqualTo(mestaHeroja.Count()));
            Assert.That(t.NazivTima, Is.EqualTo(nazivTima));
        }
    }
}
