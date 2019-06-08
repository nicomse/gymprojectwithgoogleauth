using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public String Nombre { get; set; }
        public List<Horario> Horarios { get; set; }
        public int Estado { get; set; }
    }
}