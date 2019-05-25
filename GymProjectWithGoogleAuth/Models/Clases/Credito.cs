using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Credito
    {
        private int IdCredito { get; set; }
        private Alumno Alumno { get; set; }
        private Pack Pack { get; set; }
        private int Cantidad { get; set; }
        private DateTime FechaCompra { get; set; } // VERIFICAR TIPO DE DATO
        private DateTime FechaExpiracion { get; set; } // VERIFICAR TIPO DE DATO
    }
}