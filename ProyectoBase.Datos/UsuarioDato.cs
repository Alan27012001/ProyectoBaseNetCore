using ProyectoBase.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Datos
{
    public class UsuarioDato
    {
        #region Login
        public Usuario ConsultarUsuarioLogin(Usuario usuario)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                Usuario oUsuario = new Usuario();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                cmd = new SqlCommand("SEG_ConsultarUsuarioLogin", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cuenta", usuario.Cuenta);
                cmd.Parameters.AddWithValue("@Contrasena", string.IsNullOrEmpty(usuario.Contrasena) ? "" : usuario.Contrasena);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    oUsuario.ClaveUsuario = Convert.ToInt32(dr["ClaveUsuario"]);
                    oUsuario.Contrasena = string.IsNullOrEmpty(dr["Contrasena"].ToString()) ? string.Empty : dr["Contrasena"].ToString();
                    oUsuario.Activo = Convert.ToBoolean(dr["Activo"]);
                    oUsuario.Cuenta = Convert.ToInt32(dr["Cuenta"]);
                    oUsuario.EsAdmin = Convert.ToBoolean(dr["EsAdmin"]);
                    oUsuario.NombreTrabajador = string.IsNullOrEmpty(dr["NombreTrabajador"].ToString()) ? string.Empty : dr["NombreTrabajador"].ToString();
                    oUsuario.ClaveDepartamento = Convert.ToInt32(dr["ClaveDepartamento"]);
                    oUsuario.NombreDepartamento = string.IsNullOrEmpty(dr["NombreDepartamento"].ToString()) ? string.Empty : dr["NombreDepartamento"].ToString();
                    oUsuario.ClavePerfil = Convert.ToInt32(dr["ClavePerfil"]);
                    oUsuario.NombrePuesto = string.IsNullOrEmpty(dr["NombrePuesto"].ToString()) ? string.Empty : dr["NombrePuesto"].ToString();
                    oUsuario.ClavePuesto = Convert.ToInt32(dr["ClavePuesto"]);
                    oUsuario.ClaveArea = Convert.ToInt32(dr["ClaveArea"]);
                    oUsuario.Correo = string.IsNullOrEmpty(dr["Correo"].ToString()) ? string.Empty : dr["Correo"].ToString();
                    oUsuario.NumeroIntentoLogin = Convert.ToInt32(dr["NumeroIntentoLogin"]);
                    oUsuario.NombrePerfil = string.IsNullOrEmpty(dr["NombrePerfil"].ToString()) ? string.Empty : dr["NombrePerfil"].ToString();
                }
                return oUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public UsuarioBloqueado ConsultarUsuarioBloqueadoPorIntento(UsuarioBloqueado usuarioBloqueado)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                UsuarioBloqueado oUsuarioBloqueado = new UsuarioBloqueado();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                cmd = new SqlCommand("SEG_ConsultarUsuarioBloqueado", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cuenta", usuarioBloqueado.Cuenta);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    oUsuarioBloqueado.ClaveUsuario = Convert.ToInt32(dr["ClaveUsuario"]);
                    oUsuarioBloqueado.Contrasena = string.IsNullOrEmpty(dr["Contrasena"].ToString()) ? string.Empty : dr["Contrasena"].ToString();
                    oUsuarioBloqueado.Activo = Convert.ToBoolean(dr["Activo"]);
                    oUsuarioBloqueado.Cuenta = Convert.ToInt32(dr["Cuenta"]);
                    oUsuarioBloqueado.NumeroIntentoLogin = Convert.ToInt32(dr["NumeroIntentoLogin"]);
                }
                return oUsuarioBloqueado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void GuardarSesionUsuario(Sesion sesion)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEG_GuardarSesionUsuario";
                cmd.Connection = conexion;

                cmd.Parameters.AddWithValue("@IdUsuario", sesion.IdUsuario);
                cmd.Parameters.AddWithValue("@Fecha", sesion.Fecha);

                conexion.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion

        #region Catalogo
        public List<Usuario> ConsultarUsuarios()
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                List<Usuario> lstUsuarios = new List<Usuario>();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                cmd = new SqlCommand("SEG_ConsultarUsuarios", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Usuario oUsuario = new Usuario();

                    oUsuario.ClaveUsuario = Convert.ToInt32(dr["ClaveUsuario"]);
                    oUsuario.Contrasena = string.IsNullOrEmpty(dr["Contrasena"].ToString()) ? string.Empty : dr["Contrasena"].ToString();
                    oUsuario.Activo = Convert.ToBoolean(dr["Activo"]);
                    oUsuario.Cuenta = Convert.ToInt32(dr["Cuenta"]);
                    oUsuario.EsAdmin = Convert.ToBoolean(dr["EsAdmin"]);
                    oUsuario.NombreEstatus = string.IsNullOrEmpty(dr["NombreEstatus"].ToString()) ? string.Empty : dr["NombreEstatus"].ToString();
                    oUsuario.NombreTrabajador = string.IsNullOrEmpty(dr["NombreTrabajador"].ToString()) ? string.Empty : dr["NombreTrabajador"].ToString();
                    oUsuario.ClaveDepartamento = Convert.ToInt32(dr["ClaveDepartamento"]);
                    oUsuario.NombreDepartamento = string.IsNullOrEmpty(dr["NombreDepartamento"].ToString()) ? string.Empty : dr["NombreDepartamento"].ToString();
                    oUsuario.ClavePerfil = Convert.ToInt32(dr["ClavePerfil"]);
                    oUsuario.NombrePuesto = string.IsNullOrEmpty(dr["NombrePuesto"].ToString()) ? string.Empty : dr["NombrePuesto"].ToString();
                    oUsuario.ClavePuesto = Convert.ToInt32(dr["ClavePuesto"]);
                    oUsuario.ClaveArea = Convert.ToInt32(dr["ClaveArea"]);
                    oUsuario.Correo = string.IsNullOrEmpty(dr["Correo"].ToString()) ? string.Empty : dr["Correo"].ToString();
                    oUsuario.NumeroIntentoLogin = Convert.ToInt32(dr["NumeroIntentoLogin"]);
                    oUsuario.NombrePerfil = string.IsNullOrEmpty(dr["NombrePerfil"].ToString()) ? string.Empty : dr["NombrePerfil"].ToString();

                    lstUsuarios.Add(oUsuario);
                }

                return lstUsuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public Usuario ConsultarUsuario(Usuario usuario)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                Usuario oUsuario = new Usuario();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                cmd = new SqlCommand("SEG_ConsultarUsuario", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClaveUsuario", usuario.ClaveUsuario);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    oUsuario.ClaveUsuario = Convert.ToInt32(dr["ClaveUsuario"]);
                    oUsuario.Contrasena = string.IsNullOrEmpty(dr["Contrasena"].ToString()) ? string.Empty : dr["Contrasena"].ToString();
                    oUsuario.Activo = Convert.ToBoolean(dr["Activo"]);
                    oUsuario.Cuenta = Convert.ToInt32(dr["Cuenta"]);
                    oUsuario.EsAdmin = Convert.ToBoolean(dr["EsAdmin"]);
                    oUsuario.NombreEstatus = string.IsNullOrEmpty(dr["NombreEstatus"].ToString()) ? string.Empty : dr["NombreEstatus"].ToString();
                    oUsuario.NombreTrabajador = string.IsNullOrEmpty(dr["NombreTrabajador"].ToString()) ? string.Empty : dr["NombreTrabajador"].ToString();
                    oUsuario.ClaveDepartamento = Convert.ToInt32(dr["ClaveDepartamento"]);
                    oUsuario.NombreDepartamento = string.IsNullOrEmpty(dr["NombreDepartamento"].ToString()) ? string.Empty : dr["NombreDepartamento"].ToString();
                    oUsuario.ClavePerfil = Convert.ToInt32(dr["ClavePerfil"]);
                    oUsuario.NombrePuesto = string.IsNullOrEmpty(dr["NombrePuesto"].ToString()) ? string.Empty : dr["NombrePuesto"].ToString();
                    oUsuario.ClavePuesto = Convert.ToInt32(dr["ClavePuesto"]);
                    oUsuario.ClaveArea = Convert.ToInt32(dr["ClaveArea"]);
                    oUsuario.Correo = string.IsNullOrEmpty(dr["Correo"].ToString()) ? string.Empty : dr["Correo"].ToString();
                    oUsuario.NumeroIntentoLogin = Convert.ToInt32(dr["NumeroIntentoLogin"]);
                    oUsuario.NombrePerfil = string.IsNullOrEmpty(dr["NombrePerfil"].ToString()) ? string.Empty : dr["NombrePerfil"].ToString();
                }
                return oUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void GuardarUsuario(Usuario usuario)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEG_UsuarioUpsert";
                cmd.Connection = conexion;
                cmd.Parameters.AddWithValue("@Clave_usuario", usuario.ClaveUsuario);
                cmd.Parameters.AddWithValue("@Contraseña", usuario.Contrasena);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                cmd.Parameters.AddWithValue("@Cuenta", usuario.Cuenta);
                cmd.Parameters.AddWithValue("@Es_admin", usuario.EsAdmin);
                cmd.Parameters.AddWithValue("@Nombre_trabajador", usuario.NombreTrabajador);
                cmd.Parameters.AddWithValue("@Cla_depto", usuario.ClaveDepartamento == 0 ? DBNull.Value : usuario.ClaveDepartamento);
                //cmd.Parameters.AddWithValue("@Nom_depto", usuario.NombreDepartamento);
                cmd.Parameters.AddWithValue("@Cla_perfil", usuario.ClavePerfil);
                //cmd.Parameters.AddWithValue("@Nom_puesto", usuario.NombrePuesto);
                cmd.Parameters.AddWithValue("@Cla_puesto", usuario.ClavePuesto == 0 ? DBNull.Value : usuario.ClavePuesto);
                cmd.Parameters.AddWithValue("@Cla_area", usuario.ClaveArea == 0 ? DBNull.Value : usuario.ClaveArea);
                //cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                cmd.Parameters.AddWithValue("@Intento_Login", usuario.NumeroIntentoLogin);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void EliminarUsuario(int claveUsuario)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEG_EliminarUsuario";
                cmd.Connection = conexion;
                cmd.Parameters.AddWithValue("@claveUsuario", claveUsuario);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        #endregion
    }
}
