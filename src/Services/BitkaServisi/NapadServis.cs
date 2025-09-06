using Domain.Enumeracije;
using Domain.Modeli;
using Domain.Servisi;

namespace Services.BitkaServisi
{
    public class NapadServis : INapadServis
    {
        public IshodNapada Napad(Heroj napadac, Entitet defanzivac)
        {
            if (defanzivac is Heroj heroj_def)
            {
                if (napadac.JacinaNapada > heroj_def.JacinaNapada) return IshodNapada.USPESAN;

                if (napadac.JacinaNapada < heroj_def.JacinaNapada) return IshodNapada.NEUSPESAN;

                return IshodNapada.NERESENO;
            }

            defanzivac.ZivotniPoeni -= napadac.JacinaNapada;

            if (defanzivac.ZivotniPoeni <= 0)
            {
                napadac.KolicinaZlatnihNovcica += defanzivac.KolicinaZlatnihNovcica;
                return IshodNapada.USPESAN;
            }

            return IshodNapada.NEUSPESAN;

        }

    }
}
