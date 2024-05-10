using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Triangulo : Shape
    {
        private readonly decimal _base;
        private readonly decimal _altura;
        public Triangulo(decimal laBase, decimal altura)
        {
            _base = laBase;
            _altura = altura;
        }
        public Triangulo(decimal lado)
        {
            _base = lado;
            _altura = (lado * Convert.ToDecimal(Math.Sqrt(3))) / 2;
        }

        public override FormasEnum Tipo => FormasEnum.Triangulo;

        public override decimal CalcularArea()
        {
            return Convert.ToDecimal(_base * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            return Convert.ToDecimal(Convert.ToDouble(_base) + (2 * Pitagoras(_base / 2, _altura)));
        }
    }
}
