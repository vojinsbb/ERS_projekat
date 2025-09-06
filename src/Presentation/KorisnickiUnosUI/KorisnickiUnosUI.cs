using Domain.Modeli;
using Domain.Repozitorijumi.HerojiRepozitorijum;
using Domain.Repozitorijumi.IgraciRepozitorijum;
using Domain.Repozitorijumi.MapeRepozitorijum;
using Domain.Repozitorijumi.ProdavniceRepozitorijum;
using Domain.Servisi;
using Services.MeniServisi;

namespace Presentation.KorisnickiUnosUI
{
    public class KorisnickiUnosUI : IKorisnickiUnosUI
    {
        private IOdabirMapeServis odabirMape = new OdabirMapeMeniServis();
        private IOdabirHerojaServis odabirHeroja = new OdabirHerojaMeniServis();
        private IOdabirProdavniceServis odabirProdavnice = new OdabirProdavniceMeniServis();
        private IOdabirIgracaServis odabirIgraca = new OdabirIgracaMeniServis();

        public KorisnickiUnosUI() { }

        public Mapa PokreniKorisnickiUnos()
        {
            Mapa _mapa = new Mapa();

            Console.Clear();
            Console.WriteLine("POKRECEM KORISNICKI UNOS...");
            Thread.Sleep(1000);
            Console.Clear();

            _mapa = new Mapa(odabirMape.Odaberi(new MapeRepozitorijum().SpisakMapa()));
            Console.WriteLine(_mapa);
            Thread.Sleep(1000);

            Console.WriteLine();

            Prodavnica _prodavnica = new Prodavnica(odabirProdavnice.Odaberi(new ProdavniceRepozitorijum().SpisakProdavnica()));
            Console.WriteLine(_prodavnica);
            Thread.Sleep(1000);
            _mapa._prodavnica = _prodavnica;

            int OnlineCount = IgraciRepozitorijum.BrojOnlineIgraca();
            Console.WriteLine("TRENUTAN BROJ ONLINE IGRACA: " + OnlineCount);
            Console.WriteLine();

            int brojIgracaPoTimu = -1;

            //ako je online manje igraca od maksimalnog broja igraca na mapi, vratice broj svih igraca koji su online kao maksimum (floor(n/2))
            int maksIgraca = OnlineCount < _mapa.MaksBrojIgraca ? OnlineCount / 2 : _mapa.MaksBrojIgraca / 2;

            do
            {
                try
                {
                    Console.WriteLine("Unesite broj igraca po timu (max " + maksIgraca + "): ");
                    brojIgracaPoTimu = Convert.ToInt32(Console.ReadLine());
                    if (brojIgracaPoTimu < 1 || brojIgracaPoTimu > maksIgraca)
                        Console.WriteLine("POGRESAN UNOS. UNESITE PONOVO.");
                    Thread.Sleep(200);
                    Console.WriteLine();
                }
                catch (Exception) { }
            } while (brojIgracaPoTimu < 1 || brojIgracaPoTimu > maksIgraca);

            Console.WriteLine();

            Console.Write("Unesite naziv plavog tima: "); //unos plavog tima
            string nazivPlavogTima = Console.ReadLine() ?? "";
            Console.WriteLine();

            Tim plaviTim = new Tim(odabirIgraca.Odaberi(brojIgracaPoTimu, new IgraciRepozitorijum().SpisakIgraca(), false), odabirHeroja.Odaberi(brojIgracaPoTimu, new HerojiRepozitorijum().spisakHeroja(), false), nazivPlavogTima);
            _mapa.PlaviTim = plaviTim;
            Console.WriteLine();

            Console.Write("Unesite naziv crvenog tima: "); //unos crvenog tima
            string nazivCrvenogTima = Console.ReadLine() ?? "";
            Console.WriteLine();

            Tim crveniTim = new Tim(odabirIgraca.Odaberi(brojIgracaPoTimu, new IgraciRepozitorijum().SpisakIgraca(), false), odabirHeroja.Odaberi(brojIgracaPoTimu, new HerojiRepozitorijum().spisakHeroja(), false), nazivCrvenogTima);
            _mapa.CrveniTim = crveniTim;

            Console.WriteLine();

            Console.WriteLine("Ubacivanje igraca u mapu...");
            _mapa.UkupanBrojIgracaTrenutno = 2 * brojIgracaPoTimu;
            Thread.Sleep(1500);
            Console.Clear();

            return _mapa;
        }
        public void ClearAll()
        {
            odabirHeroja.ClearList();
            odabirIgraca.ClearList();
        }
    }
}
