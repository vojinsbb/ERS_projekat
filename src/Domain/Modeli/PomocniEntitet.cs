namespace Domain.Modeli
{
    public class PomocniEntitet : Entitet
    {
        public PomocniEntitet(string nazivEntiteta) : base(nazivEntiteta, new Random().Next(1, 16), new Random().Next(20, 91)) { }
    }
}
