using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public String Telefono { get; set; }
        public int Estado { get; set; }
        public String Rol { get; set; }
    }
}