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
                List<Horario> dias = db.GetTodosLosDiasDeUnProfesor(idSucursal, profesor.IdProfesor, idActividad);
                return PartialView("Dias_Partial", dias);
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

        public PartialViewResult DamePartialAlumnos()
        {
            Database db = new Database();

            try
            {
                Profesor profesor = db.GetProfesorPorEmail(User.Identity.GetUserName());
                // FALTA HACER EL SP (Y SU MÉTODO EN DATABASE) PARA LLENAR LA LISTA alumnos CON LO QUE CORRESPONDE.
                List<Alumno> alumnos = new List<Alumno>();
                return PartialView("Alumnos_Partial", alumnos);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}