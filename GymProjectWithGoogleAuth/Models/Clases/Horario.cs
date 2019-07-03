using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Horario
    {
        public int IdHorario { get; set; }

        public Actividad Actividad { get; set; }

        public Profesor Profesor { get; set; }

        public Sucursal Sucursal { get; set; }

        public List<Alumno> Alumnos { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime HoraInicio { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public DateTime HoraFin { get; set; }

        public String Dia { get; set; }

        public int Estado { get; set; }
    }
}