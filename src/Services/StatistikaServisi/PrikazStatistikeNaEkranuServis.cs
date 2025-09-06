using Domain.Servisi;

namespace Services.StatistikaServisi
{
    public class PrikazStatistikeNaEkranuServis : IPrikazStatistikeServis
    {
        public void PrikaziStatistiku(string stats)
        {
            Console.WriteLine(stats);
        }
    }
}
