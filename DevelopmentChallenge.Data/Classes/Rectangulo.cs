using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : Shape
    {
        private readonly decimal _base;
        private readonly decimal _altura;
        public Rectangulo(decimal laBase, decimal altura)
        {
            _base = laBase;
            _altura = altura;
        }

        public override FormasEnum Tipo => FormasEnum.Rectangulo;

        public override decimal CalcularArea()
        {
            return Convert.ToDecimal(_base * _altura);
        }

        public override decimal CalcularPerimetro()
        {
            return Convert.ToDecimal(_base + _base + _altura + _altura);
        }
    }
}
