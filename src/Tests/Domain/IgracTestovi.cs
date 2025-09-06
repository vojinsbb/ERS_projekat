using Domain.Modeli;
using Domain.Repozitorijumi.HerojiRepozitorijum;
using Domain.Repozitorijumi.IgraciRepozitorijum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class IgracTestovi
    {
        [Test]
        [TestCaseSource(typeof(IgraciRepozitorijum), nameof(IgraciRepozitorijum.SpisakIgracaTest))]

        public void Konstruktor_OK(Igrac _igrac)
        {
            Igrac i = new Igrac(_igrac.KorisnickoIme, _igrac.Online);

            Assert.That(i, Is.Not.Null);
            Assert.That(i.KorisnickoIme, Is.EqualTo(_igrac.KorisnickoIme));
            Assert.That(i.Online, Is.EqualTo(_igrac.Online));
        }

    }
}
