using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public Actividad Actividad { get; set; }
        public Sucursal Sucursal { get; set; }
        public Profesor Profesor { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public TimeSpan HoraInicio { get; set; } // VERIFICAR TIPO DE DATO
        public TimeSpan HoraFin { get; set; } // VERIFICAR TIPO DE DATO
        public String Dia { get; set; }
    }
}