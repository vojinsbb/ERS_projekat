using Domain.Modeli;
using Domain.Servisi;
using Services.MeniServisi;
using Services.StatistikaServisi;

namespace Presentation.StatistikaUI
{
    public class StatistikaUI : IStatistikaUI
    {
        public StatistikaUI() { }

        public void PrikaziStatistiku(Mapa _mapa)
        {
            IPripremaStatistikeServis pripremaStatistike = new PripremaStatistikeServis();
            string stats = pripremaStatistike.PripremaStatistike(_mapa);
            IStatistikaMeniServis statistikaMeni = new StatistikaMeniServis();
            IPrikazStatistikeServis prikazStatistike;
            int komanda = statistikaMeni.StatistikaMeni();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Clear();

            if (komanda == 1)
            {
                prikazStatistike = new PrikazStatistikeNaEkranuServis();
                prikazStatistike.PrikaziStatistiku(stats);
            }
            else
            {
                Console.Write("UNESITE NAZIV FAJLA: ");
                string naziv = Console.ReadLine() ?? "";
                prikazStatistike = new CuvanjeStatistikeUDatoteku(naziv);
                prikazStatistike.PrikaziStatistiku(stats);
            }
        }
    }
}
