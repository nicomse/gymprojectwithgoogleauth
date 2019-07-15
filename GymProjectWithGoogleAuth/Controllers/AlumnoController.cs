using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;
using GymProjectWithGoogleAuth.Models.Clases;
using Microsoft.AspNet.Identity;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class AlumnoController : Controller
    {
        // POSIBLE MANERA DE RESTRINGIR EL ACCESO A LOS ROLES NO PERMITIDOS

        /* public ActionResult ComprobarRol()
        {
            Database db = new Database();
            String email = User.Identity.GetUserName();
            String rol = db.GetRolPersona(email);

            if (rol != "ALUMNO")
            {
                return RedirectToAction("AccesoDenegado");
            }

            return View();
        } */

        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComprarCreditos()
        {
            Database db = new Database();
            List<Pack> packs = db.GetTodosLosPacks();

            return View(packs);
        }

        public ActionResult ComprarPack(int idPack)
        {
            Database db = new Database();
            Alumno alumno = db.GetAlumnoPorEmail(User.Identity.GetUserName());
            Pack pack = db.GetPack(idPack);
            db.AltaCredito(alumno, pack);

            return RedirectToAction("ListarCreditos");
        }

        public ActionResult ListarCreditos()
        {
            Database db = new Database();
            Alumno alumno = db.GetAlumnoPorEmail(User.Identity.GetUserName());
            List<Credito> creditos = db.GetCreditosAlumno(alumno.IdAlumno);

            return View(creditos);
        }

        public ActionResult VerDetalleCredito(int id)
        {
            Database db = new Database();
            Credito credito = db.GetCredito(id);
            List<List<String>> detalleCreditos = db.GetDetalleCredito(id);
            ViewBag.detalleCreditos = detalleCreditos;

            return View(credito);
        }

        public ActionResult InscribirActividad()
        {
            Database db = new Database();
            Alumno alumno = db.GetAlumnoPorEmail(User.Identity.GetUserName());
            List<Sucursal> sucursales = db.GetTodasLasSucursalesDeUnAlumno(alumno.IdAlumno);

            return View(sucursales);
        }

        public PartialViewResult DamePartialHorario(int idSucursal)
        {
            Database db = new Database();

            try
            {
                List<Horario> horarios = db.GetTodosLosHorariosDeSucursal(idSucursal);
                return PartialView("Horario_Partial", horarios);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public JsonResult Inscribir(FormCollection form)
        {
            try
            {
                int idSucursal = Convert.ToInt32(form["idSucursal"]);
                int idHorario = Convert.ToInt32(form["idHorario"]);
                DateTime fechaActividad = Convert.ToDateTime(form["fechaActividad"]);

                Database db = new Database();
                Horario horario = db.GetHorario(idHorario);

                if (!FechaValida(fechaActividad, horario.Dia))
                {
                    return Json("La fecha seleccionada no es válida.");
                }

                Alumno alumno = db.GetAlumnoPorEmail(User.Identity.GetUserName());
                Credito credito = db.GetCreditoSucursalMasProximoAExpirar(idSucursal, alumno.IdAlumno);

                if (credito.Cantidad > 0)
                {
                    try
                    {
                        db.InsertarAlumnoAHorario(alumno.IdAlumno, idHorario, credito.IdCredito, fechaActividad);
                        db.DescontarCredito(credito.IdCredito, credito.Cantidad);
                    }
                    catch
                    {
                        return Json("Ya se encuentra inscripto a esta actividad en la fecha seleccionada.");
                    }

                    return Json("La inscripción a la actividad fue realizada con éxito.");
                }
                else
                {
                    return Json("No cuenta con créditos suficientes para realizar la inscripción.");
                }
            }
            catch
            {
                return Json("Debe ingresar una fecha para completar la inscripción.");
            }
        }

        [HttpPost]
        public JsonResult Desuscribir(FormCollection form)
        {
            try
            {
                Database db = new Database();
                Alumno alumno = db.GetAlumnoPorEmail(User.Identity.GetUserName());
                int idHorario = Convert.ToInt32(form["id"]);
                DateTime fechaActividad = Convert.ToDateTime(form["desde"]);

                if (DateTime.Today < fechaActividad)
                {
                    db.DesuscribirAlumno(alumno.IdAlumno, idHorario, fechaActividad);
                    Credito credito = db.DameCreditoAlumnoHorario(alumno.IdAlumno, idHorario, fechaActividad);
                    db.AumentarCredito(credito.IdCredito, credito.Cantidad);
                    return Json("La desuscripción a la actividad fue realizada con éxito.");
                }
                else
                {
                    return Json("No puede desuscribirse de una actividad que ya fue realizada.");
                }
            }
            catch
            {
                return Json("No fue posible realizar la desuscripción de la actividad seleccionada.");
            }
        }

        public bool FechaValida(DateTime fechaActividad, String diaActividad)
        {
            bool valida = false;

            CultureInfo ci = new CultureInfo("Es-Es");
            String diaSeleccionado = ci.DateTimeFormat.GetDayName(fechaActividad.DayOfWeek);
            TimeSpan diferencia = fechaActividad - DateTime.Today;

            if (diaActividad.ToLower() == diaSeleccionado && diferencia.Days <= 30 && diferencia.Days > 0)
            {
                valida = true;
            }

            return valida;
        }

        public ActionResult CalendarioActividades()
        {
            return View();
        }

        public JsonResult GetEventosAlumno()
        {
            Database db = new Database();
            Alumno alumno = db.GetAlumnoPorEmail(User.Identity.GetUserName());
            List<Dictionary<String, String>> actividades = db.GetActividadesDeUnAlumno(alumno.IdAlumno);
            return Json(actividades, JsonRequestBehavior.AllowGet);
        }
    }
}