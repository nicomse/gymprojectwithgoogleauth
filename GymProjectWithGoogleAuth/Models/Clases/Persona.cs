using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Persona
    {
        private int IdPersona { get; set; }
        private String Nombre { get; set; }
        private String Apellido { get; set; }
        private String Email { get; set; }
        private String Telefono { get; set; }
        private int Estado { get; set; }
        private String Rol { get; set; }
    }
}