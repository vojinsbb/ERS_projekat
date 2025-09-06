using Domain.Servisi;

namespace Services.StatistikaServisi
{
    public class CuvanjeStatistikeUDatoteku : IPrikazStatistikeServis
    {
        private string nazivDatoteke;

        public CuvanjeStatistikeUDatoteku(string nazivDatoteke)
        {
            this.nazivDatoteke = nazivDatoteke;
        }

        public void PrikaziStatistiku(string stats)
        {
            try
            {
                string putanja = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + this.nazivDatoteke + ".txt";
                File.WriteAllText(putanja, stats);
                Console.WriteLine();
                Console.WriteLine("STATISTIKA USPESNO SACUVANA NA DESKTOP-u.");
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("GRESKA PRILIKOM UPISA U DATOTEKU.");
            }
        }
    }
}
