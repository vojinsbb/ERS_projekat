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
    public class PomocniEntitetTestovi
    {
        [Test]
        [TestCase("pomocniEntitet1")]
        [TestCase("pomocniEntitet2")]
        [TestCase("pomocniEntitet3")]
        [TestCase("pomocniEntitet4")]
        [TestCase("pomocniEntitet5")]
        public void Konstruktor_OK(string nazivEntiteta)
        {
            PomocniEntitet pe = new PomocniEntitet(nazivEntiteta);
            Assert.That(pe, Is.Not.Null);
            Assert.That(pe.Naziv, Is.EqualTo(nazivEntiteta));
            Assert.That(pe.ZivotniPoeni, Is.LessThanOrEqualTo(15));
            Assert.That(pe.ZivotniPoeni, Is.GreaterThanOrEqualTo(1));
            Assert.That(pe.KolicinaZlatnihNovcica, Is.LessThanOrEqualTo(90));
            Assert.That(pe.KolicinaZlatnihNovcica, Is.GreaterThanOrEqualTo(20));
        }
    }
}
