using GymProject.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                Persona p = db.getPersonaPorEmail(email);
                if (p != null)
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
        
       public static bool tienePermiso (Persona persona, String permisoRequerido)
       {
            if (persona.Rol == permisoRequerido)
            {
                return true;
            }

            return false;
       }

    }
}