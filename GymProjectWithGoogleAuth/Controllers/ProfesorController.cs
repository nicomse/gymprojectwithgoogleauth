using GymProject.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            return View();
        }

        // AGREGAR PROFESOR
        public ActionResult AgregarProfesor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProfesor(Profesor Profesor)
        {
            Database db = new Database();

            Profesor AlumnoEmail = db.GetProfesorPorEmail(Profesor.Email);

            if (AlumnoEmail == null)
            {
                if (ModelState.IsValid)
                {
                    db.AltaProfesor(Profesor);
                    return RedirectToAction("ListarProfesores"); // NO EXISTE EL LISTADO. A DONDE VA ??
                }
                else
                {
                    return View();
                }
            }
            else
            {
                if (AlumnoEmail != null)
                {
                    ModelState.AddModelError("Email", "El profesor ingresado ya existe.");
                }
                return View();
            }
        }
    }
}