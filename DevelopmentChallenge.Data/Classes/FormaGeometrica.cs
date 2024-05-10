/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public static class FormaGeometrica
    {
        public enum IdiomasEnum
        {
            Castellano,
            Ingles,
            Italiano
        }
        private static ResXResourceSet recursosDeIdioma(IdiomasEnum idioma)
        {
            var lang = "es";
            switch (idioma)
            {
                case IdiomasEnum.Italiano:
                    lang = "it";
                    break;
                case IdiomasEnum.Ingles:
                    lang = "en";
                    break;
                default:
                    break;

            }
            return new ResXResourceSet(@"./Dictionaries/" + lang + ".resx");
        }

        public static string Imprimir(List<Shape> formas, IdiomasEnum idioma)
        {
            var sb = new StringBuilder();
            using (var dic = recursosDeIdioma(idioma))
            {
                if (!formas.Any())
                {
                    sb.Append($"<h1>{dic.GetString("emptyList")}</h1>");
                }
                else
                {
                    // Hay por lo menos una forma
                    // HEADER
                    sb.Append($"<h1>{dic.GetString("shapesReport")}</h1>");


                    var reports = new Hashtable();

                    // Llenamos los reportes 
                    for (var i = 0; i < formas.Count; i++)
                    {
                        var shape = formas[i];
                        if (!reports.ContainsKey(shape.Tipo))
                            reports.Add(shape.Tipo, new Report() { Tipo = shape.Tipo });

                        var report = reports[shape.Tipo] as Report;
                        report.Perimetro += shape.CalcularPerimetro();
                        report.Area += shape.CalcularArea();
                        report.Count++;
                    }
                    var total = new Report();

                    //Las tablas de hash estan desordenadas asi que la ordenamos con el criterio de entrada
                    var list = new List<Report>();
                    foreach (var shape in formas)
                    {
                        if (reports.ContainsKey(shape.Tipo))
                        {
                            list.Add(reports[shape.Tipo] as Report);
                            reports.Remove(shape.Tipo);
                        }
                    }

                    // Renderizamos
                    foreach (Report report in list)
                    {
                        total.Area += report.Area;
                        total.Count += report.Count;
                        total.Perimetro += report.Perimetro;
                        sb.Append($"{report.Count} {dic.GetString(report.Tipo.ToString() + (report.Count > 1 ? "Pluralized" : ""))} | {dic.GetString("area")} {report.Area.ToString("#.##").Replace(".", ",")} | {dic.GetString("perimeter")} {report.Perimetro.ToString("#.##").Replace(".", ",")} <br/>");
                    }

                    // FOOTER
                    sb.Append("TOTAL:<br/>");
                    sb.Append(total.Count + " " + dic.GetString("shape" + (total.Count > 1 ? "Pluralized" : "")) + " ");
                    sb.Append(dic.GetString("perimeter") + " " + total.Perimetro.ToString("#.##").Replace(".", ",") + " ");
                    sb.Append(dic.GetString("area") + " " + total.Area.ToString("#.##").Replace(".", ","));
                }
            }


            return sb.ToString();
        }

    }
}
