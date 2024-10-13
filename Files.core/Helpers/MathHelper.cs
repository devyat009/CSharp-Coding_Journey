using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpJourney.core.Helpers
{
    public static class MathHelper
    {
        public static double Soma(double x, double y)
        {
            return x + y;
        }
        public static double Subtracao(double x, double y)
        {
            return x - y;
        }
        public static double Divisao(double x, double y)
        {
            return x / y;
        }
        public static double Multiplicacao(double x, double y)
        {
            return x * y;
        }
        /// <summary>
        /// Calcula a potência de um número.
        /// </summary>
        /// <param name="x">O primeiro número.</param>
        /// <param name="y">O segundo número</param>
        /// <returns>A potência de x por y.</returns>
        public static double Potencia(double x, double y)
        {
            return Math.Pow(x, y);
        }
        public static List<string> Tabuada(double x)
        {
            List<string> list = new List<string>();
            for (int i = 0; i <= 10; i++)
            {
                string result = $"{x} X {i} = {x * i}";
                list.Add(result);
            }
            return list;
        }
    }
}
