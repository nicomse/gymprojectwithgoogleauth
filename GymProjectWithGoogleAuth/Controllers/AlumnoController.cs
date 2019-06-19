using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymProject.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        // AGREGAR ALUMNO
        public ActionResult AgregarAlumno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarAlumno(Alumno alumno)
        {
            Database db = new Database();

            Alumno AlumnoEmail = db.GetAlumnoPorEmail(alumno.Email);

            if (AlumnoEmail == null)
            {
                if (ModelState.IsValid)
                {
                    db.AltaAlumno(alumno);
                    return RedirectToAction("ListarAlumnos"); // NO EXISTE EL LISTADO DE ALUMNOS. A DONDE VA ??
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
                    ModelState.AddModelError("Email", "El alumno ingresado ya existe.");
                }
                return View();
            }
        }

        // MODIFICAR ALUMNO
        public ActionResult ModificarAlumno(int id)
        {
            Database db = new Database();
            Alumno alumno = db.GetAlumno(id);
            return View(alumno);
        }

        [HttpPost]
        public ActionResult ModificarAlumno(Alumno alumno)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.ModificarAlumno(alumno);
                return RedirectToAction("ListarAlumnos"); // NO EXISTE EL LISTADO DE ALUMNOS. A DONDE VA ??
            }
            else
            {
                return View();
            }
        }
    }
}