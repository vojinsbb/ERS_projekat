using Domain.Enumeracije;
using Domain.Modeli;

namespace Domain.Servisi
{
    public interface INapadServis
    {
        public IshodNapada Napad(Heroj napadac, Entitet defanzivac);
    }
}
