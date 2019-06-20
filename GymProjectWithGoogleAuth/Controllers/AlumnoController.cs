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

        public ActionResult ListarAlumnos()
        {
            Database db = new Database();
            List<Alumno> alumnos = db.GetTodosLosAlumnos();

            return View(alumnos);
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
                    return RedirectToAction("ListarAlumnos");
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
            Alumno alu = db.GetAlumno(id);
            return View(alu);
        }

        [HttpPost]
        public ActionResult ModificarAlumno(Alumno alumno)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.ModificarAlumno(alumno);
                return RedirectToAction("ListarAlumnos");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public PartialViewResult BuscarAlumnosAjax(FormCollection form)
        {
            String email = form["email"];
            Database db = new Database();
            if (email == "")
            {
                try
                {
                    List<Alumno> alumnos = db.GetTodosLosAlumnos();
                    return PartialView("ListadoAlumnos", alumnos);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else {
                try
                {
                    List<Alumno> alumnos = db.BuscarAlumnoPorEmail(email);
                    return PartialView("ListadoAlumnos", alumnos);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        //ELIMINAR ALUMNO
        public ActionResult EliminarAlumno(int idAlumno) {
            Database db = new Database();
            try
            {
                Alumno alumno = db.GetAlumno(idAlumno);
                db.BajaAlumno(alumno);
                return RedirectToAction("ListarAlumnos");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarAlumnos","error");
            }
        }




    }
}