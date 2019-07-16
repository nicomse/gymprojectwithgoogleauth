using GymProjectWithGoogleAuth.Models.BaseDeDatos;
using GymProjectWithGoogleAuth.Models.Clases;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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

        public ActionResult TomarAsistencia()
        {
            Database db = new Database();
            Profesor profesor = db.GetProfesorPorEmail(User.Identity.GetUserName());
            List<Sucursal> sucursales = db.GetTodasLasSucursalesDeUnProfesor(profesor.IdProfesor);

            return View(sucursales);
        }

        public PartialViewResult DamePartialActividades(int idSucursal)
        {
            Database db = new Database();

            try
            {
                Profesor profesor = db.GetProfesorPorEmail(User.Identity.GetUserName());
                List<Actividad> actividades = db.GetTodasLasActividadesDeUnProfesor(idSucursal, profesor.IdProfesor);

                return PartialView("Actividades_Partial", actividades);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PartialViewResult DamePartialDias(int idSucursal, int idActividad)
        {
            Database db = new Database();

            try
            {
                Profesor profesor = db.GetProfesorPorEmail(User.Identity.GetUserName());
                List<String> dias = db.GetTodosLosDiasDeUnProfesor(idSucursal, profesor.IdProfesor, idActividad);
                ViewBag.dias = dias;

                return PartialView("Dias_Partial");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PartialViewResult DamePartialHorarios(int idSucursal, int idActividad, String dia)
        {
            Database db = new Database();

            try
            {
                Profesor profesor = db.GetProfesorPorEmail(User.Identity.GetUserName());
                List<Horario> horarios = db.GetTodosLosHorariosDeUnProfesor(idSucursal, profesor.IdProfesor, idActividad, dia);

                return PartialView("Horarios_Partial", horarios);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PartialViewResult DamePartialFechas(int idHorario)
        {
            Database db = new Database();

            try
            {
                Profesor profesor = db.GetProfesorPorEmail(User.Identity.GetUserName());
                List<String> fechas = db.GetTodasLasFechasDeUnHorario(idHorario);
                ViewBag.fechas = fechas;

                return PartialView("Fechas_Partial");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PartialViewResult DamePartialAlumnos(int idHorario, String fechaActividad)
        {
            Database db = new Database();

            try
            {
                DateTime fecha = Convert.ToDateTime(fechaActividad);
                Profesor profesor = db.GetProfesorPorEmail(User.Identity.GetUserName());
                List<Alumno> alumnos = db.GetAlumnosHorario(idHorario, fecha);

                return PartialView("Alumnos_Partial", alumnos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public JsonResult DarElPresente(int idAlumno, int idHorario, String fechaActividad, String estado)
        {
            Database db = new Database();
            DateTime fecha = Convert.ToDateTime(fechaActividad);
            bool asistencia = db.TomarAsistencia(idAlumno, idHorario, fecha, estado);

            return Json(asistencia, JsonRequestBehavior.AllowGet);
        }
    }
}