using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GymProjectWithGoogleAuth.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class ActividadController : Controller
    {
        // GET: Actividad
        public ActionResult Index()
        {
            return View();
        }

        // LISTAR ACTIVIDADES
        public ActionResult ListarActividades()
        {
            Database db = new Database();
            List<Actividad> actividades = db.GetTodasLasActividades();
            return View(actividades);
        }

        // AGREGAR ACTIVIDAD
        public ActionResult AgregarActividad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarActividad(Actividad actividad)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.AltaActividad(actividad);
                return RedirectToAction("AgregarActividad");
            }
            else
            {
                return View();
            }
        }

        // MODIFICAR ACTIVIDAD
        public ActionResult ModificarActividad(int id)
        {
            Database db = new Database();
            Actividad actividad = db.GetActividad(id);
            return View(actividad);
        }

        [HttpPost]
        public ActionResult ModificarActividad(Actividad actividad)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.ModificarActividad(actividad);
                return RedirectToAction("ListarActividades");
            }
            else
            {
                return View();
            }
        }

        //ELIMINAR ACTIVIDAD
        public ActionResult EliminarActividad(int idActividad)
        {
            Database db = new Database();
            try
            {
                Actividad actividad = db.GetActividad(idActividad);
                db.BajaActividad(actividad);
                return RedirectToAction("ListarActividades");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarActividad", "error");
            }
        }
    }
}