using Domain.Enumeracije;
using System.Text;

namespace Domain.Modeli
{
    public class Mapa
    {

        public string NazivMape { get; set; } = String.Empty;
        public TipMape TipMape { get; set; }
        public Prodavnica? _prodavnica { get; set; }
        public int MaksBrojIgraca { get; set; } = 0;
        public int UkupanBrojIgracaTrenutno { get; set; } = 0;
        public Tim? PlaviTim { get; set; }
        public Tim? CrveniTim { get; set; }
        public int BrojPomocnihEntiteta { get; set; } = 0;
        public int VremeTrajanjaBitke { get; set; } = 0;

        public Mapa()
        {

        }
        public Mapa(string nazivMape, TipMape tipMape, int maksBrojIgraca, int brojPomocnihEntiteta)
        {
            NazivMape = nazivMape;
            TipMape = tipMape;
            MaksBrojIgraca = maksBrojIgraca;
            BrojPomocnihEntiteta = brojPomocnihEntiteta;
        }

        public Mapa(Mapa _mapa)
        {
            NazivMape = _mapa.NazivMape;
            TipMape = _mapa.TipMape;
            MaksBrojIgraca = _mapa.MaksBrojIgraca;
            BrojPomocnihEntiteta = _mapa.BrojPomocnihEntiteta;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append("PODACI O MAPI: \n");
            sb.Append("\tNAZIV MAPE: " + NazivMape + "\n");
            sb.Append("\tTIP MAPE: " + TipMape + "\n");
            sb.Append("\tMAKSIMALAN BROJ IGRACA NA MAPI: " + MaksBrojIgraca + "\n");
            sb.Append("\tTRENUTAN BROJ IGRACA NA MAPI: " + UkupanBrojIgracaTrenutno + "\n");
            sb.Append("\tBROJ POMOCNIH ENTITETA NA MAPI: " + BrojPomocnihEntiteta + "\n");


            if (PlaviTim != null && CrveniTim != null && _prodavnica != null)
            {
                if (PlaviTim.NazivTima != String.Empty && CrveniTim.NazivTima != String.Empty)
                {
                    sb.Append("\tID PRODAVNICE NA MAPI: " + _prodavnica?.IDProdavnice + " " + _prodavnica?.NazivProdavnice + "\n");
                    sb.Append("\tNAZIV PLAVOG TIMA: " + PlaviTim.NazivTima + "\n");
                    sb.Append("\tNAZIV CRVENOG TIMA: " + CrveniTim.NazivTima + "\n");
                }
            }


            return sb.ToString();
        }

    }
}