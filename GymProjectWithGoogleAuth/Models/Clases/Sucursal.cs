using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Sucursal
    {
        public int NroSucursal { get; set; }
        public List<Pack> Packs { get; set; }
        public String Barrio { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public int Estado { get; set; }
    }
}