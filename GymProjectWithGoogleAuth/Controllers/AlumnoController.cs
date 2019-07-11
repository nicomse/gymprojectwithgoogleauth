using System;
using System.Collections.Generic;
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

        public ActionResult VerDetalleCredito(int idCredito)
        {
            Database db = new Database();
            Credito credito = db.GetCredito(idCredito);

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
            int idSucursal = Convert.ToInt32(form["idSucursal"]);
            int idHorario = Convert.ToInt32(form["idHorario"]);

            Database db = new Database();
            Alumno alumno = db.GetAlumnoPorEmail(User.Identity.GetUserName());
            Credito credito = db.GetCreditoSucursalMasProximoAExpirar(idSucursal, alumno.IdAlumno);

            db.InsertarAlumnoAHorario(alumno.IdAlumno, idHorario, credito.IdCredito);

            return Json("La inscripción a la actividad fue realizada con éxito.");
        }
    }
}