using Domain.Modeli;
using Domain.Servisi;
using Services.BitkaServisi;
using Services.VremenskiServisi;

namespace Presentation.BitkaUI
{
    public class BitkaUI : IBitkaUI
    {
        public BitkaUI() { }

        public bool ZapocniBitku(Mapa _mapa)
        {   
            IVremeServis vremeServis = new VremeServis();
            INapadServis napadServis = new NapadServis();
            IKupovinaServis kupovinaServis = new KupovinaServis();

            IBitkaServis bitka = new BitkaServis(vremeServis, napadServis, kupovinaServis);

            Console.Clear();
            Console.WriteLine("ZAPOCINJEM BITKU...");
            Thread.Sleep(1000);
            Console.Clear();

            if (_mapa != null)
            {
                Console.WriteLine(_mapa.PlaviTim?.NazivTima + " vs " + _mapa.CrveniTim?.NazivTima);
                Console.WriteLine();
                if(!bitka.Bitka(_mapa)) return false;
                Console.WriteLine();
                return true;
            }
            
            Console.WriteLine();
            return false;
        }
    }
}
