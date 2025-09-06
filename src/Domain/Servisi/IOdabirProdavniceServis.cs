using Domain.Modeli;

namespace Domain.Servisi
{
    public interface IOdabirProdavniceServis
    {
        public Prodavnica Odaberi(List<Prodavnica> sve_prodavnice);
    }
}
