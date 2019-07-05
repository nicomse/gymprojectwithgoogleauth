using System;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Credito
    {
        public int IdCredito { get; set; }

        public Alumno Alumno { get; set; }

        public Pack Pack { get; set; }

        public int Cantidad { get; set; }

        public DateTime FechaCompra { get; set; }

        public DateTime FechaExpiracion { get; set; }
    }
}