using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymProject.Models.Clases
{
    public class Pack
    {
        private int IdPack { get; set; }
        private Sucursal Sucursal { get; set; }
        private int CantCreditos { get; set; }
        private int DiasVigencia { get; set; }
        private float Precio { get; set; }
    }
}