using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Alumno : Persona
    {
        private int IdAlumno { get; set; }
        private List<Credito> Creditos { get; set; }
        private List<Horario> Horarios { get; set; }
    }
}