using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Repozitorijumi.HerojiRepozitorijum;
using Domain.Repozitorijumi.MapeRepozitorijum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class MapaTestovi
    {
        [Test]
        public void Konstruktor_PrazanOK()
        {
            Mapa m = new Mapa();

            Assert.That(m, Is.Not.Null);
        }

        [Test]
        [TestCase("Dust 2", TipMape.LETNJA, 10, 8)]
        [TestCase("Bikini Bottom", TipMape.ZIMSKA, 8, 10)]
        [TestCase("Fakultet Tehničkih Nauka", TipMape.ZIMSKA, 12, 12)]
        [TestCase("Novi Sad", TipMape.LETNJA, 10, 9)]
        [TestCase("Zajecar", TipMape.LETNJA, 14, 7)]
        [TestCase("Sombor", TipMape.ZIMSKA, 8, 5)]
        [TestCase("Zemlja Dembelija", TipMape.LETNJA, 10, 10)]
        [TestCase("Kupusijada Futog", TipMape.LETNJA, 6, 7)]
        [TestCase("Jugoslavija", TipMape.ZIMSKA, 16, 9)]
        [TestCase("Lyoko", TipMape.ZIMSKA, 10, 7)]
        [TestCase("Atomsko Skloniste", TipMape.LETNJA, 8, 8)]

        public void Konstruktor_ParametriOK(string nazivMape, TipMape tipMape, int maksBrojIgraca, int brojPomocnihEntiteta)
        {
            Mapa m = new Mapa(nazivMape, tipMape, maksBrojIgraca, brojPomocnihEntiteta);

            Assert.That(m, Is.Not.Null);
            Assert.That(m.NazivMape, Is.EqualTo(nazivMape));
            Assert.That(m.TipMape, Is.EqualTo(tipMape));
            Assert.That(m.MaksBrojIgraca, Is.EqualTo(maksBrojIgraca));
            Assert.That(m.BrojPomocnihEntiteta, Is.EqualTo(brojPomocnihEntiteta));

        }

        [Test]
        [TestCaseSource(typeof(MapeRepozitorijum), nameof(MapeRepozitorijum.SpisakMapaTest))]
        public void Konstruktor_KopijeOK(Mapa _mapa)
        {
            Mapa m = new Mapa(_mapa);

            Assert.That(m, Is.Not.Null);
            Assert.That(m.NazivMape, Is.EqualTo(_mapa.NazivMape));
            Assert.That(m.TipMape, Is.EqualTo(_mapa.TipMape));
            Assert.That(m.MaksBrojIgraca, Is.EqualTo(_mapa.MaksBrojIgraca));
            Assert.That(m.BrojPomocnihEntiteta, Is.EqualTo(_mapa.BrojPomocnihEntiteta));
        }
    }
}
