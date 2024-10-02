using System;
using System.Collections.Generic;

namespace Atividade._03
{
    public static class Atividade03
    {
        public static List<string> frutas = new List<string> { "Maçã", "Limão" };
        public static void atividade_03_menu()
        {
            
            // Adiciona ao final da lista
            frutas.Add("Uva");
            // Adiciona em uma posição
            frutas.Insert(1, "Laranja");

            Mostrarlista();
        }
        static void Mostrarlista()
        {
            for (int i = 0; i < frutas.Count; i++)
            {
                Console.WriteLine($"{i} - {frutas[i]}");
            }
        }
    }
}
