using Domain.Modeli;

namespace Domain.Servisi
{
    public interface IOdabirIgracaServis
    {
        public int[] Odaberi(int brojIgraca, List<Igrac> onlineIgraci, bool test);
        public void ClearList();
    }
}
