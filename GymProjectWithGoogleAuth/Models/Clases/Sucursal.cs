using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Sucursal
    {
        private int NroSucursal { get; set; }
        private List<Pack> Packs { get; set; }
        private String Barrio { get; set; }
        private String Direccion { get; set; }
        private String Telefono { get; set; }
        private int Estado { get; set; }
    }
}