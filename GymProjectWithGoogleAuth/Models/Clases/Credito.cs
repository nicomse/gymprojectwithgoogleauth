using System;
using System.ComponentModel.DataAnnotations;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Credito
    {
        public int IdCredito { get; set; }

        public Alumno Alumno { get; set; }

        public Pack Pack { get; set; }

        public int Cantidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaExpiracion { get; set; }
    }
}