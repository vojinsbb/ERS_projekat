namespace Domain.Modeli
{
    public class Igrac
    {
        public string KorisnickoIme { get; set; } = string.Empty;
        public bool Online { get; set; } = false;

        public Igrac(string korisnickoIme, bool online)
        {
            KorisnickoIme = korisnickoIme;
            Online = online;
        }
    }
}
