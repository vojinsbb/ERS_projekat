using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Servisi;
using Services.VremenskiServisi;

namespace Services.BitkaServisi
{
    public class BitkaServis : IBitkaServis
    {
       
        private IVremeServis vreme;
        private INapadServis napadServis;
        private IKupovinaServis kupovina;


        public BitkaServis(IVremeServis vremeServis, INapadServis napadServis, IKupovinaServis kupovinaServis)
        {
            this.vreme = vremeServis;
            this.napadServis = napadServis;
            this.kupovina = kupovinaServis;
        }


        public bool Bitka(Mapa mapa)
        {
            int sekunde = new Random().Next(10, 46);
            Thread vremenskaNit = new(() => vreme.Vreme(sekunde));
            vremenskaNit.IsBackground = true;
            vremenskaNit.Start();
            List<Igrac_Heroj> poginuli = [];

            // provera da li je sve inicijalizovano
            if (mapa == null || mapa.PlaviTim == null || mapa.CrveniTim == null || mapa._prodavnica == null)
            {
                Console.WriteLine("GRESKA: PODACI NISU SPREMNI ZA POKRETANJE SIMULACIJE!");
                return false;
            }

            while (vreme.Counter < sekunde)
            {
                try
                {
                    int koNapada = new Random().Next(0, 2); // 0 - plavi tim; 1 - crveni tim
                    int kogaNapada = new Random().Next(2, 4); // 2 - drugog heroja; 3 - pomocni entitet

                    if (mapa.PlaviTim.herojiUTimu.Count == 0) //provera broja igraca u timovima
                    {
                        Console.WriteLine("\nTIM \"" + mapa.CrveniTim.NazivTima + "\" JE POBEDIO.");
                        break;
                    }
                    else if (mapa.CrveniTim.herojiUTimu.Count == 0)
                    {
                        Console.WriteLine("\nTIM \"" + mapa.PlaviTim.NazivTima + "\" JE POBEDIO.");
                        break;
                    }

                    Igrac_Heroj napadac = new Igrac_Heroj(); //izbor napadaca
                    napadac.idx = koNapada == 0 ? new Random().Next(0, mapa.PlaviTim.herojiUTimu.Count) : new Random().Next(0, mapa.PlaviTim.herojiUTimu.Count);

                    napadac.OdabranHeroj = koNapada == 0 ? mapa.PlaviTim.herojiUTimu.ElementAt(napadac.idx) : mapa.CrveniTim.herojiUTimu.ElementAt(napadac.idx);
                    napadac.Igrac = koNapada == 0 ? mapa.PlaviTim.igraciUTimu.ElementAt(napadac.idx) : mapa.CrveniTim.igraciUTimu.ElementAt(napadac.idx);
                    napadac.tim = Convert.ToBoolean(koNapada);

                    Predmet randomPredmetIzProdavnice = (new Random().Next(0, 2) == 1) ? mapa._prodavnica.MagicniNapitakList[new Random().Next(0, mapa._prodavnica.MagicniNapitakList.Count)] : mapa._prodavnica.OruzjeList[new Random().Next(0, mapa._prodavnica.OruzjeList.Count)];

                    if (kupovina.Kupi(napadac.OdabranHeroj, randomPredmetIzProdavnice))
                    {
                        Console.WriteLine("HEROJ " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv + " JE USPESNO KUPIO " + randomPredmetIzProdavnice.Naziv);
                        mapa._prodavnica.UkupnaVrednost += randomPredmetIzProdavnice.Cena;
                        Console.WriteLine();
                        Thread.Sleep(300);
                    }

                    if (kogaNapada == 2) //napad na protivnicki tim
                    {
                        Igrac_Heroj defanzivac = new Igrac_Heroj();

                        defanzivac.idx = koNapada == 0 ? new Random().Next(0, mapa.CrveniTim.herojiUTimu.Count) : new Random().Next(0, mapa.PlaviTim.herojiUTimu.Count);

                        defanzivac.OdabranHeroj = koNapada == 0 ? mapa.CrveniTim.herojiUTimu[defanzivac.idx] : mapa.PlaviTim.herojiUTimu[defanzivac.idx];

                        defanzivac.Igrac = koNapada == 0 ? mapa.CrveniTim.igraciUTimu[defanzivac.idx] : mapa.PlaviTim.igraciUTimu[defanzivac.idx];

                        defanzivac.tim = !Convert.ToBoolean(koNapada);

                        Console.WriteLine("HEROJ " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv + " (ATK " + napadac.OdabranHeroj.JacinaNapada + ") NAPADA " + defanzivac.Igrac.KorisnickoIme + "::" + defanzivac.OdabranHeroj.Naziv + " (ATK " + defanzivac.OdabranHeroj.JacinaNapada + ")");
                        Console.WriteLine();
                        Thread.Sleep(500);

                        IshodNapada ishod = napadServis.Napad(napadac.OdabranHeroj, defanzivac.OdabranHeroj);

                        if (ishod == IshodNapada.USPESAN) //ako je napadac pobedio
                        {
                            defanzivac.OdabranHeroj.ZivotniPoeni -= napadac.OdabranHeroj.JacinaNapada;
                            Console.WriteLine("NAPAD USPESAN!");
                            Console.WriteLine();

                            if (defanzivac.OdabranHeroj.ZivotniPoeni <= 0)
                            {
                                napadac.OdabranHeroj.KolicinaZlatnihNovcica += 300;
                                Console.WriteLine("HEROJ " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv + " JE ELIMINISAO PROTIVNIKA " + defanzivac.Igrac.KorisnickoIme + "::" + defanzivac.OdabranHeroj.Naziv);
                                Console.WriteLine("\tHEROJ " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv + " JE DOBIO 300 ZLATNIH NOVCICA");
                                Console.WriteLine();

                                if (koNapada == 0)
                                {
                                    poginuli.Add(new Igrac_Heroj(defanzivac));
                                    mapa.CrveniTim.herojiUTimu.Remove(defanzivac.OdabranHeroj);
                                    mapa.CrveniTim.igraciUTimu.Remove(defanzivac.Igrac);
                                }
                                else
                                {
                                    poginuli.Add(new Igrac_Heroj(defanzivac));
                                    mapa.PlaviTim.herojiUTimu.Remove(defanzivac.OdabranHeroj);
                                    mapa.PlaviTim.igraciUTimu.Remove(defanzivac.Igrac);
                                }
                            }
                            Thread.Sleep(400);
                        }
                        else if (ishod == IshodNapada.NEUSPESAN)
                        {
                            napadac.OdabranHeroj.ZivotniPoeni -= defanzivac.OdabranHeroj.JacinaNapada;
                            Console.WriteLine("NAPAD NEUSPESAN");
                            Console.WriteLine();

                            if (napadac.OdabranHeroj.ZivotniPoeni <= 0)
                            {
                                defanzivac.OdabranHeroj.KolicinaZlatnihNovcica += 300;
                                Console.WriteLine("DEFANZIVAC " + defanzivac.Igrac.KorisnickoIme + "::" + defanzivac.OdabranHeroj.Naziv + " JE ELIMINISAO PROTIVNIKA " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv);
                                Console.WriteLine("\tHEROJ " + defanzivac.Igrac.KorisnickoIme + "::" + defanzivac.OdabranHeroj.Naziv + " JE DOBIO 300 ZLATNIH NOVCICA");
                                Console.WriteLine();

                                if (koNapada == 0)
                                {
                                    poginuli.Add(new Igrac_Heroj(napadac));
                                    mapa.PlaviTim.herojiUTimu.Remove(napadac.OdabranHeroj);
                                    mapa.PlaviTim.igraciUTimu.Remove(napadac.Igrac);
                                }
                                else
                                {
                                    poginuli.Add(new Igrac_Heroj(napadac));
                                    mapa.CrveniTim.herojiUTimu.Remove(napadac.OdabranHeroj);
                                    mapa.CrveniTim.igraciUTimu.Remove(napadac.Igrac);
                                }
                            }
                            Thread.Sleep(400);
                        }
                        else
                        {
                            Console.WriteLine("HEROJ " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv + " IMA ISTO BODOVA ZA NAPAD KAO DEFANZIVAC " + defanzivac.Igrac.KorisnickoIme + "::" + defanzivac.OdabranHeroj.Naziv);
                            Console.WriteLine();
                            Thread.Sleep(400);
                        }
                    }
                    else if (kogaNapada == 3 && mapa.BrojPomocnihEntiteta > 0) //ako napada entiteta
                    {
                        PomocniEntitet pEntitet = new PomocniEntitet(("pomocniEntitet_" + new Random().Next(0, 25)));

                        Console.WriteLine("HEROJ " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv + " (ATK " + napadac.OdabranHeroj.JacinaNapada + ") NAPADA POMOCNI ENTITET " + pEntitet.Naziv);
                        Console.WriteLine();
                        Thread.Sleep(500);

                        if (napadServis.Napad(napadac.OdabranHeroj, pEntitet) == IshodNapada.USPESAN)
                        {
                            Console.WriteLine("HEROJ " + napadac.Igrac.KorisnickoIme + "::" + napadac.OdabranHeroj.Naziv + " JE ELIMINISAO POMOCNOG ENTITETA");
                            Console.WriteLine("\tHEROJ JE DOBIO " + pEntitet.KolicinaZlatnihNovcica + " ZLATNIH NOVCICA");
                            Thread.Sleep(200);
                            Console.WriteLine("NA MAPI JE OSTALO JOS " + --mapa.BrojPomocnihEntiteta + " POMOCNIH ENTITETA");
                            Console.WriteLine();
                            Thread.Sleep(400);
                        }
                    }
                }
                catch (Exception) { }
            }

            if (vreme.Counter >= sekunde)
            {
                Console.WriteLine();
                Console.WriteLine("=============================== VREME JE ISTEKLO ===============================");
                Thread.Sleep(300);

                if (mapa.PlaviTim.herojiUTimu.Count > mapa.CrveniTim.herojiUTimu.Count)
                    Console.WriteLine("TIM \"" + mapa.PlaviTim.NazivTima + "\" IMA VISE ZIVIH HEROJA TE JE ON POBEDNIK.");
                else if (mapa.PlaviTim.herojiUTimu.Count < mapa.CrveniTim.herojiUTimu.Count)
                    Console.WriteLine("TIM \"" + mapa.CrveniTim.NazivTima + "\" IMA VISE ZIVIH HEROJA TE JE ON POBEDNIK.");
                else
                    Console.WriteLine("\tOBA TIMA IMAJU ISTI BROJ PREZIVELIH TE JE REZULTAT NERESEN!");

                Console.WriteLine("================================================================================");
            }

            foreach (Igrac_Heroj ih in poginuli)  //vracanje poginulih u listu sa novim parametrima zarad statistike
            {
                if (ih == null || ih.Igrac == null || ih.OdabranHeroj == null)
                    continue; // provera da li je null

                if (!ih.tim) //ako je plavi tim
                {
                    mapa.PlaviTim.igraciUTimu.Add(ih.Igrac);
                    mapa.PlaviTim.herojiUTimu.Add(ih.OdabranHeroj);
                }
                else //u suprotnom je crveni
                {
                    mapa.CrveniTim.igraciUTimu.Add(ih.Igrac);
                    mapa.CrveniTim.herojiUTimu.Add(ih.OdabranHeroj);
                }
            }
            mapa.VremeTrajanjaBitke = vreme.Counter;
            return true;
        }
    }
}
