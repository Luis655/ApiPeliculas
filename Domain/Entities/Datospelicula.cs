using System;
using System.Collections.Generic;

namespace ApiLibros.Domain.Data
{
    public partial class Datospelicula
    {
        public int Idpelicula { get; set; }
        public string? Titulo { get; set; }
        public string? Director { get; set; }
        public string? Genero { get; set; }
        public double? Puntuacion { get; set; }
        public string? Rating { get; set; }
        public DateTime? Fechalanzamiento { get; set; }
    }
}
