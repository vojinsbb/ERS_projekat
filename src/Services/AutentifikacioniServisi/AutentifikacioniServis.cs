using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Servisi;

namespace Services.AutentifikacioniServisi
{
    public class AutentifikacioniServis : IAutentifikacijaServis
    {
        private static readonly List<Korisnik> _korisnici;

        static AutentifikacioniServis()
        {
            _korisnici = new List<Korisnik>
            {
                new Korisnik("dimitrije", "123", "Dimitrije Stankovic"),
                new Korisnik("vojin", "456", "Vojin Jovanovic"),
            };
        }
        public (bool, Korisnik, GreskaUPrijavi) Prijava(string korisnickoIme, string lozinka)
        {
            GreskaUPrijavi greska = GreskaUPrijavi.NEMA_GRESKE;
            Korisnik prijavljen = null;
            foreach (Korisnik korisnik in _korisnici)
            {
                if (korisnik.KorisnickoIme.Equals(korisnickoIme))
                { //ako postoji korisnicko ime
                    if (korisnik.Lozinka.Equals(lozinka)) //i ako je uneta ispravna lozinka
                    { //vracamo pronadjenog korisnika
                        prijavljen = korisnik;
                        greska = GreskaUPrijavi.NEMA_GRESKE;
                        return (true, prijavljen, greska);
                    }
                    else
                    {
                        greska = GreskaUPrijavi.LOZINKA;
                    }
                }
            }

            if (greska != GreskaUPrijavi.LOZINKA) greska = GreskaUPrijavi.KORISNICKO_IME; //ako ne postoji korisnik
            prijavljen = null;
            return (false, prijavljen, greska);
        }
    }
}
