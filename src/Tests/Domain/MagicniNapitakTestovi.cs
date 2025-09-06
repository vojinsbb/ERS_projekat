using Domain.Modeli;
using Domain.Repozitorijumi.HerojiRepozitorijum;
using Domain.Repozitorijumi.MagicniNapiciRepozitorijum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class MagicniNapitakTestovi
    {

        [Test]
        public void Konstruktor_PrazanOK() 
        {
            MagicniNapitak mn = new MagicniNapitak();

            Assert.That(mn, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(typeof(MagicniNapiciRepozitorijum), nameof(MagicniNapiciRepozitorijum.SpisakMagicnihNapitakaTest))]
        public void Konstruktor_ListaOK(MagicniNapitak _magicniNapitak)
        {
            //test konstruktora sa parametrima pomocu elemenata iz liste magicnih napitaka
            //test se preskace ako nisu ucitane iste random vrednosti u listi
            //sto ne znaci da nece proci u suprotnom slucaju (PROVERENO!!)
            MagicniNapitak mn = new MagicniNapitak(_magicniNapitak.Naziv, _magicniNapitak.Cena, _magicniNapitak.PoeniZaNapad, _magicniNapitak.DostupnaKolicinaZaKupovinu);

            Assert.That(mn, Is.Not.Null);
            Assert.That(mn.Naziv, Is.EqualTo(_magicniNapitak.Naziv));
            Assert.That(mn.Cena, Is.EqualTo(_magicniNapitak.Cena));
            Assert.That(mn.PoeniZaNapad, Is.EqualTo(_magicniNapitak.PoeniZaNapad));
            Assert.That(mn.DostupnaKolicinaZaKupovinu, Is.EqualTo(_magicniNapitak.DostupnaKolicinaZaKupovinu));
            Assert.That(mn.DostupnaKolicinaZaKupovinu, Is.LessThanOrEqualTo(3));
            Assert.That(mn.DostupnaKolicinaZaKupovinu, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        [TestCase("PRVI I", 100, 20, 2)]
        [TestCase("Duplikat II", 500, 50, 1)]
        [TestCase("III", 300, 30, 3)]
        [TestCase("Čelični napad V", 250, 25, 2)]
        [TestCase("Magija Vinksa IV", 400, 35, 3)]
        public void Konstruktor_ParametriOK(string naziv, int cena, int poeniZaNapad, int dostupnaKolicinaZaKupovinu)
        {
            //test konstruktora sa parametrima sa zapravo parametrima,
            //random vrednosti su hard kodovane radi provere ispravnosti testova
            MagicniNapitak mn = new MagicniNapitak(naziv, cena, poeniZaNapad, dostupnaKolicinaZaKupovinu);

            Assert.That(mn, Is.Not.Null);
            Assert.That(mn.Naziv, Is.EqualTo(naziv));
            Assert.That(mn.Cena, Is.EqualTo(cena));
            Assert.That(mn.PoeniZaNapad, Is.EqualTo(poeniZaNapad));
            Assert.That(mn.DostupnaKolicinaZaKupovinu, Is.EqualTo(dostupnaKolicinaZaKupovinu));
            Assert.That(mn.DostupnaKolicinaZaKupovinu, Is.LessThanOrEqualTo(3));
            Assert.That(mn.DostupnaKolicinaZaKupovinu, Is.GreaterThanOrEqualTo(1));
        }
    }
}
