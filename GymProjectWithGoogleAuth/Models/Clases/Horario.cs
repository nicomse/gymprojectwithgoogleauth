using System;
using System.ComponentModel.DataAnnotations;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Horario
    {
        public int IdHorario { get; set; }

        public Actividad Actividad { get; set; }

        public Profesor Profesor { get; set; }

        public Sucursal Sucursal { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public TimeSpan HoraInicio { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public TimeSpan HoraFin { get; set; }

        public String Dia { get; set; }

        public int Estado { get; set; }
    }
}