using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Actividad
    {
        public int IdActividad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(100)]
        public String Nombre { get; set; }

        public int Estado { get; set; }
    }
}