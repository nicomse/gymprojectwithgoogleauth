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
        // POSIBLE MANERA DE RESTRINGIR EL ACCESO A LOS ROLES NO PERMITIDOS.

        /*public ActionResult ComprobarRol()
        {
            Database db = new Database();
            String email = User.Identity.GetUserName();
            String rol = db.GetRolPersona(email);

            if (rol != "ALUMNO")
            {
                return RedirectToAction("NotAllowedPage");
            }

            return View();
        }*/

        // GET: Alumno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarCreditosAlumno()
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

        public ActionResult ListarPacks()
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

            return RedirectToAction("ListarCreditosAlumno");
        }

    }
}