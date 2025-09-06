namespace Domain.Servisi
{
    public interface IVremeServis
    {   
        public int Counter { get; set; }
        public void Vreme(int sekunde);
    }
}
