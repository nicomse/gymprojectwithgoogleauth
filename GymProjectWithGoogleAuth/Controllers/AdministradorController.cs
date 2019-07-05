using GymProjectWithGoogleAuth.Models.BaseDeDatos;
using GymProjectWithGoogleAuth.Models.Clases;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GymProjectWithGoogleAuth.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }

        // ABM ALUMNOS
        public ActionResult ListarAlumnos()
        {
            Database db = new Database();
            List<Alumno> alumnos = db.GetTodosLosAlumnos();
            return View(alumnos);
        }

        public ActionResult AgregarAlumno()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarAlumno(Alumno alumno)
        {
            Database db = new Database();

            Alumno AlumnoEmail = db.GetAlumnoPorEmail(alumno.Email);

            if (AlumnoEmail == null)
            {
                if (ModelState.IsValid)
                {
                    db.AltaAlumno(alumno);
                    return RedirectToAction("AgregarAlumno");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                if (AlumnoEmail != null)
                {
                    ModelState.AddModelError("Email", "El alumno ingresado ya existe.");
                }
                return View();
            }
        }

        public ActionResult ModificarAlumno(int id)
        {
            Database db = new Database();
            Alumno alu = db.GetAlumno(id);
            return View(alu);
        }

        [HttpPost]
        public ActionResult ModificarAlumno(Alumno alumno)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.ModificarAlumno(alumno);
                return RedirectToAction("ListarAlumnos");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EliminarAlumno(int idAlumno)
        {
            Database db = new Database();
            try
            {
                Alumno alumno = db.GetAlumno(idAlumno);
                db.BajaAlumno(alumno);
                return RedirectToAction("ListarAlumnos");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarAlumnos", "error");
            }
        }

        // AMB PROFESORES
        public ActionResult ListarProfesores()
        {
            Database db = new Database();
            List<Profesor> profesores = db.GetTodosLosProfesores();

            return View(profesores);
        }

        public ActionResult AgregarProfesor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProfesor(Profesor Profesor)
        {
            Database db = new Database();

            Profesor ProfesorEmail = db.GetProfesorPorEmail(Profesor.Email);

            if (ProfesorEmail == null)
            {
                if (ModelState.IsValid)
                {
                    db.AltaProfesor(Profesor);
                    return RedirectToAction("AgregarProfesor");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                if (ProfesorEmail != null)
                {
                    ModelState.AddModelError("Email", "El profesor ingresado ya existe.");
                }
                return View();
            }
        }

        public ActionResult ModificarProfesor(int id)
        {
            Database db = new Database();
            Profesor profesor = db.GetProfesor(id);
            return View(profesor);
        }

        [HttpPost]
        public ActionResult ModificarProfesor(Profesor profesor)
        {
            Database db = new Database();

            if (ModelState.IsValid)
            {
                db.ModificarProfesor(profesor);
                return RedirectToAction("ListarProfesores");
            }
            else
            {
                return View();
            }
        }

        public ActionResult EliminarProfesor(int idProfesor)
        {
            Database db = new Database();
            try
            {
                Profesor profesor = db.GetProfesor(idProfesor);
                db.BajaProfesor(profesor);
                return RedirectToAction("ListarProfesores");
            }
            catch (Exception e)
            {
                return RedirectToAction("ListarProfesores", "error");
            }
        }

        // ABM SUCURSALES
        public ActionResult ListarSucursales()
        {
            Database db = new Database();
            List<Sucursal> sucursales = db.GetTodasLasSucursales();
            return View(sucursales);
        }

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

        // ABM ACTIVIDADES
        public ActionResult ListarActividades()
        {
            Database db = new Database();
            List<Actividad> actividades = db.GetTodasLasActividades();
            return View(actividades);
        }

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

        // ABM PACKS
        public ActionResult ListarPacks()
        {
            Database db = new Database();
            List<Pack> packs = db.GetTodosLosPacks();
            return View(packs);
        }

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

        // ABM HORARIOS
        public ActionResult ListarHorarios()
        {
            Database db = new Database();
            List<Horario> horarios = db.GetTodosLosHorarios();
            return View(horarios);
        }

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