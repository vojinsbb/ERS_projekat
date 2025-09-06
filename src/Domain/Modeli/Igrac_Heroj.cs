namespace Domain.Modeli
{
    public class Igrac_Heroj
    {
        public int idx;
        public Igrac? Igrac { get; set; }
        public Heroj? OdabranHeroj { get; set; }
        public bool tim; //false plavi tim; true crveni tim;

        public Igrac_Heroj() { }

        public Igrac_Heroj(Igrac_Heroj ih)
        {
            idx = ih.idx;
            Igrac = ih.Igrac;
            OdabranHeroj = ih.OdabranHeroj;

            if (OdabranHeroj != null)
                OdabranHeroj.ZivotniPoeni = 0;

            tim = ih.tim;
        }
    }
}
