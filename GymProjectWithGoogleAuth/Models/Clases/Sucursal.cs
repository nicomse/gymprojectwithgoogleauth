using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Sucursal
    {
        public int NroSucursal { get; set; }

        public List<Pack> Packs { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(100)]
        public String Barrio { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(100)]
        public String Direccion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [StringLength(255)]
        public String Telefono { get; set; }

        public int Estado { get; set; }
    }
}