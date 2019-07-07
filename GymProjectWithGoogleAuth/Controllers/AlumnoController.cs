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

        public ActionResult ComprarPack()
        {
            Database db = new Database();
            
            // RECIBE EL PACK COMPRADO Y EL ALUMNO QUE COMPRÓ EL PACK
            // SE CREA EL OBJETO CREDITO CON LOS CAMPOS QUE CORRESPONDAN
            // SE ASIGNA EL CREDITO AL ALUMNO

            return View();
        }

    }
}