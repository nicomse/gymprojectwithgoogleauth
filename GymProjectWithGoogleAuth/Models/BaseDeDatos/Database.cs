using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GymProjectWithGoogleAuth.Models.Clases;

namespace GymProjectWithGoogleAuth.Models.BaseDeDatos
{
    public class Database
    {
        public static string DATABASE_NAME = "Taller6";

        // ABRIR LA CONEXIÓN DE LA BASE DE DATOS
        public static SqlConnection AbrirConexion()
        {
            SqlConnection conn;

            try
            {
                conn = new SqlConnection
                {
                    ConnectionString = GetConnectionString()
                };
                conn.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            return conn;
        }

        // CERRAR LA CONEXIÓN DE LA BASE DE DATOS
        public static void CerrarConexion(SqlConnection conn)
        {
            conn.Close();
        }

        // OBTENER LA CADENA DE CONEXIÓN DE LA BASE DE DATOS
        public static String GetConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Database=" + DATABASE_NAME + ";Integrated Security= true";
        }

        // INICIO DEL MÓDULO DE ACTIVIDADES
        public bool AltaActividad(Actividad actividad)
        {
            bool insertado = false;

            try
            {
                SqlConnection conn = AbrirConexion();

                SqlCommand cmd = new SqlCommand("dbo.altaActividad", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nombre", actividad.Nombre));

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

        public bool ModificarActividad(Actividad actividadAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();

                SqlCommand cmd = new SqlCommand("dbo.modificarActividad", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idActividad", actividadAModificar.IdActividad));
                cmd.Parameters.Add(new SqlParameter("@nombre", actividadAModificar.Nombre));

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

        public bool BajaActividad(Actividad actividadAEliminar)
        {
            bool baja = false;

            try
            {
                SqlConnection conn = AbrirConexion();

                SqlCommand cmd = new SqlCommand("dbo.bajaActividad", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idActividad", actividadAEliminar.IdActividad));

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

        public Actividad GetActividad(int idActividad)
        {
            Actividad miActividad = null;

            try
            {
                SqlConnection conn = AbrirConexion();

                SqlCommand cmd = new SqlCommand("dbo.getActividadPorId", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idActividad", idActividad));

                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miActividad = new Actividad
                        {
                            IdActividad = Convert.ToInt32(miLectorDeDatos["idActividad"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
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

        public List<Actividad> GetTodasLasActividades()
        {
            List<Actividad> actividades = new List<Actividad>();
            Actividad actividad;

            try
            {
                SqlConnection conn = AbrirConexion();

                SqlCommand cmd = new SqlCommand("dbo.getTodasLasActividades", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        actividad = new Actividad
                        {
                            IdActividad = Convert.ToInt32(miLectorDeDatos["idActividad"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),
                        };
                        actividades.Add(actividad);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return actividades;
        }
        // FIN DEL MÓDULO DE ACTIVIDADES

        // INICIO DEL MÓDULO DE ALUMNOS
        public bool AltaAlumno(Alumno alumno)
        {
            bool insertado = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.altaAlumno", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nombre", alumno.Nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido", alumno.Apellido));
                cmd.Parameters.Add(new SqlParameter("@email", alumno.Email));
                cmd.Parameters.Add(new SqlParameter("@telefono", alumno.Telefono));

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
                SqlCommand cmd = new SqlCommand("dbo.getAlumnoPorId", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
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
                SqlCommand cmd = new SqlCommand("dbo.getTodosLosAlumnos", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
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

        // BUSCAR ALUMNOS POR EMAIL CON EL OPERADOR LIKE
        public List<Alumno> BuscarAlumnoPorEmail(String EmailAlumno)
        {
            List<Alumno> misAlumnos = new List<Alumno>();
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.buscarAlumnoPorMail", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@email", EmailAlumno));
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
                SqlCommand cmd = new SqlCommand("dbo.getAlumnoPorEmail", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@emailAlumno", EmailAlumno));
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
                SqlCommand cmd = new SqlCommand("dbo.modificarAlumno", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
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
                SqlCommand cmd = new SqlCommand("dbo.bajaAlumno", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idAlumno", alumnoAEliminar.IdAlumno));
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
        // FIN MODULO ALUMNOS

        // INICIO MODULO SUCURSALES

        public bool AltaSucursal(Sucursal sucursal)
        {
            bool insertado = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.altaSucursal", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@barrio", sucursal.Barrio));
                cmd.Parameters.Add(new SqlParameter("@direccion", sucursal.Direccion));
                cmd.Parameters.Add(new SqlParameter("@telefono", sucursal.Telefono));

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

        // GET SUCURSAL
        public Sucursal GetSucursal(int numeroSucursal)
        {
            Sucursal sucursal = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getSucursalPorId", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nroSucursal", numeroSucursal));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        sucursal = new Sucursal
                        {
                            NroSucursal = Convert.ToInt32(miLectorDeDatos["nroSucursal"]),
                            Barrio = miLectorDeDatos["barrio"].ToString(),
                            Direccion = miLectorDeDatos["direccion"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                            // PACKS ?
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return sucursal;
        }

        //OBTENER TODAS LAS SUCURSALES

        public List<Sucursal> GetTodasLasSucursales()
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            Sucursal sucursal;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getTodasLasSucursales", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        sucursal = new Sucursal
                        {
                            NroSucursal = Convert.ToInt32(miLectorDeDatos["nroSucursal"]),
                            Barrio = miLectorDeDatos["barrio"].ToString(),
                            Direccion = miLectorDeDatos["direccion"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),

                            // PACKS ?
                        };
                        sucursales.Add(sucursal);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return sucursales;
        }

        // MODIFICAR SUCURSAL

        public bool ModificarSucursal(Sucursal sucursalAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.modificarSucursal", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nroSucursal", sucursalAModificar.NroSucursal));
                cmd.Parameters.Add(new SqlParameter("@barrio", sucursalAModificar.Barrio));
                cmd.Parameters.Add(new SqlParameter("@direccion", sucursalAModificar.Direccion));
                cmd.Parameters.Add(new SqlParameter("@telefono", sucursalAModificar.Telefono));

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

        public bool BajaSucursal(Sucursal sucursalAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand(
                    "dbo.bajaSucursal", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
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

        // FIN MODULO SUCURSALES

        // INICIO MODULO PACKS
        public bool AltaPack(Pack pack)
        {
            bool insertado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.altaPack", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nroSucursal", pack.Sucursal.NroSucursal));
                cmd.Parameters.Add(new SqlParameter("@cantCreditos", pack.CantCreditos));
                cmd.Parameters.Add(new SqlParameter("@diasVigencia", pack.DiasVigencia));
                cmd.Parameters.Add(new SqlParameter("@precio", pack.Precio));

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

        public List<Pack> GetTodosLosPacks()
        {
            List<Pack> packs = new List<Pack>();
            Pack pack;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getTodosLosPacks", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        pack = new Pack
                        {
                            IdPack = Convert.ToInt32(miLectorDeDatos["idPack"]),
                            Sucursal = GetSucursal(Convert.ToInt32(miLectorDeDatos["nroSucursal"])),
                            CantCreditos = Convert.ToInt32(miLectorDeDatos["cantCreditos"]),
                            DiasVigencia = Convert.ToInt32(miLectorDeDatos["diasVigencia"]),
                            Precio = float.Parse(miLectorDeDatos["precio"].ToString()),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),
                        };
                        packs.Add(pack);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return packs;
        }

        public Pack GetPack(int idPack)
        {
            Pack miPack = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getPackPorId", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idPack", idPack));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        miPack = new Pack
                        {
                            IdPack = Convert.ToInt32(miLectorDeDatos["idPack"]),
                            Sucursal = GetSucursal(Convert.ToInt32(miLectorDeDatos["nroSucursal"])),
                            CantCreditos = Convert.ToInt32(miLectorDeDatos["cantCreditos"]),
                            DiasVigencia = Convert.ToInt32(miLectorDeDatos["diasVigencia"]),
                            Precio = float.Parse(miLectorDeDatos["precio"].ToString()),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),
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

        public bool ModificarPack(Pack packAModificar)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.modificarPack", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nroSucursal", packAModificar.Sucursal.NroSucursal));
                cmd.Parameters.Add(new SqlParameter("@idPack", packAModificar.IdPack));
                cmd.Parameters.Add(new SqlParameter("@cantCreditos", packAModificar.CantCreditos));
                cmd.Parameters.Add(new SqlParameter("@diasVigencia", packAModificar.DiasVigencia));
                cmd.Parameters.Add(new SqlParameter("@precio", packAModificar.Precio));

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

        public bool BajaPack(Pack packAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.bajaPack", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idPack", packAEliminar.IdPack));

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

        // FIN MODULO PACKS

        // INICIO MODULO PROFESORES

        public bool AltaProfesor(Profesor profesor)
        {
            bool insertado = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.altaProfesor", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@nombre", profesor.Nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido", profesor.Apellido));
                cmd.Parameters.Add(new SqlParameter("@email", profesor.Email));
                cmd.Parameters.Add(new SqlParameter("@telefono", profesor.Telefono));

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

        // BUSCAR PROFESORES POR EMAIL CON EL OPERADOR LIKE
        public List<Profesor> BuscarProfesorPorEmail(String EmailProfesor)
        {
            List<Profesor> misProfesores = new List<Profesor>();
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.buscarProfesorPorMail", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@email", EmailProfesor));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        Profesor miProfesor = new Profesor
                        {
                            IdProfesor = Convert.ToInt32(miLectorDeDatos["idProfesor"]),
                            IdPersona = Convert.ToInt32(miLectorDeDatos["idPersona"]),
                            Nombre = miLectorDeDatos["nombre"].ToString(),
                            Apellido = miLectorDeDatos["apellido"].ToString(),
                            Email = miLectorDeDatos["email"].ToString(),
                            Telefono = miLectorDeDatos["telefono"].ToString(),
                            Rol = miLectorDeDatos["rol"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),
                        };
                        misProfesores.Add(miProfesor);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return misProfesores;
        }

        // GET PROFESOR POR ID
        public Profesor GetProfesor(int idProfesor)
        {
            Profesor miProfesor = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getProfesorPorId", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idProfesor", idProfesor));
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

        //OBTENER TODOS LOS PROFESORES

        public List<Profesor> GetTodosLosProfesores()
        {
            List<Profesor> misProfesores = new List<Profesor>();
            Profesor miProfesor;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getTodosLosProfesores", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
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
                        };
                        misProfesores.Add(miProfesor);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return misProfesores;
        }

        // GET PROFESOR POR EMAIL
        public Profesor GetProfesorPorEmail(String EmailProfesor)
        {
            Profesor miProfesor = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getProfesorPorEmail", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
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
                SqlCommand cmd = new SqlCommand("dbo.modificarProfesor", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idProfesor", profesorAModificar.IdProfesor));
                cmd.Parameters.Add(new SqlParameter("@nombre", profesorAModificar.Nombre));
                cmd.Parameters.Add(new SqlParameter("@apellido", profesorAModificar.Apellido));
                cmd.Parameters.Add(new SqlParameter("@email", profesorAModificar.Email));
                cmd.Parameters.Add(new SqlParameter("@telefono", profesorAModificar.Telefono));

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

        public bool BajaProfesor(Profesor profesorAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.bajaProfesor", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idProfesor", profesorAEliminar.IdProfesor));

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

        //FIN MODULO PROFESORES

        // INICIO MODULO HORARIOS

        public Horario GetHorario(int idHorario)
        {
            Horario horario = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getHorarioPorId", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idHorario", idHorario));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        horario = new Horario
                        {
                            IdHorario = Convert.ToInt32(miLectorDeDatos["idHorario"]),
                            Actividad = GetActividad(Convert.ToInt32(miLectorDeDatos["idActividad"])),
                            Profesor = GetProfesor(Convert.ToInt32(miLectorDeDatos["idProfesor"])),
                            Sucursal = GetSucursal(Convert.ToInt32(miLectorDeDatos["nroSucursal"])),
                            // alumnos ??
                            HoraInicio = Convert.ToDateTime(miLectorDeDatos["horaInicio"]),
                            HoraFin = Convert.ToDateTime(miLectorDeDatos["horaFin"]),
                            Dia = miLectorDeDatos["dia"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),
                        };
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return horario;
        }

        public List<Horario> GetTodosLosHorarios()
        {
            List<Horario> horarios = new List<Horario>();
            Horario horario;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getTodosLosHorarios", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        horario = new Horario
                        {
                            IdHorario = Convert.ToInt32(miLectorDeDatos["idHorario"]),
                            Actividad = GetActividad(Convert.ToInt32(miLectorDeDatos["idActividad"])),
                            Profesor = GetProfesor(Convert.ToInt32(miLectorDeDatos["idProfesor"])),
                            Sucursal = GetSucursal(Convert.ToInt32(miLectorDeDatos["nroSucursal"])),
                            // alumnos ??
                            HoraInicio = Convert.ToDateTime(miLectorDeDatos["horaInicio"]),
                            HoraFin = Convert.ToDateTime(miLectorDeDatos["horaFin"]),
                            Dia = miLectorDeDatos["dia"].ToString(),
                            Estado = Convert.ToInt32(miLectorDeDatos["estado"]),
                        };
                        horarios.Add(horario);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return horarios;
        }

        public bool AltaHorario(Horario horario)
        {
            bool insertado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.altaHorario", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idActividad", horario.Actividad.IdActividad));
                cmd.Parameters.Add(new SqlParameter("@idProfesor", horario.Profesor.IdProfesor));
                cmd.Parameters.Add(new SqlParameter("@nroSucursal", horario.Sucursal.NroSucursal));
                cmd.Parameters.Add(new SqlParameter("@horaInicio", horario.HoraInicio));
                cmd.Parameters.Add(new SqlParameter("@horaFin", horario.HoraFin));
                cmd.Parameters.Add(new SqlParameter("@dia", horario.Dia));

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

        public bool ModificarHorario(Horario horario)
        {
            bool modificado = false;

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.modificarHorario", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idActividad", horario.Actividad.IdActividad));
                cmd.Parameters.Add(new SqlParameter("@idProfesor", horario.Profesor.IdProfesor));
                cmd.Parameters.Add(new SqlParameter("@nroSucursal", horario.Sucursal.NroSucursal));
                cmd.Parameters.Add(new SqlParameter("@horaInicio", horario.HoraInicio));
                cmd.Parameters.Add(new SqlParameter("@horaFin", horario.HoraFin));
                cmd.Parameters.Add(new SqlParameter("@dia", horario.Dia));

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

        public bool BajaHorario(Horario horarioAEliminar)
        {
            bool baja = false;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.bajaHorario", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@idHorario", horarioAEliminar.IdHorario));

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

        // FIN MODULO HORARIOS

        // INICIO MODULO PERSONAS
        public Persona GetPersonaPorEmail(String emailPersona)
        {
            Persona miPersona = null;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.buscarPersonaPorMail", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@email", emailPersona));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    while (miLectorDeDatos.Read())
                    {
                        miPersona = new Persona
                        {
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

                return miPersona;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // FIN MODULO PERSONAS

        // INICIO MODULO ADMINISTRADOR

        public bool AltaAdministrador(String email)
        {
            bool insertado = false;
            Persona admin = new Persona
            {
                Email = email
            };
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.altaAdministrador", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.Add(new SqlParameter("@email", admin.Email));

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

        public int DameCantPersonas()
        {
            int count;
            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Personas", conn);
                count = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }

            return count;
        }

        // FIN MODULO ADMINISTRADOR

        public bool TienePermisoBuscado(Persona persona, String rolABuscar)
        {
            SqlConnection conn = AbrirConexion();
            SqlCommand cmd = new SqlCommand("dbo.tieneRolAsignado", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add(new SqlParameter("@idPersona", persona.IdPersona));
            cmd.Parameters.Add(new SqlParameter("@nombreRol", rolABuscar));
            SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

            bool tienePermiso = false;

            if (miLectorDeDatos.HasRows)
            {
                while (miLectorDeDatos.Read())
                {
                    tienePermiso = true;
                }
            }
            return tienePermiso;
        }

        public String GetRolPersona(String email)
        {
            String rol = "";

            try
            {
                SqlConnection conn = AbrirConexion();
                SqlCommand cmd = new SqlCommand("dbo.getRolPersona", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@email", email));
                SqlDataReader miLectorDeDatos = cmd.ExecuteReader();

                if (miLectorDeDatos.HasRows)
                {
                    if (miLectorDeDatos.Read())
                    {
                        rol = miLectorDeDatos["rol"].ToString();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return rol;
        }


    }
}