using Domain.Enumeracije;
using Domain.Modeli;

namespace Domain.Servisi
{
    public interface IAutentifikacijaServis
    {
        public (bool, Korisnik, GreskaUPrijavi) Prijava(string korisnickoIme, string lozinka);
    }
}
