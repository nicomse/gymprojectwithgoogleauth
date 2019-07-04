using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GymProjectWithGoogleAuth.Models.Clases;
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

        // LISTAR ALUMNOS
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
                    return RedirectToAction("AgregarAlumno");
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

        //ELIMINAR ALUMNO
        public ActionResult EliminarAlumno(int idAlumno)
        {
            Database db = new Database();
            try
            {
                Alumno alumno = db.GetAlumno(idAlumno);
                db.BajaAlumno(alumno);
                return RedirectToAction("ListarAlumnos");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarAlumnos", "error");
            }
        }
        [HttpGet]
        public ActionResult validarController()
        {
            if (User != null)
            {
                string email = User.Identity.Name;
                Database db = new Database();
                Persona persona = null;
                try
                {
                    persona = db.GetPersonaPorEmail(email);
                    if (persona != null)
                    {
                        if (!db.TienePermisoBuscado(persona, "ALUMNO"))
                        {
                            return RedirectToAction("NotAllowedPage", "Account");
                        }
                        else
                        {
                            return RedirectToRoute("/");
                            ;
                        }
                    }
                    else
                    {
                        return RedirectToRoute("/");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                return RedirectToRoute("/");
            }
        }

    }
}