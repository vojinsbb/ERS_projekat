namespace Domain.Modeli
{
    public abstract class Entitet
    {
        public string Naziv { get; set; } = String.Empty;
        public int ZivotniPoeni { get; set; } = 0;
        public int KolicinaZlatnihNovcica { get; set; } = 0;

        protected Entitet() { }

        protected Entitet(string naziv, int zivotniPoeni, int kolicinaZlatnihNovcica)
        {
            Naziv = naziv;
            ZivotniPoeni = zivotniPoeni;
            KolicinaZlatnihNovcica = kolicinaZlatnihNovcica;
        }
    }
}
