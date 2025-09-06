using Domain.Modeli;

namespace Domain.Repozitorijumi.IgraciRepozitorijum
{
    public interface IIgraciRepozitorijum
    {
        public List<Igrac> SpisakIgraca();
        public static abstract int BrojOnlineIgraca();
    }
}
