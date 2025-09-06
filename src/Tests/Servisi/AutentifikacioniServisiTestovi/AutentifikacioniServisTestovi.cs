using Domain.Servisi;
using Domain.Enumeracije;
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Modeli;

namespace Tests.Servisi.AutentifikacioniServisiTestovi
{
    [TestFixture]
    public class AutentifikacioniServisTestovi
    {
        Mock<IAutentifikacijaServis> aut_servis;

        public AutentifikacioniServisTestovi() => aut_servis = new Mock<IAutentifikacijaServis>();

        [SetUp]

        public void Setup()
        {
            aut_servis = new Mock<IAutentifikacijaServis>();
        }

        [Test]
        [TestCase("dimitrije", "123")]
        [TestCase("vojin", "456")]
        public void PrijavaSaIspravnimPodacima(string korisnickoIme, string lozinka)
        {
            
            Korisnik korisnik = new Korisnik(korisnickoIme, lozinka, "");

            aut_servis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((true, korisnik, GreskaUPrijavi.NEMA_GRESKE));

            (bool uspesnaAutentifikacija, Korisnik prijavljen, GreskaUPrijavi greska) = aut_servis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesnaAutentifikacija, Is.True);
            Assert.That(prijavljen, Is.Not.Null);
            Assert.That(prijavljen.KorisnickoIme, Is.EqualTo(korisnickoIme));
            Assert.That(prijavljen.Lozinka, Is.EqualTo(lozinka));
            Assert.That(greska, Is.EqualTo(GreskaUPrijavi.NEMA_GRESKE));
        }

        [Test]
        [TestCase("mirko", "123")]
        [TestCase("slavko", "123")]
        public void PrijavaSaNeispravnimKorisnickimImenom(string korisnickoIme, string lozinka)
        { 
            Korisnik korisnik;

            aut_servis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((false, null, GreskaUPrijavi.KORISNICKO_IME));

            (bool uspesnaAutentifikacija, korisnik, GreskaUPrijavi greska) = aut_servis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesnaAutentifikacija, Is.False);
            Assert.That(korisnik, Is.Null);
            Assert.That(greska, Is.EqualTo(GreskaUPrijavi.KORISNICKO_IME));
        }

        [Test]
        [TestCase("dimitrije", "978")]
        [TestCase("vojin", "3")]
        public void PrijavaSaNeispravnomLozinkom(string korisnickoIme, string lozinka)
        {
            Korisnik korisnik = new Korisnik(korisnickoIme, lozinka, "");

            aut_servis.Setup(x => x.Prijava(korisnickoIme, lozinka)).Returns((false, null, GreskaUPrijavi.LOZINKA));

            (bool uspesnaAutentifikacija, korisnik, GreskaUPrijavi greska) = aut_servis.Object.Prijava(korisnickoIme, lozinka);

            Assert.That(uspesnaAutentifikacija, Is.False);
            Assert.That(korisnik, Is.Null);
            Assert.That(greska, Is.EqualTo(GreskaUPrijavi.LOZINKA));
        }


    }
}
