using Domain.Modeli;

namespace Domain.Servisi
{
    public interface IOdabirHerojaServis
    {
        public int[] Odaberi(int brojHeroja, List<Heroj> ponudjeniHeroji, bool test);

        public void ClearList();
    }
}
