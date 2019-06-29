using GymProjectWithGoogleAuth.Models.BaseDeDatos;
using GymProjectWithGoogleAuth.Models.Clases;
using System;

namespace GymProjectWithGoogleAuth.Models.Middleware
{
    public static class Middleware
    {
        public static bool PuedePasar(String email)
        {
            Database db = new Database();
            bool puedePasar = false;

            try
            {
                Persona persona = db.getPersonaPorEmail(email);

                if (persona != null)
                {
                    puedePasar = true;
                }

                return puedePasar;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool TienePermiso(Persona persona, String permisoRequeridoParaPasar)
        {
            Database db = new Database();
            bool tienePermiso = db.tienePermisoBuscado(persona, permisoRequeridoParaPasar);

            if (tienePermiso)
            {
                return true;
            }

            return false;
        }
    }
}