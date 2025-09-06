using Domain.Repozitorijumi.HerojiRepozitorijum;
using Domain.Repozitorijumi.IgraciRepozitorijum;
using System.Text;


namespace Domain.Modeli
{
    public class Tim
    {
        public string NazivTima;
        public List<Igrac> igraciUTimu = new List<Igrac>();
        public List<Heroj> herojiUTimu = new List<Heroj>();
        public int BrojIgracaUTimu { get; set; } = 0;

        public Tim(int[] mestaIgraca, int[] mestaHeroja, string nazivTima)
        {
            for (int i = 0; i < mestaIgraca.Length; i++)
                igraciUTimu.Add(new IgraciRepozitorijum().SpisakIgraca().ElementAt(mestaIgraca[i]));

            for (int i = 0; i < mestaHeroja.Length; i++)
                herojiUTimu.Add(new Heroj(new HerojiRepozitorijum().spisakHeroja().ElementAt(mestaHeroja[i])));

            this.NazivTima = nazivTima;
            BrojIgracaUTimu = igraciUTimu.Count();

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\nTIM: " + NazivTima + "\n");


            for (int i = 0; i < BrojIgracaUTimu; ++i)
                sb.Append("\t IGRAC: " + igraciUTimu[i].KorisnickoIme + " :: HEROJ: " + herojiUTimu[i].Naziv + "\n");

            return sb.ToString();
        }
    }
}
