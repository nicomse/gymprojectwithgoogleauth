using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GymProjectWithGoogleAuth.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            return View();
        }

        // LISTAR SUCURSALES
        public ActionResult ListarSucursales()
        {
            Database db = new Database();
            List<Sucursal> sucursales = db.GetTodasLasSucursales();
            return View(sucursales);
        }

        // AGREGAR SUCURSAL
        public ActionResult AgregarSucursal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarSucursal(Sucursal sucursal)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.AltaSucursal(sucursal);
                return RedirectToAction("AgregarSucursal");
            }
            else
            {
                return View();
            }
        }

        // MODIFICAR SUCURSAL
        public ActionResult ModificarSucursal(int id)
        {
            Database db = new Database();
            Sucursal sucursal = db.GetSucursal(id);
            return View(sucursal);
        }

        [HttpPost]
        public ActionResult ModificarSucursal(Sucursal sucursal)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.ModificarSucursal(sucursal);
                return RedirectToAction("ListarSucursales");
            }
            else
            {
                return View();
            }
        }

        //ELIMINAR SUCURSAL
        public ActionResult EliminarSucursal(int idSucursal)
        {
            Database db = new Database();
            try
            {
                Sucursal sucursal = db.GetSucursal(idSucursal);
                db.BajaSucursal(sucursal);
                return RedirectToAction("ListarSucursales");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarSucursal", "error");
            }
        }
    }
}