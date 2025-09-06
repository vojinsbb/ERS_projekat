using Domain.Servisi;

namespace Services.VremenskiServisi
{
    public class VremeServis : IVremeServis
    {
        public int Counter { get; set; }

        public void Vreme(int sekunde)
        {
            while (Counter < sekunde)
            {
                Counter++;
                //nit spava dve sekunde umesto jedne jer svaka iteracija ciklusa borbe trosi oko 1s za akciju
                Thread.Sleep(2000);
            }
        }

        public VremeServis()
        {
            Counter = 0;
        }

    }
}
