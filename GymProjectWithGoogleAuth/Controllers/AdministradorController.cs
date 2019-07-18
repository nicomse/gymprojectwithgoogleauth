﻿using GymProjectWithGoogleAuth.Models.BaseDeDatos;
using GymProjectWithGoogleAuth.Models.Clases;
using Microsoft.AspNet.Identity;
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
            if (ComprobarRolAdministrador())
            {
                return View();
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        // ABM ALUMNOS
        public ActionResult ListarAlumnos()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                List<Alumno> alumnos = db.GetTodosLosAlumnos();
                return View(alumnos);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        public ActionResult AgregarAlumno()
        {
            if (ComprobarRolAdministrador())
            {
                return View();
            }
            else
            {
                return View("AccesoDenegado");
            }
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
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                Alumno alu = db.GetAlumno(id);
                return View(alu);
            }
            else
            {
                return View("AccesoDenegado");
            }
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
            if (ComprobarRolAdministrador())
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
                    throw e;
                }
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        // ABM PROFESORES
        public ActionResult ListarProfesores()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                List<Profesor> profesores = db.GetTodosLosProfesores();

                return View(profesores);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        public ActionResult AgregarProfesor()
        {
            if (ComprobarRolAdministrador())
            {
                return View();
            }
            else
            {
                return View("AccesoDenegado");
            }
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
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                Profesor profesor = db.GetProfesor(id);
                return View(profesor);
            }
            else
            {
                return View("AccesoDenegado");
            }

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
            if (ComprobarRolAdministrador())
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
                    throw e;
                }
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        // ABM SUCURSALES
        public ActionResult ListarSucursales()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                List<Sucursal> sucursales = db.GetTodasLasSucursales();
                return View(sucursales);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        public ActionResult AgregarSucursal()
        {
            if (ComprobarRolAdministrador())
            {
                return View();
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        [HttpPost]
        public ActionResult AgregarSucursal(Sucursal sucursal)
        {
            Database db = new Database();

            Sucursal sucursalDireccion = db.GetSucursalPorDireccion(sucursal.Direccion);

            if (sucursalDireccion == null)
            {
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
            else
            {
                if (sucursalDireccion != null)
                {
                    ModelState.AddModelError("Direccion", "La sucursal ingresada ya existe.");
                }
                return View();
            }
        }

        public ActionResult ModificarSucursal(int id)
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                Sucursal sucursal = db.GetSucursal(id);
                return View(sucursal);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        [HttpPost]
        public ActionResult ModificarSucursal(Sucursal sucursal)
        {
            Database db = new Database();

            try
            {
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
            catch
            {
                ModelState.AddModelError("Direccion", "La dirección ingresada ya existe.");
                return View();
            }
        }

        public ActionResult EliminarSucursal(int idSucursal)
        {
            if (ComprobarRolAdministrador())
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
                    throw e;
                }
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        // ABM ACTIVIDADES
        public ActionResult ListarActividades()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                List<Actividad> actividades = db.GetTodasLasActividades();
                return View(actividades);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        public ActionResult AgregarActividad()
        {
            if (ComprobarRolAdministrador())
            {
                return View();
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        [HttpPost]
        public ActionResult AgregarActividad(Actividad actividad)
        {
            Database db = new Database();

            Actividad actividadNombre = db.GetActividadPorNombre(actividad.Nombre);

            if (actividadNombre == null)
            {

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
            else
            {
                if (actividadNombre != null)
                {
                    ModelState.AddModelError("Nombre", "La actividad ingresada ya existe.");
                }
                return View();
            }
        }

        public ActionResult ModificarActividad(int id)
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                Actividad actividad = db.GetActividad(id);
                return View(actividad);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        [HttpPost]
        public ActionResult ModificarActividad(Actividad actividad)
        {
            Database db = new Database();

            Actividad actividadNombre = db.GetActividadPorNombre(actividad.Nombre);

            if (actividadNombre == null)
            {

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
            else
            {
                if (actividadNombre != null)
                {
                    ModelState.AddModelError("Nombre", "La actividad ingresada ya existe.");
                }
                return View();
            }
        }

        public ActionResult EliminarActividad(int idActividad)
        {
            if (ComprobarRolAdministrador())
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
                    throw e;
                }
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        // ABM PACKS
        public ActionResult ListarPacks()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                List<Pack> packs = db.GetTodosLosPacks();
                return View(packs);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        public ActionResult AgregarPack()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                ViewBag.data = db.GetTodasLasSucursales();
                return View();
            }
            else
            {
                return View("AccesoDenegado");
            }
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
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                Pack pack = db.GetPack(id);
                ViewBag.data = db.GetTodasLasSucursales();
                return View(pack);
            }
            else
            {
                return View("AccesoDenegado");
            }
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
            if (ComprobarRolAdministrador())
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
                    throw e;
                }
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        // CRÉDITOS
        public ActionResult AsignarCreditosAlumno()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                List<Pack> packs = db.GetTodosLosPacks();
                return View(packs);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        [HttpPost]
        public JsonResult AsignarPack(FormCollection form)
        {
            try
            {
                int idPack = Convert.ToInt32(form["idPack"]);
                String emailAlumno = (form["emailAlumno"]).ToString();

                if (emailAlumno == "")
                {
                    return Json("Debe ingresar un E-Mail.");
                }

                Database db = new Database();
                Alumno alumno = db.GetAlumnoPorEmail(emailAlumno);
                Pack pack = db.GetPack(idPack);
                db.AltaCredito(alumno, pack);

                return Json("Se le han asignado correctamente los créditos al alumno.");
            }
            catch
            {
                return Json("El E-Mail ingresado es incorrecto.");
            }
        }

        // ABM HORARIOS
        public ActionResult ListarHorarios()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                List<Horario> horarios = db.GetTodosLosHorarios();
                return View(horarios);
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        public ActionResult AgregarHorario()
        {
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                ViewBag.actividades = db.GetTodasLasActividades();
                ViewBag.profesores = db.GetTodosLosProfesores();
                ViewBag.sucursales = db.GetTodasLasSucursales();
                return View();
            }
            else
            {
                return View("AccesoDenegado");
            }
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
            if (ComprobarRolAdministrador())
            {
                Database db = new Database();
                Horario horario = db.GetHorario(id);
                ViewBag.actividades = db.GetTodasLasActividades();
                ViewBag.profesores = db.GetTodosLosProfesores();
                ViewBag.sucursales = db.GetTodasLasSucursales();
                return View(horario);
            }
            else
            {
                return View("AccesoDenegado");
            }
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
            if (ComprobarRolAdministrador())
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
                    throw e;
                }
            }
            else
            {
                return View("AccesoDenegado");
            }
        }

        public bool ComprobarRolAdministrador()
        {
            bool comprobado = false;

            if (User.Identity.IsAuthenticated)
            {
                Database db = new Database();
                String email = User.Identity.GetUserName();
                String rol = db.GetRolPersona(email);

                if (rol == "ADMINISTRADOR")
                {
                    comprobado = true;
                }
            }

            return comprobado;
        }
    }
}