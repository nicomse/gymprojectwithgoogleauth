using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymProject.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Index()
        {
            return View();
        }

        // LISTAR PROFESORES
        public ActionResult ListarProfesores()
        {
            Database db = new Database();
            List<Profesor> profesores = db.GetTodosLosProfesores();

            return View(profesores);
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
                    return RedirectToAction("AgregarProfesor");
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

        // MODIFICAR PROFESOR
        public ActionResult ModificarProfesor(int id)
        {
            Database db = new Database();
            Profesor profesor = db.GetProfesor(id);
            return View(profesor);
        }

        [HttpPost]
        public ActionResult ModificarProfesor(Profesor profesor)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.ModificarProfesor(profesor);
                return RedirectToAction("ListarProfesores");
            }
            else
            {
                return View();
            }
        }

        // BUSCAR PROFESORES

        [HttpPost]
        public PartialViewResult BuscarProfesoresAjax(FormCollection form)
        {
            String email = form["email"];
            Database db = new Database();
            if (email == "")
            {
                try
                {
                    List<Profesor> profesores = db.GetTodosLosProfesores();
                    return PartialView("ListarProfesoresParcial", profesores);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                try
                {
                    List<Profesor> profesores = db.BuscarProfesorPorEmail(email);
                    return PartialView("ListarProfesoresParcial", profesores);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        //ELIMINAR PROFESOR
        public ActionResult EliminarProfesor(int idProfesor)
        {
            Database db = new Database();
            try
            {
                Profesor profesor = db.GetProfesor(idProfesor);
                db.BajaProfesor(profesor);
                return RedirectToAction("ListarProfesores");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarProfesores", "error");
            }
        }

    }
}