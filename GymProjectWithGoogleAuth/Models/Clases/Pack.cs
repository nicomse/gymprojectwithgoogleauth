using System.ComponentModel.DataAnnotations;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Pack
    {
        public int IdPack { get; set; }

        public Sucursal Sucursal { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int CantCreditos { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int DiasVigencia { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public double Precio { get; set; }

        public int Estado { get; set; }
    }
}