using Domain.Modeli;
using Domain.Repozitorijumi.MapeRepozitorijum;
using Domain.Repozitorijumi.ProdavniceRepozitorijum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class ProdavnicaTestovi
    {
        [Test]
        public void Konstruktor_PrazanOK()
        {
            Prodavnica p = new Prodavnica();

            Assert.That(p, Is.Not.Null);
        }


        [Test]
        [TestCase(1455, "Beli Dren", 0)]
        [TestCase(2613, "Mirko Market", 0)]
        [TestCase(34829, "Interex", 0)]
        [TestCase(4243, "KINEZI", 0)]
        [TestCase(501, "Trafika", 0)]
        public void Konstruktor_ParametriOK(int idProdavnice, string nazivProdavnice, int ukupnaVrednost)
        {
            //buduci da su liste predmeta nasumicne, ne saljemo ih kao parametre testa, jer ce se svakako uvek razlikovati
            //bitno nam je samo da se kreiraju, odnosno da nisu NULL

            Prodavnica p = new Prodavnica(idProdavnice, nazivProdavnice, new Oruzje().NasumicanPredmet(5), new MagicniNapitak().NasumicanPredmet(3), ukupnaVrednost);

            Assert.That(p, Is.Not.Null);
            Assert.That(p.IDProdavnice, Is.EqualTo(idProdavnice));
            Assert.That(p.NazivProdavnice, Is.EqualTo(nazivProdavnice));
            Assert.That(p.OruzjeList, Is.Not.Null);
            Assert.That(p.MagicniNapitakList, Is.Not.Null);
            Assert.That(p.UkupnaVrednost, Is.EqualTo(ukupnaVrednost));
        }

        [Test]
        [TestCaseSource(typeof(ProdavniceRepozitorijum), nameof(ProdavniceRepozitorijum.SpisakProdavnicaTest))]
        public void Konstruktor_KopijeOK(Prodavnica _p)
        {
            
            Prodavnica p = new Prodavnica(_p);

            Assert.That(p, Is.Not.Null);
            Assert.That(p.IDProdavnice, Is.EqualTo(_p.IDProdavnice));
            Assert.That(p.NazivProdavnice, Is.EqualTo(_p.NazivProdavnice));
            Assert.That(p.OruzjeList, Is.Not.Null);
            Assert.That(p.MagicniNapitakList, Is.Not.Null);
            Assert.That(p.UkupnaVrednost, Is.EqualTo(_p.UkupnaVrednost));
        }

    }
}
