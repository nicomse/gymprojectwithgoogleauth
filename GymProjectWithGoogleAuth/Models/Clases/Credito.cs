using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Credito
    {
        public int IdCredito { get; set; }
        public Alumno Alumno { get; set; }
        public Pack Pack { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCompra { get; set; } // VERIFICAR TIPO DE DATO
        public DateTime FechaExpiracion { get; set; } // VERIFICAR TIPO DE DATO
    }
}