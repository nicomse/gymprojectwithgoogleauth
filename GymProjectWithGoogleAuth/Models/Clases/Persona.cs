using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Persona
    {
        public int IdPersona { get; set; }

        [RegularExpression(@"^[A-ZñÑáéíóúÁÉÍÓÚ]+[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Nombre no válido")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100)]
        public String Nombre { get; set; }

        [RegularExpression(@"^[A-ZñÑáéíóúÁÉÍÓÚ]+[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Apellido no válido")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [StringLength(100)]
        public String Apellido { get; set; }

        [EmailAddress(ErrorMessage = "E-mail no válido")]
        [StringLength(255)]
        public String Email { get; set; }

        [StringLength(255)]
        public String Telefono { get; set; }
        public int Estado { get; set; }
        public String Rol { get; set; }
    }
}