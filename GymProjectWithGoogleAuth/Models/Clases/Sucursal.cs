using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GymProject.Models.Clases
{
    public class Sucursal
    {
        public int NroSucursal { get; set; }

        public List<Pack> Packs { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public String Barrio { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public String Direccion { get; set; }
       
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public String Telefono { get; set; }

        public int Estado { get; set; }
    }
}