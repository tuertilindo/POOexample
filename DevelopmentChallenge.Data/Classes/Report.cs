namespace DevelopmentChallenge.Data.Classes
{
    public class Report
    {
        public int Count { get; set; } = 0;
        public decimal Area { get; set; } = 0;
        public decimal Perimetro { get; set; } = 0;
        public Shape.FormasEnum Tipo { get; set; }
    }
}
