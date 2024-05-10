using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<Shape>(), FormaGeometrica.IdiomasEnum.Castellano));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<Shape>(), FormaGeometrica.IdiomasEnum.Ingles));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>L'elenco delle forme è vuoto!</h1>",
                FormaGeometrica.Imprimir(new List<Shape>(), FormaGeometrica.IdiomasEnum.Italiano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<Shape> { new Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.IdiomasEnum.Castellano);

            Assert.AreEqual("<h1>Reporte de formas</h1>1 Cuadrado | Area 25 | Perímetro 20 <br/>TOTAL:<br/>1 Forma Perímetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<Shape>
            {
                new Cuadrado (5),
                new Cuadrado (1),
                new Cuadrado (3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.IdiomasEnum.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 Shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<Shape>
            {
                new Cuadrado (5),
                new Circulo (3),
                new Triangulo (4),
                new Cuadrado (2),
                new Triangulo (9),
                new Circulo (2.75m),
                new Triangulo (4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.IdiomasEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 Shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<Shape>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(4),
                new Cuadrado(2),
                new Triangulo(9),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.IdiomasEnum.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de formas</h1>2 Cuadrados | Area 29 | Perímetro 28 <br/>2 Círculos | Area 13,01 | Perímetro 18,06 <br/>3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 Formas Perímetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<Shape>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Triangulo(4),
                new Cuadrado(2),
                new Triangulo(9),
                new Circulo(2.75m),
                new Triangulo(4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.IdiomasEnum.Italiano);

            Assert.AreEqual(
                "<h1>Rapporti sulla forma</h1>2 Quadrati | Area 29 | Rettangoli 28 <br/>2 cerchi | Area 13,01 | Rettangoli 18,06 <br/>3 triangoli | Area 49,64 | Rettangoli 51,6 <br/>TOTAL:<br/>7 Forme Rettangoli 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapeciosEnItaliano()
        {
            var formas = new List<Shape>
            {
                new Trapecio(1,4,3),
                new Trapecio(2,5,2),
                 new Trapecio(3,6,1)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.IdiomasEnum.Italiano);

            Assert.AreEqual(
                "<h1>Rapporti sulla forma</h1>3 Trapezi | Area 19 | Rettangoli 36,31 <br/>TOTAL:<br/>3 Forme Rettangoli 36,31 Area 19",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapeciosYRectangulos()
        {
            var formas = new List<Shape>
            {
                new Trapecio(1,4,3),
                new Trapecio(2,5,2),
                new Rectangulo(3,6),
                new Rectangulo(5,5),
                new Cuadrado(5)

            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.IdiomasEnum.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Trapezoids | Area 14,5 | Perimeter 23,71 <br/>2 Rectangles | Area 43 | Perimeter 38 <br/>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>5 Shapes Perimeter 81,71 Area 82,5",
                resumen);
        }
    }
}
