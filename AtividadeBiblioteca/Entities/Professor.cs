﻿using System.Globalization;

namespace SistemaBiblioteca.Entities
{
    public class Professor : Usuario
    {
        public string Departamento { get; set; }
        public string Discriminator { get; set; } = "PROFESSOR";
    }
}
