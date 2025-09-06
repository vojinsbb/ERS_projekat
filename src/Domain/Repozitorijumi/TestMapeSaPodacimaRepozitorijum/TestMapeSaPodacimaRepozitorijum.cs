using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Repozitorijumi.TestMapeRepozitorijum;
using Domain.Repozitorijumi.MapeRepozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repozitorijumi.ProdavniceRepozitorijum;

namespace Domain.Repozitorijumi.TestMapeSaPodacimaRepozitorijum
{
    public class TestMapeSaPodacimaRepozitorijum : ITestMapeSaPodacimaRepozitorijum
    {
        public static readonly List<Mapa> test_mape;

        static TestMapeSaPodacimaRepozitorijum()
        {   
            test_mape = new List<Mapa>();
            foreach (Mapa m in MapeRepozitorijum.MapeRepozitorijum.SpisakMapaTest())
            {
                Mapa mapa = new Mapa(m);
                Random r = new Random();
                mapa._prodavnica = ProdavniceRepozitorijum.ProdavniceRepozitorijum.SpisakProdavnicaTest().ElementAt(r.Next(0, 5));
                mapa.PlaviTim = new Tim(new int[] { r.Next(0, 4), r.Next(4, 8), r.Next(8, 12), r.Next(12, 15) }, new int[] { r.Next(0, 4), r.Next(4, 8), r.Next(8, 12), r.Next(12, 15) }, "plaviTim");
                mapa.CrveniTim = new Tim(new int[] { r.Next(0, 4), r.Next(4, 8), r.Next(8, 12), r.Next(12, 15) }, new int[] { r.Next(0, 4), r.Next(4, 8), r.Next(8, 12), r.Next(12, 15) }, "crveniTim");
                test_mape.Add(mapa);
            }
        }

        public List<Mapa> SpisakTestMapa() { return test_mape; }
        public static List<Mapa> StaticSpisakTestMapa() { return test_mape; }
    }
}
