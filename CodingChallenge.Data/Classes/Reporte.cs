/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace CodingChallenge.Data.Interfaces
{
    public class Reporte
    {
        public static string Imprimir(IFormaGeometrica[] formas)
        {
            var sb = new StringBuilder();

            //Manager para acceder a los recursos
            ResourceManager resourceManager = new ResourceManager("CodingChallenge.Data.Lang.FormasText", Assembly.GetExecutingAssembly());

            #region Header
            if (!formas.Any())
            {
                sb.Append($"<h1>{resourceManager.GetString("TitleEmpty")}</h1>");
                return sb.ToString();
            }

            sb.Append($"<h1>{resourceManager.GetString("Title")}</h1>");
            #endregion

            #region Body
            var tiposFormasIngresadas = formas.GroupBy(s => s.GetType()).Select(x => x.Key);

            //Se almacenan los datos de cada tipo de forma
            var datosFormaEspecifica = new List<DatosFormaReporte>();

            foreach (var tipoForma in tiposFormasIngresadas)
            {
                datosFormaEspecifica.Add(new DatosFormaReporte
                {
                    TipoForma = tipoForma,
                    Cantidad = formas.Where(x => x.GetType().Equals(tipoForma)).Count(),
                    AreaTotal = formas.Where(x => x.GetType().Equals(tipoForma)).Sum(s => s.CalcularArea()),
                    PerimetroTotal = formas.Where(x => x.GetType().Equals(tipoForma)).Sum(s => s.CalcularPerimetro())
                });

                sb.Append(ObtenerLinea(datosFormaEspecifica.LastOrDefault(), resourceManager));
            }

            #endregion

            #region Footer
            var areasTotal = datosFormaEspecifica.Sum(x => x.AreaTotal).ToString("#.##");
            var perimetrosTotal = datosFormaEspecifica.Sum(x => x.PerimetroTotal).ToString("#.##");

            sb.Append("TOTAL:<br/>");
            sb.Append($"{datosFormaEspecifica.Sum(x => x.Cantidad)} {resourceManager.GetString("Shapes")} ");
            sb.Append($"{resourceManager.GetString("Perimeter")} {perimetrosTotal} ");
            sb.Append($"{resourceManager.GetString("Area")} {areasTotal}");
            #endregion

            return sb.ToString();
        }

        private static string ObtenerLinea(DatosFormaReporte datos, ResourceManager rm)
        {
            if (datos.Cantidad > 0)
            {
                var areasTotal = datos.AreaTotal.ToString("#.##");
                var perimetrosTotal = datos.PerimetroTotal.ToString("#.##");
                var nombreForma = datos.Cantidad == 1 ? rm.GetString("SingleName" + datos.TipoForma.Name) : rm.GetString("PluralName" + datos.TipoForma.Name);

                return $"{datos.Cantidad} {nombreForma} | {rm.GetString("Area")} {areasTotal} | {rm.GetString("Perimeter")} {perimetrosTotal} <br/>";
            }

            return string.Empty;
        }

        private class DatosFormaReporte
        {
            public Type TipoForma { get; set; }
            public int Cantidad { get; set; }
            public decimal AreaTotal { get; set; }
            public decimal PerimetroTotal { get; set; }
        }

    }
}
