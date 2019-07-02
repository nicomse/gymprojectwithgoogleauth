using System;
using System.Collections.Generic;
using System.Web.Mvc;
using GymProjectWithGoogleAuth.Models.Clases;
using GymProjectWithGoogleAuth.Models.BaseDeDatos;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class PackController : Controller
    {
        // GET: Pack
        public ActionResult Index()
        {
            return View();
        }

        // LISTAR PACKS
        public ActionResult ListarPacks()
        {
            Database db = new Database();
            List<Pack> packs = db.GetTodosLosPacks();
            return View(packs);
        }

        // AGREGAR PACK
        public ActionResult AgregarPack()
        {
            Database db = new Database();
            ViewBag.data = db.GetTodasLasSucursales();
            return View();
        }

        [HttpPost]
        public ActionResult AgregarPack(Pack pack, FormCollection collection)
        {
            Database db = new Database();

            int idSucursal = Convert.ToInt32(collection["idSucursal"]);
            pack.Sucursal = db.GetSucursal(idSucursal);

            if (ModelState.IsValid)
            {
                db.AltaPack(pack);
                return RedirectToAction("ListarPacks");
            }
            else
            {
                ViewBag.data = db.GetTodasLasSucursales();
                return View();
            }
        }

        // MODIFICAR PACK
        public ActionResult ModificarPack(int id)
        {
            Database db = new Database();
            Pack pack = db.GetPack(id);
            ViewBag.data = db.GetTodasLasSucursales();
            return View(pack);
        }

        [HttpPost]
        public ActionResult ModificarPack(Pack pack, FormCollection collection)
        {
            Database db = new Database();

            int idSucursal = Convert.ToInt32(collection["idSucursal"]);
            pack.Sucursal = db.GetSucursal(idSucursal);

            if (ModelState.IsValid)
            {
                db.ModificarPack(pack);
                return RedirectToAction("ListarPacks");
            }
            else
            {
                ViewBag.data = db.GetTodasLasSucursales();
                return View();
            }
        }

        //ELIMINAR PACK
        public ActionResult EliminarPack(int idPack)
        {
            Database db = new Database();
            try
            {
                Pack pack = db.GetPack(idPack);
                db.BajaPack(pack);
                return RedirectToAction("ListarPacks");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarPacks", "error");
            }
        }
    }
}