using System;
using System.Collections.Generic;

namespace Atividade._03
{
    public static class Atividade03
    {
        public static void atividade_03_menu()
        {
            List<string> frutas = new List<string> { "Ma��", "Lim�o"};
            // Adiciona ao final da lista
            frutas.Add("Uva");
            // Adiciona em uma posi��o
            frutas.Insert(1, "Laranja");

            for (int i = 0; i < frutas.Count; i++)
            {
                Console.WriteLine($"{i} - {frutas[i]}");
            }
        }
    }
}
