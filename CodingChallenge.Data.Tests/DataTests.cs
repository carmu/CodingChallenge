using CodingChallenge.Data.Interfaces;
using CodingChallenge.Data.Formas;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        [SetCulture("es-AR")]
        [SetUICulture("es-AR")]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Reporte.Imprimir(new IFormaGeometrica[] { }));
        }

        [TestCase]
        [SetCulture("en-US")]
        [SetUICulture("en-US")]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Reporte.Imprimir(new IFormaGeometrica[] { }));
        }

        [TestCase]
        [SetCulture("es-AR")]
        [SetUICulture("es-AR")]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new IFormaGeometrica[] { new Cuadrado(5) };

            var resumen = Reporte.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        [SetCulture("en-US")]
        [SetUICulture("en-US")]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new IFormaGeometrica[]
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = Reporte.Imprimir(cuadrados);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        [SetCulture("en-US")]
        [SetUICulture("en-US")]
        public void TestResumenListaConMasTipos()
        {
            var formas = new IFormaGeometrica[]
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = Reporte.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        [SetCulture("es-AR")]
        [SetUICulture("es-AR")]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new IFormaGeometrica[]
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

            var resumen = Reporte.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
        /// <summary>
        /// Nuevos tests
        /// </summary>
        
            
        [TestCase]
        [SetCulture("fr-FR")]
        [SetUICulture("fr-FR")]
        public void TestResumenListaVaciaFormasEnFrances()
        {
            Assert.AreEqual("<h1>Liste vide de formes!</h1>",
                Reporte.Imprimir(new IFormaGeometrica[] { }));
        }

        [TestCase]
        [SetCulture("fr-FR")]
        [SetUICulture("fr-FR")]
        public void TestResumenListaConFormasEnFrances()
        {
            var formas = new IFormaGeometrica[]
            {
                new TrapecioRectangulo(5, 4, 3, 10.16m),
                new Cuadrado(4)
            };

            var resumen = Reporte.Imprimir(formas);

            Assert.AreEqual(
                "<h1>Rapport de formes</h1>1 Trapèze | Superficie 13,5 | Périmètre 22,16 <br/>1 Carré | Superficie 16 | Périmètre 16 <br/>TOTAL:<br/>2 Manières Périmètre 38,16 Superficie 29,5",
                resumen);
        }
    }
}
