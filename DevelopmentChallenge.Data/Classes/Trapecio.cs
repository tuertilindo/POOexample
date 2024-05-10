using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : Shape
    {
        private readonly decimal _superior;
        private readonly decimal _inferior;
        private readonly decimal _altura;
        public Trapecio(decimal superior, decimal inferior, decimal altura)
        {
            _altura = altura;
            _superior = superior;
            _inferior = inferior;
        }

        public override FormasEnum Tipo => FormasEnum.Trapecio;

        public override decimal CalcularArea()
        {
            return Convert.ToDecimal((_superior + _inferior) * _altura) / 2;
        }

        public override decimal CalcularPerimetro()
        {
            var b = Math.Abs(_inferior - _superior) / 2;
            var lados = 2 * Pitagoras(_altura, b);
            return _inferior + _superior + Convert.ToDecimal(lados);
        }
    }
}
