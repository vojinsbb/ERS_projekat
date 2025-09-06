using Domain.Servisi;
using Services.MeniServisi;

namespace Presentation.PocetniMeniUI
{
    public class PocetniMeniUI : IPocetniMeniUI
    {
        public PocetniMeniUI() { }

        public int PrikaziPocetniMeni()
        {
            IMeniServis pocetniMeni = new PocetniMeniServis();

            return pocetniMeni.Meni();

        }
    }
}
