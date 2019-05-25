using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Actividad
    {
        private int IdActividad { get; set; }
        private String Nombre { get; set; }
        private List<Horario> Horarios { get; set; }
        private int Estado { get; set; }
    }
}