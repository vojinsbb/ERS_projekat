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

    public class KorisnikTestovi
    {

        [Test]
        [TestCase("dimitrije", "123", "Dimitrije Stankovic")]
        [TestCase("vojin", "456", "Vojin Jovanovic")]

        public void KonstruktorOK(string korisnickoIme, string lozinka, string imePrezime)
        {
            Korisnik korisnik = new Korisnik(korisnickoIme, lozinka, imePrezime);

            Assert.That(korisnik, Is.Not.Null);
            Assert.That(korisnik.KorisnickoIme, Is.EqualTo(korisnickoIme));
            Assert.That(korisnik.Lozinka, Is.EqualTo(lozinka));
            Assert.That(korisnik.ImePrezime, Is.EqualTo(imePrezime));
        }

        
    }
}
