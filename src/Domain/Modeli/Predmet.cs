namespace Domain.Modeli
{
    public abstract class Predmet
    {
        public string Naziv { get; set; } = string.Empty;
        public int Cena { get; set; } = 0;
        public int PoeniZaNapad { get; set; } = 0;
        public int DostupnaKolicinaZaKupovinu { get; set; } = 0;

        public abstract List<Predmet> NasumicanPredmet(int broj);

        protected Predmet(string naziv, int cena, int poeniZaNapad, int dostupnaKolicinaZaKupovinu)
        {
            Naziv = naziv;
            Cena = cena;
            DostupnaKolicinaZaKupovinu = dostupnaKolicinaZaKupovinu;
            PoeniZaNapad = poeniZaNapad;
        }

        protected Predmet(){}
    }
}
