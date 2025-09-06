using Domain.Modeli;
using Domain.Repozitorijumi.OruzjaRepozitorijum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class OruzjeTestovi
    {

        [Test]
        public void Konstruktor_PrazanOK()
        {
            Oruzje o = new Oruzje();

            Assert.That(o, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(typeof(OruzjaRepozitorijum), nameof(OruzjaRepozitorijum.spisakOruzjaTest))]
        public void Konstruktor_ListaOK(Oruzje oruzje)
        {
            //test konstruktora sa parametrima pomocu elemenata iz liste oruzja
            //test se preskace ako nisu ucitane iste random vrednosti u listi
            //sto ne znaci da nece proci u suprotnom slucaju (PROVERENO!!)
            Oruzje o = new Oruzje(oruzje.Naziv, oruzje.Cena, oruzje.PoeniZaNapad, oruzje.DostupnaKolicinaZaKupovinu);

            Assert.That(o, Is.Not.Null);
            Assert.That(o.Naziv, Is.EqualTo(oruzje.Naziv));
            Assert.That(o.Cena, Is.EqualTo(oruzje.Cena));
            Assert.That(o.PoeniZaNapad, Is.EqualTo(oruzje.PoeniZaNapad));
            Assert.That(o.DostupnaKolicinaZaKupovinu, Is.EqualTo(oruzje.DostupnaKolicinaZaKupovinu));
            Assert.That(o.DostupnaKolicinaZaKupovinu, Is.LessThanOrEqualTo(5));
            Assert.That(o.DostupnaKolicinaZaKupovinu, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        [TestCase("Dijamantski mac", 500, 30, 3)]
        [TestCase("Zlatna sekira", 251, 20, 3)]
        [TestCase("Srebrni mac", 250, 20, 2)]
        [TestCase("Drveni kramp", 100, 15, 3)]
        [TestCase("Luk i strela", 200, 20, 5)]
        [TestCase("Metalno koplje", 300, 25, 1)]
        [TestCase("Trozubac", 350, 25, 4)]
        [TestCase("Glock 17", 500, 35, 3)]
        [TestCase("CZ99", 500, 35, 4)]
        [TestCase("AK47", 500, 40, 3)]
        [TestCase("M416", 500, 40, 5)]
        [TestCase("Magicni stapic", 300, 30, 4)]
        [TestCase("Motorna testera", 400, 20, 3)]
        [TestCase("Zlatni kramp", 500, 20, 2)]
        [TestCase("Bomba", 450, 40, 1)]
        [TestCase("Bojna sekira", 300, 20, 3)]
        [TestCase("Lakonski stap", 200, 15, 4)]
  
        public void Konstruktor_ParametriOK(string naziv, int cena, int poeniZaNapad, int dostupnaKolicinaZaKupovinu)
        {
            //test konstruktora sa parametrima sa zapravo parametrima,
            //random vrednosti su hard kodovane radi provere ispravnosti testova
            Oruzje o = new Oruzje(naziv, cena, poeniZaNapad, dostupnaKolicinaZaKupovinu);

            Assert.That(o, Is.Not.Null);
            Assert.That(o.Naziv, Is.EqualTo(naziv));
            Assert.That(o.Cena, Is.EqualTo(cena));
            Assert.That(o.PoeniZaNapad, Is.EqualTo(poeniZaNapad));
            Assert.That(o.DostupnaKolicinaZaKupovinu, Is.EqualTo(dostupnaKolicinaZaKupovinu));
            Assert.That(o.DostupnaKolicinaZaKupovinu, Is.LessThanOrEqualTo(5));
            Assert.That(o.DostupnaKolicinaZaKupovinu, Is.GreaterThanOrEqualTo(1));
        }
    }
}
