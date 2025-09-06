using Domain.Modeli;
using Domain.Servisi;
using System.Text;

namespace Services.StatistikaServisi
{
    public class PripremaStatistikeServis : IPripremaStatistikeServis
    {
        public string PripremaStatistike(Mapa mapa)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("================================== STATISTIKA BITKE ==================================\n");
            sb.Append("\n");
            sb.Append("\tNAZIV MAPE: " + mapa.NazivMape + "\n");
            sb.Append("\tNAZIV PRODAVNICE: " + mapa?._prodavnica?.NazivProdavnice + "\n");
            sb.Append("\t\tUKUPNA VREDNOST PRODATIH ARTIKALA: " + mapa?._prodavnica?.UkupnaVrednost + "\n");
            sb.Append("\tVREME TRAJANJA BITKE: " + mapa?.VremeTrajanjaBitke + "s\n");

            sb.Append("\n");

            sb.Append("INFORMACIJE O TIMU \"" + mapa?.PlaviTim?.NazivTima + "\" :\n");
            sb.Append("\n");
            sb.Append("      IGRAC       |      HEROJ       |  ZIVOTNI POENI  |  JACINA NAPADA  |   NOVCICI  \n");
            sb.Append("--------------------------------------------------------------------------------------\n");

            for (int i = 0; i < mapa?.PlaviTim?.herojiUTimu.Count; i++)
            {

                sb.AppendFormat("{0,18}|{1,18}|{2,17}|{3,17}|{4,12}\n", mapa.PlaviTim.igraciUTimu[i].KorisnickoIme,
                                                                 mapa.PlaviTim.herojiUTimu[i].Naziv,
                                                                 mapa.PlaviTim.herojiUTimu[i].ZivotniPoeni,
                                                                 mapa.PlaviTim.herojiUTimu[i].JacinaNapada,
                                                                 mapa.PlaviTim.herojiUTimu[i].KolicinaZlatnihNovcica);
                if (i + 1 != mapa.PlaviTim.herojiUTimu.Count)
                    sb.Append("--------------------------------------------------------------------------------------\n");

            }

            sb.Append("\n");
            sb.Append("\n");

            sb.Append("INFORMACIJE O TIMU \"" + mapa?.CrveniTim?.NazivTima + "\" :\n");
            sb.Append("\n");
            sb.Append("      IGRAC       |      HEROJ       |  ZIVOTNI POENI  |  JACINA NAPADA  |   NOVCICI  \n");
            sb.Append("--------------------------------------------------------------------------------------\n");

            for (int i = 0; i < mapa?.CrveniTim?.herojiUTimu.Count; i++)
            {

                sb.AppendFormat("{0,18}|{1,18}|{2,17}|{3,17}|{4,12}\n", mapa.CrveniTim.igraciUTimu[i].KorisnickoIme,
                                                                 mapa.CrveniTim.herojiUTimu[i].Naziv,
                                                                 mapa.CrveniTim.herojiUTimu[i].ZivotniPoeni,
                                                                 mapa.CrveniTim.herojiUTimu[i].JacinaNapada,
                                                                 mapa.CrveniTim.herojiUTimu[i].KolicinaZlatnihNovcica);
                if (i + 1 != mapa.CrveniTim.herojiUTimu.Count)
                    sb.Append("--------------------------------------------------------------------------------------\n");


            }
            sb.Append("\n");
            sb.Append("=======================================================================================\n");

            return sb.ToString();
        }
    }
}
