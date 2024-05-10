using System;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class Shape
    {
        public enum FormasEnum
        {
            Cuadrado,
            Triangulo,
            Circulo,
            Trapecio,
            Rectangulo
        }
        public abstract FormasEnum Tipo { get; }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();

        protected double Pitagoras(decimal ladoA, decimal ladoB)
        {
            return Math.Sqrt(Math.Pow(Convert.ToDouble(ladoA), 2) + Math.Pow(Convert.ToDouble(ladoB), 2));
        }

    }
}
