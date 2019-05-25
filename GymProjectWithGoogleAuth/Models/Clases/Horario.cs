using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Horario
    {
        private int IdHorario { get; set; }
        private Actividad Actividad { get; set; }
        private Sucursal Sucursal { get; set; }
        private Profesor Profesor { get; set; }
        private List<Alumno> Alumnos { get; set; }
        private TimeSpan HoraInicio { get; set; } // VERIFICAR TIPO DE DATO
        private TimeSpan HoraFin { get; set; } // VERIFICAR TIPO DE DATO
        private String Dia { get; set; }
    }
}