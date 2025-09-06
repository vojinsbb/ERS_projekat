using System.Text;


namespace Domain.Modeli
{
    public class Prodavnica
    {
        public int IDProdavnice { get; set; } = 0;
        public string NazivProdavnice { get; set; } = String.Empty;
        public List<Predmet> OruzjeList { get; set; } = new List<Predmet>();
        public List<Predmet> MagicniNapitakList { get; set; } = new List<Predmet>();
        public int UkupnaVrednost { get; set; } = 0;

        public Prodavnica(int iDProdavnice, string nazivProdavnice, List<Predmet> oruzjeList, List<Predmet> magicniNapitakList, int ukupnaVrednost)
        {
            IDProdavnice = iDProdavnice;
            NazivProdavnice = nazivProdavnice;
            OruzjeList = oruzjeList;
            MagicniNapitakList = magicniNapitakList;
            UkupnaVrednost = ukupnaVrednost;
        }

        public Prodavnica()
        {

        }

        public Prodavnica(Prodavnica p)
        {
            IDProdavnice = p.IDProdavnice;
            NazivProdavnice = p.NazivProdavnice;
            OruzjeList = p.OruzjeList;
            MagicniNapitakList = p.MagicniNapitakList;
            UkupnaVrednost = p.UkupnaVrednost;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("PODACI O PRODAVNICI: \n");
            sb.Append("\tID PRODAVNICE: " + IDProdavnice + "\n");
            sb.Append("\tNAZIV PRODAVNICE: " + NazivProdavnice + "\n");
            sb.Append("\tUKUPNA VREDNOST: " + UkupnaVrednost + "\n");
            sb.Append("\tORUZJA U PRODAVNICI:\n");

            foreach (Oruzje o in OruzjeList)
            {
                sb.Append("\t\t" + o.ToString() + "\n");
            }

            sb.Append("\tNAPICI U PRODAVNICI:\n");

            foreach (MagicniNapitak m in MagicniNapitakList)
            {
                sb.Append("\t\t" + m.ToString() + "\n");
            }

            return sb.ToString();

        }
    }
}

