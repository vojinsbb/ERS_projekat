using Domain.PomocneMetode.Oruzje;

namespace Domain.Modeli
{
    public class Oruzje : Predmet
    {
        public Oruzje(string naziv, int cena, int poeniZaNapad, int dostupnaKolicinaZaKupovinu) : base(naziv, cena, poeniZaNapad, dostupnaKolicinaZaKupovinu)
        { }

        public Oruzje() : base() { }


        public override List<Predmet> NasumicanPredmet(int broj)
        {
            return OdabirNasumicnogOruzja.NasumicanIzbor(broj);
        }

        public override string? ToString()
        {
            return "\"" + Naziv + "\"" + " CENA: " + Cena + " POENI ZA NAPAD: " + PoeniZaNapad + " DOSTUPNO: " + DostupnaKolicinaZaKupovinu;
        }
    }
}


