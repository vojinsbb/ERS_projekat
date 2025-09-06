using Domain.Modeli;

namespace Domain.Repozitorijumi.IgraciRepozitorijum
{
    public class IgraciRepozitorijum : IIgraciRepozitorijum
    {
        private static readonly List<Igrac> svi_igraci;

        static IgraciRepozitorijum()
        {
            svi_igraci = new List<Igrac>
            { 
                //igraci su random online osim dimitrija i vojina (glavni korisnici), tako da uvek bude minimum dva igraca
                new Igrac("dimitrije", true),
                new Igrac("vojin",  true),
                new Igrac("goran",  Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("ksenija",  Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("maja",  Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("knez", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("labrnja", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("lazar", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("teodora", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("jelena", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("marko", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("pera", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("mika", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("zika", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("jova", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("dule", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("martin", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("milica", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("jovana", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("perica", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("jovica", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("mujo", Convert.ToBoolean(new Random().Next(0,2))),
                new Igrac("haso", Convert.ToBoolean(new Random().Next(0,2))),
            };
        }

        public List<Igrac> SpisakIgraca() { return svi_igraci; }
        public static List<Igrac> SpisakIgracaTest() { return svi_igraci; }

        public static int BrojOnlineIgraca()
        {
            int count = 0;
            foreach (Igrac i in svi_igraci)
                if (i.Online)
                    count++;

            return count;
        }
    }
}
