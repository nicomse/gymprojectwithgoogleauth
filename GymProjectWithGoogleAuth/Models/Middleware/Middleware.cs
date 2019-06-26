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
        
       public static bool tienePermiso (Persona persona, String permisoRequeridoParaPasar)
       {
            Database db = new Database();
            bool tienePermiso = db.tienePermisoBuscado(persona, permisoRequeridoParaPasar);
            if(tienePermiso)
            {
                return true;
            }
            return false;
       }



    }
}