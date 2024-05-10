namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : Shape
    {
        private readonly decimal _lado;
        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }
        public override FormasEnum Tipo => FormasEnum.Cuadrado;

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }
    }
}
