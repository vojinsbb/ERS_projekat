using Domain.PomocneMetode.MagicniNapitak;

namespace Domain.Modeli
{
    public class MagicniNapitak : Predmet
    {
        public MagicniNapitak() : base() { }

        public MagicniNapitak(string naziv, int cena, int poeniZaNapad, int dostupnaKolicinaZaKupovinu) : base(naziv, cena, poeniZaNapad, dostupnaKolicinaZaKupovinu)
        { }

        public override List<Predmet> NasumicanPredmet(int broj)
        {
            return OdabirNasumicnogNapitka.NasumicanOdabir(broj);
        }

        public override string? ToString()
        {
            return "\"" + Naziv + "\"" + " CENA: " + Cena + " POENI ZA NAPAD: " + PoeniZaNapad + " DOSTUPNO: " + DostupnaKolicinaZaKupovinu;
        }
    }
}
