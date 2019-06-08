using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Alumno : Persona
    {
        public int IdAlumno { get; set; }
        public List<Credito> Creditos { get; set; }
        public List<Horario> Horarios { get; set; }
    }
}