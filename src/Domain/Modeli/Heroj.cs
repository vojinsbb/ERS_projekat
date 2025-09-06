namespace Domain.Modeli
{
    public class Heroj : Entitet
    {
        public int JacinaNapada { get; set; } = 0; //jacina napada u zivotnim poenima

        public Heroj(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int kolicinaZlatnihNovcica) : base(nazivHeroja, zivotniPoeni, kolicinaZlatnihNovcica)
        {
            JacinaNapada = jacinaNapada;
        }


        public Heroj(Heroj _heroj) : base(_heroj.Naziv, _heroj.ZivotniPoeni, _heroj.KolicinaZlatnihNovcica)
        {
            JacinaNapada = _heroj.JacinaNapada;
        }

    }
}
