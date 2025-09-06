using Domain.Modeli;
using Domain.Servisi;

namespace Services.BitkaServisi
{
    public class KupovinaServis : IKupovinaServis
    {
        public bool Kupi(Heroj kupac, Predmet _predmet)
        {
            if (kupac.KolicinaZlatnihNovcica >= 500 && _predmet.DostupnaKolicinaZaKupovinu > 0)
            {
                kupac.KolicinaZlatnihNovcica -= _predmet.Cena;
                kupac.JacinaNapada += _predmet.PoeniZaNapad;
                _predmet.DostupnaKolicinaZaKupovinu--;
                return true; //uspesna kupovina
            }

            return false; //neuspesna kupovina
        }
    }
}
