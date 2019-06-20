﻿using GymProject.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GymProjectWithGoogleAuth.Models.BaseDeDatos
{
    public class Database
    {

        public static string DATABASE_NAME = "Taller6";
        // ABRIR CONEXION DE LA BASE DE DATOS
        public static SqlConnection AbrirConexion()
        {
            SqlConnection conn;
            try
            {
                conn = new SqlConnection
                {
                    ConnectionString = getConnectionString()
                };
                conn.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
            return conn;
        }

        // CERRAR CONEXION DE LA BASE DE DATOSs

        public static void CerrarConexion(SqlConnection conn)
        {
            conn.Close();
        }
        // OBTENER EL CONNECTION STRING DE LA BASE DE DATOS
        public static String getConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Database=" + DATABASE_NAME + ";Integrated Security= true";
        }

        // inicio modulo actividades
        public bool altaActividad(Actividad actividad)
        {
            bool insertado = false;
            try
            {
                SqlConnection conn = AbrirConexion();

                SqlCommand cmd = new SqlCommand(
                    "dbo.altaActividad", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@nombre", actividad.Nombre));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    insertado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return insertado;
        }

        public Actividad getActividad(int idActividad)
        {
            Actividad miActividad = null;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.getActividadPorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idActividad", idActividad));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();


                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miActividad = new Actividad
                        {
                            IdActividad = Convert.ToInt32(miLectorDeDatos["idActividad"]),
                            Nombre = miLectorDeDatos["idActividad"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return miActividad;
        }

        public bool modificarActividad(Actividad actividadAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.modificarActividad", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idActividad", actividadAModificar.IdActividad));
                cmd.Parameters.Add(
                   new SqlParameter("@nombre", actividadAModificar.Nombre));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    modificado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return modificado;
        }

        public bool bajaActividad(Actividad actividadAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.bajaActividad", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idActividad", actividadAEliminar.IdActividad));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    baja = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return baja;
        }

        // fin modulo actividades

        // inicio modulo alumnos

        public bool AltaAlumno(Alumno alumno)
        {
            bool insertado = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.altaAlumno", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nombre", alumno.Nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido", alumno.Apellido));
                cmd.Parameters.Add(new SqlParameter("@email", alumno.Email));
                cmd.Parameters.Add(new SqlParameter("@telefono", alumno.Telefono));
                // cmd.Parameters.Add(new SqlParameter("@rol", alumno.Rol));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    insertado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return insertado;
        }

        // GET ALUMNO POR ID
        public Alumno GetAlumno(int idAlumno)
        {
            Alumno miAlumno = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getAlumnoPorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idAlumno", idAlumno));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miAlumno = new Alumno
                        {
                            IdAlumno = Convert.ToInt32(miLectorDeDatos["idAlumno"]),
                            IdPersona = Convert.ToInt32(miLectorDeDatos["idPersona"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Apellido = miLectorDeDatos["apellido"].ToString(),
                            Email = miLectorDeDatos["email"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Rol = miLectorDeDatos["rol"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                            //@ TO DO falta llenar atributo CREDITOS y HORARIOS
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return miAlumno;
        }

        //OBTENER TODOS LOS ALUMNOS

        public List<Alumno> GetTodosLosAlumnos()
        {
            List<Alumno> misAlumnos = new List<Alumno>();
            Alumno miAlumno;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getTodosLosAlumnos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        miAlumno = new Alumno
                        {
                            IdAlumno = Convert.ToInt32(miLectorDeDatos["idAlumno"]),
                            IdPersona = Convert.ToInt32(miLectorDeDatos["idPersona"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Apellido = miLectorDeDatos["apellido"].ToString(),
                            Email = miLectorDeDatos["email"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Rol = miLectorDeDatos["rol"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                            //@ TO DO falta llenar atributo CREDITOS y HORARIOS
                        };
                        misAlumnos.Add(miAlumno);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return misAlumnos;
        }

        // buscar alumno por mail
        public List<Alumno> BuscarAlumnoPorEmail(String EmailAlumno)
        {
            List<Alumno> misAlumnos = new List<Alumno>();
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.buscarAlumnoPorMail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@email", EmailAlumno));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        Alumno miAlumno = new Alumno
                        {
                            IdAlumno = Convert.ToInt32(miLectorDeDatos["idAlumno"]),
                            IdPersona = Convert.ToInt32(miLectorDeDatos["idPersona"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Apellido = miLectorDeDatos["apellido"].ToString(),
                            Email = miLectorDeDatos["email"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Rol = miLectorDeDatos["rol"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                        };
                        misAlumnos.Add(miAlumno);
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return misAlumnos;
        }

        // GET ALUMNO POR EMAIL

        public Alumno GetAlumnoPorEmail(String EmailAlumno)
        {
            Alumno miAlumno = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.getAlumnoPorEmail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@emailAlumno", EmailAlumno));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miAlumno = new Alumno
                        {
                            IdAlumno = Convert.ToInt32(miLectorDeDatos["idAlumno"]),
                            IdPersona = Convert.ToInt32(miLectorDeDatos["idPersona"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Apellido = miLectorDeDatos["apellido"].ToString(),
                            Email = miLectorDeDatos["email"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Rol = miLectorDeDatos["rol"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return miAlumno;
        }

        // MODIFICAR ALUMNO
        public bool ModificarAlumno(Alumno alumnoAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.modificarAlumno", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idAlumno", alumnoAModificar.IdAlumno));
                cmd.Parameters.Add(new SqlParameter("@nombre", alumnoAModificar.Nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido", alumnoAModificar.Apellido));
                cmd.Parameters.Add(new SqlParameter("@email", alumnoAModificar.Email));
                cmd.Parameters.Add(new SqlParameter("@telefono", alumnoAModificar.Telefono));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    modificado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return modificado;
        }

        //BAJA ALUMNO

        public bool BajaAlumno(Alumno alumnoAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.bajaAlumno", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idAlumno", alumnoAEliminar.IdAlumno));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    baja = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return baja;
        }
        // fin modulo alumnos


        // inicio modulo sucursales

        public bool altaSucursal(Sucursal sucursal)
        {
            bool insertado = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.altaSucursal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@barrio", sucursal.Barrio));
                cmd.Parameters.Add(
                    new SqlParameter("@direccion", sucursal.Direccion));
                cmd.Parameters.Add(
                    new SqlParameter("@telefono", sucursal.Telefono));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    insertado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return insertado;
        }

        public Sucursal getSucursal(int nroSucursal)
        {
            Sucursal miSucursal = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.getSucursalPorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@nroSucursal", nroSucursal));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miSucursal = new Sucursal
                        {
                            NroSucursal = Convert.ToInt32(miLectorDeDatos["nroSucursal"]),
                            Barrio = miLectorDeDatos["barrio"].ToString(),
                            Direccion = miLectorDeDatos["direccion"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString()
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return miSucursal;
        }

        public bool modificarSucursal(Sucursal sucursalAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.modificarSucursal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@nroSucursal", sucursalAModificar.NroSucursal));
                cmd.Parameters.Add(
                   new SqlParameter("@barrio", sucursalAModificar.Barrio));
                cmd.Parameters.Add(
                  new SqlParameter("@direccion", sucursalAModificar.Direccion));
                cmd.Parameters.Add(
                  new SqlParameter("@telefono", sucursalAModificar.Telefono));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    modificado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return modificado;
        }

        public bool bajaSucursal(Sucursal sucursalAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.bajaSucursal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@nroSucursal", sucursalAEliminar.NroSucursal));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    baja = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return baja;
        }


        //fin modulo sucursales
        

        // inicio modulo packs
        public bool altaPack(Pack pack)
        {
            bool insertado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.altaPack", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@nroSucursal", pack.Sucursal.NroSucursal));
                cmd.Parameters.Add(
                    new SqlParameter("@cantCreditos", pack.CantCreditos));
                cmd.Parameters.Add(
                    new SqlParameter("@diasVigencia", pack.DiasVigencia));
                cmd.Parameters.Add(
                    new SqlParameter("@precio", pack.Precio));


                if (cmd.ExecuteNonQuery() > 0)
                {
                    insertado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return insertado;
        }

        public Pack getPack(int idPack)
        {
            Pack miPack = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.getPackPorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idPack", idPack));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miPack = new Pack
                        {
                            IdPack = Convert.ToInt32(miLectorDeDatos["idPack"]),
                            Sucursal = getSucursal(Convert.ToInt32(miLectorDeDatos["nroSucursal"])),
                            CantCreditos = Convert.ToInt32(miLectorDeDatos["cantCreditos"]),
                            DiasVigencia = Convert.ToInt32(miLectorDeDatos["diasVigencia"]),
                            Precio = float.Parse(miLectorDeDatos["precio"].ToString()),// chequear esta func


                            //@ TO DO falta llenar atributo CREDITOS y HORARIOS
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return miPack;
        }

        public bool modificarPack(Pack packAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.modificarPack", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@nroSucursal", packAModificar.Sucursal.NroSucursal));
                cmd.Parameters.Add(
                   new SqlParameter("@idPack", packAModificar.IdPack));
                cmd.Parameters.Add(
                  new SqlParameter("@cantCreditos", packAModificar.CantCreditos));
                cmd.Parameters.Add(
                  new SqlParameter("@diasVigencia", packAModificar.DiasVigencia));
                cmd.Parameters.Add(
                  new SqlParameter("@precio", packAModificar.Precio));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    modificado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return modificado;
        }

        public bool bajaPack(Pack packAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.bajaPack", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idPack", packAEliminar.IdPack));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    baja = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return baja;
        }

        //fin modulo packs

        //inicio modulo profesores

        public bool AltaProfesor(Profesor profesor)
        {
            bool insertado = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.altaProfesor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@nombre", profesor.Nombre));
                cmd.Parameters.Add(
                    new SqlParameter("@apellido", profesor.Apellido));
                cmd.Parameters.Add(
                    new SqlParameter("@email", profesor.Email));
                cmd.Parameters.Add(
                    new SqlParameter("@telefono", profesor.Telefono));


                if (cmd.ExecuteNonQuery() > 0)
                {
                    insertado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return insertado;
        }

        // GET PROFESOR POR ID
        public Profesor GetProfesor(int idProfesor)
        {
            Profesor miProfesor = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.getProfesorPorId", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idProfesor", idProfesor));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miProfesor = new Profesor
                        {
                            IdProfesor = Convert.ToInt32(miLectorDeDatos["idProfesor"]),
                            IdPersona = Convert.ToInt32(miLectorDeDatos["idPersona"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Apellido = miLectorDeDatos["apellido"].ToString(),
                            Email = miLectorDeDatos["email"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Rol = miLectorDeDatos["rol"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                            //@ TO DO falta llenar atributo CREDITOS y HORARIOS
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return miProfesor;
        }

        // GET PROFESOR POR EMAIL
        public Profesor GetProfesorPorEmail(String EmailProfesor)
        {
            Profesor miProfesor = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getProfesorPorEmail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@EmailProfesor", EmailProfesor));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miProfesor = new Profesor
                        {
                            IdProfesor = Convert.ToInt32(miLectorDeDatos["idProfesor"]),
                            IdPersona = Convert.ToInt32(miLectorDeDatos["idPersona"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Apellido = miLectorDeDatos["apellido"].ToString(),
                            Email = miLectorDeDatos["email"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Rol = miLectorDeDatos["rol"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                            //@ TO DO falta llenar atributo CREDITOS y HORARIOS
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return miProfesor;
        }

        public bool ModificarProfesor(Profesor profesorAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.modificarProfesor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idProfesor", profesorAModificar.IdProfesor));
                cmd.Parameters.Add(
                   new SqlParameter("@nombre", profesorAModificar.Nombre));
                cmd.Parameters.Add(
                  new SqlParameter("@apellido", profesorAModificar.Apellido));
                cmd.Parameters.Add(
                  new SqlParameter("@email", profesorAModificar.Email));
                cmd.Parameters.Add(
                  new SqlParameter("@telefono", profesorAModificar.Telefono));

                if (cmd.ExecuteNonQuery() > 0)
                {
                    modificado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return modificado;
        }

        public bool bajaProfesor(Profesor profesorAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.bajaProfesor", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(
                    new SqlParameter("@idProfesor", profesorAEliminar.IdProfesor));
                if (cmd.ExecuteNonQuery() > 0)
                {
                    baja = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return baja;
        }




        //fin modulo profesores





    }
}