using Domain.Modeli;
using Domain.Repozitorijumi.HerojiRepozitorijum;
using Domain.Repozitorijumi.IgraciRepozitorijum;
using Domain.Repozitorijumi.MapeRepozitorijum;
using Domain.Repozitorijumi.ProdavniceRepozitorijum;
using Domain.Servisi;
using Services.MeniServisi;

namespace Presentation.AutomatskiUnosUI
{
    public class AutomatskiUnosUI : IAutomatskiUnosUI
    {
        private IOdabirMapeServis odabirMape = new OdabirMapeMeniServis();
        private IOdabirHerojaServis odabirHeroja = new OdabirHerojaMeniServis();
        private IOdabirProdavniceServis odabirProdavnice = new OdabirProdavniceMeniServis();
        private IOdabirIgracaServis odabirIgraca = new OdabirIgracaMeniServis();
        public AutomatskiUnosUI() { }

        public Mapa PokreniAutomatskiUnos()
        {
            Mapa _mapa = new Mapa();
            IOdabirMapeServis odabirMape = new OdabirMapeMeniServis();
            IOdabirHerojaServis odabirHeroja = new OdabirHerojaMeniServis();
            IOdabirProdavniceServis odabirProdavnice = new OdabirProdavniceMeniServis();
            IOdabirIgracaServis odabirIgraca = new OdabirIgracaMeniServis();

            Console.Clear();
            Console.WriteLine("POKRECEM AUTOMATSKI UNOS PODATAKA...");
            Thread.Sleep(2000);
            Console.Clear();

            _mapa = new Mapa(new MapeRepozitorijum().SpisakMapa().ElementAt(new Random().Next(0, new MapeRepozitorijum().SpisakMapa().Count())));
            Console.WriteLine(_mapa);
            Thread.Sleep(3000);
            Console.WriteLine();

            Prodavnica _prodavnicaTest = new ProdavniceRepozitorijum().SpisakProdavnica().ElementAt(new Random().Next(0, new ProdavniceRepozitorijum().SpisakProdavnica().Count()));
            Console.WriteLine(_prodavnicaTest);
            _mapa._prodavnica = _prodavnicaTest;
            Console.WriteLine();
            Console.Write("NASTAVI...");
            Console.ReadLine();

            int OnlineCount = IgraciRepozitorijum.BrojOnlineIgraca();
            Console.WriteLine("TRENUTAN BROJ ONLINE IGRACA: " + OnlineCount);
            Console.WriteLine();

            //ako je online manje igraca od maksimalnog broja igraca, vratice broj svih igraca koji su dostupni kao maksimum (floor(n/2))
            int maksIgraca = OnlineCount < _mapa.MaksBrojIgraca ? OnlineCount / 2 : _mapa.MaksBrojIgraca / 2;

            Console.Write("Unesite broj igraca po timu (max " + maksIgraca + "): ");
            Thread.Sleep(300);
            int brojIgracaPoTimu = new Random().Next(1, maksIgraca + 1);
            Console.WriteLine(brojIgracaPoTimu);
            Thread.Sleep(1000);
            Console.WriteLine();

            Console.Write("Unesite naziv plavog tima: "); //automatski unos plavog tima
            Thread.Sleep(300);
            Console.WriteLine("plaviTimTest");
            Thread.Sleep(1000);
            string nazivPlavogTima = "plaviTimTest";
            Console.WriteLine();

            Tim plaviTim = new Tim(odabirIgraca.Odaberi(brojIgracaPoTimu, new IgraciRepozitorijum().SpisakIgraca(), true), odabirHeroja.Odaberi(brojIgracaPoTimu, new HerojiRepozitorijum().spisakHeroja(), true), nazivPlavogTima);

            _mapa.PlaviTim = plaviTim;
            Console.WriteLine();

            Console.Write("Unesite naziv crvenog tima: "); //automatski unos crvenog tima
            Thread.Sleep(300);
            Console.WriteLine("crveniTimTest");
            Thread.Sleep(1000);
            string nazivCrvenogTima = "crveniTimTest";
            Console.WriteLine();

            Tim crveniTim = new Tim(odabirIgraca.Odaberi(brojIgracaPoTimu, new IgraciRepozitorijum().SpisakIgraca(), true), odabirHeroja.Odaberi(brojIgracaPoTimu, new HerojiRepozitorijum().spisakHeroja(), true), nazivCrvenogTima);

            _mapa.CrveniTim = crveniTim;

            _mapa.UkupanBrojIgracaTrenutno = 2 * brojIgracaPoTimu;

            Console.WriteLine("Ubacivanje igraca u mapu...");
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
