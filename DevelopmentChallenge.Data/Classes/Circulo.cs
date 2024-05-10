using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : Shape
    {
        private readonly decimal _radio;
        public Circulo(decimal diametro)
        {
            _radio = diametro / 2;
        }

        public override FormasEnum Tipo => FormasEnum.Circulo;

        public override decimal CalcularArea()
        {
            return Convert.ToDecimal(Math.PI * Math.Pow(Convert.ToDouble(_radio), 2));
        }

        public override decimal CalcularPerimetro()
        {
            return Convert.ToDecimal(Math.PI * Convert.ToDouble(_radio * 2));
        }
    }
}
