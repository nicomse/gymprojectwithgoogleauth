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
                Persona persona = db.GetPersonaPorEmail(email);

                if(persona == null && db.DameCantPersonas() == 0)
                {
                    db.AltaAdministrador(email);
                    puedePasar = true;
                }

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
            bool tienePermiso = db.TienePermisoBuscado(persona, permisoRequeridoParaPasar);

            if (tienePermiso)
            {
                return true;
            }

            return false;
        }
    }
}