using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Pack
    {
        public int IdPack { get; set; }
        public Sucursal Sucursal { get; set; }
        public int CantCreditos { get; set; }
        public int DiasVigencia { get; set; }
        public float Precio { get; set; }
    }
}