using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GymProjectWithGoogleAuth.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class HorarioController : Controller
    {
        // GET: Horario
        public ActionResult Index()
        {
            return View();
        }

        // LISTAR HORARIOS
        public ActionResult ListarHorarios()
        {
            Database db = new Database();
            List<Horario> horarios = db.GetTodosLosHorarios();
            return View(horarios);
        }

        // AGREGAR HORARIO
        public ActionResult AgregarHorario()
        {
            Database db = new Database();
            ViewBag.actividades = db.GetTodasLasActividades();
            ViewBag.profesores = db.GetTodosLosProfesores();
            ViewBag.sucursales = db.GetTodasLasSucursales();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarHorario(Horario horario, FormCollection collection)
        {
            Database db = new Database();

            int idActividad = Convert.ToInt32(collection["idActividad"]);
            horario.Actividad = db.GetActividad(idActividad);

            int idProfesor = Convert.ToInt32(collection["idProfesor"]);
            horario.Profesor = db.GetProfesor(idProfesor);

            int idSucursal = Convert.ToInt32(collection["idSucursal"]);
            horario.Sucursal = db.GetSucursal(idSucursal);
            
            if (ModelState.IsValid)
            {
                db.AltaHorario(horario);
                return RedirectToAction("ListarHorarios");
            }
            else
            {
                ViewBag.actividades = db.GetTodasLasActividades();
                ViewBag.profesores = db.GetTodosLosProfesores();
                ViewBag.sucursales = db.GetTodasLasSucursales();
                return View();
            }
        }

        // MODIFICAR HORARIO
        public ActionResult ModificarHorario(int id)
        {
            Database db = new Database();
            Horario horario = db.GetHorario(id);
            ViewBag.actividades = db.GetTodasLasActividades();
            ViewBag.profesores = db.GetTodosLosProfesores();
            ViewBag.sucursales = db.GetTodasLasSucursales();
            return View(horario);
        }

        [HttpPost]
        public ActionResult ModificarHorario(Horario horario, FormCollection collection)
        {
            Database db = new Database();

            int idActividad = Convert.ToInt32(collection["idActividad"]);
            horario.Actividad = db.GetActividad(idActividad);

            int idProfesor = Convert.ToInt32(collection["idProfesor"]);
            horario.Profesor = db.GetProfesor(idProfesor);

            int idSucursal = Convert.ToInt32(collection["idSucursal"]);
            horario.Sucursal = db.GetSucursal(idSucursal);
            
            if (ModelState.IsValid)
            {
                db.ModificarHorario(horario);
                return RedirectToAction("ListarHorarios");
            }
            else
            {
                ViewBag.actividades = db.GetTodasLasActividades();
                ViewBag.profesores = db.GetTodosLosProfesores();
                ViewBag.sucursales = db.GetTodasLasSucursales();
                return View();
            }
        }

        //ELIMINAR HORARIO
        public ActionResult EliminarHorario(int idHorario)
        {
            Database db = new Database();
            try
            {
                Horario horario = db.GetHorario(idHorario);
                db.BajaHorario(horario);
                return RedirectToAction("ListarHorarios");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarHorarios", "error");
            }
        }

    }
}