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
                cmd.Parameters.AddWithValue("@Cuenta", string.IsNullOrEmpty(usuario.Cuenta) ? "" : usuario.Cuenta);
                cmd.Parameters.AddWithValue("@Contrasena", string.IsNullOrEmpty(usuario.Contrasena) ? "" : usuario.Contrasena);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    oUsuario.ClaveUsuario = Convert.ToInt32(dr["ClaveUsuario"]);
                    oUsuario.Contrasena = string.IsNullOrEmpty(dr["Contrasena"].ToString()) ? string.Empty : dr["Contrasena"].ToString();
                    oUsuario.Activo = Convert.ToBoolean(dr["Activo"]);
                    oUsuario.Cuenta = string.IsNullOrEmpty(dr["Cuenta"].ToString()) ? string.Empty : dr["Cuenta"].ToString();
                    oUsuario.EsAdmin = Convert.ToBoolean(dr["EsAdmin"]);
                    oUsuario.NombreTrabajador = string.IsNullOrEmpty(dr["NombreTrabajador"].ToString()) ? string.Empty : dr["NombreTrabajador"].ToString();
                    oUsuario.ClaveDepartamento = Convert.ToInt32(dr["ClaveDepartamento"]);
                    oUsuario.NombreDepartamento = string.IsNullOrEmpty(dr["NombreDepartamento"].ToString()) ? string.Empty : dr["NombreDepartamento"].ToString();
                    oUsuario.ClavePerfil = Convert.ToInt32(dr["ClavePerfil"]);
                    oUsuario.NombrePuesto = string.IsNullOrEmpty(dr["NombrePuesto"].ToString()) ? string.Empty : dr["NombrePuesto"].ToString();
                    oUsuario.ClavePuesto = Convert.ToInt32(dr["ClavePuesto"]);
                    oUsuario.ClaveArea = Convert.ToInt32(dr["ClaveArea"]);
                    oUsuario.Correo = string.IsNullOrEmpty(dr["Correo"].ToString()) ? string.Empty : dr["Correo"].ToString();
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
    }
}
