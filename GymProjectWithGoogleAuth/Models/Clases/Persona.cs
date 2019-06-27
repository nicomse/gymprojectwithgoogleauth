﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Persona
    {
        public int IdPersona { get; set; }

        [RegularExpression(@"^[A-ZñÑáéíóúÁÉÍÓÚ]+[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El nombre ingresado no es válido.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(100)]
        public String Nombre { get; set; }

        [RegularExpression(@"^[A-ZñÑáéíóúÁÉÍÓÚ]+[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "El apellido ingresado no es válido.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(100)]
        public String Apellido { get; set; }

        [EmailAddress(ErrorMessage = "El E-Mail ingresado no es válido.")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(255)]
        public String Email { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(255)]
        public String Telefono { get; set; }
        public int Estado { get; set; }
    }
}