using System.Collections.Generic;

namespace GymProjectWithGoogleAuth.Models.Clases
{
    public class Alumno : Persona
    {
        public int IdAlumno { get; set; }

        public List<Credito> Creditos { get; set; }

        public List<Horario> Horarios { get; set; }
    }
}