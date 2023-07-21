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
    public class PerfilDato
    {
        public List<Perfil> ConsultarPerfiles()
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                List<Perfil> lstPerfiles = new List<Perfil>();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                cmd = new SqlCommand("SEG_ConsultarPerfiles", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Perfil oPerfil = new Perfil();

                    oPerfil.ClavePerfil = Convert.ToInt32(dr["ClavePerfil"]);
                    oPerfil.NombrePerfil = string.IsNullOrEmpty(dr["NombrePerfil"].ToString()) ? string.Empty : dr["NombrePerfil"].ToString();
                    oPerfil.Descripcion = string.IsNullOrEmpty(dr["Descripcion"].ToString()) ? string.Empty : dr["Descripcion"].ToString();

                    lstPerfiles.Add(oPerfil);
                }

                return lstPerfiles;
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

        public Perfil ConsultarPerfil(Perfil perfil)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                Perfil oPerfil = new Perfil();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                cmd = new SqlCommand("SEG_ConsultarPerfilPorClavePerfil", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClavePerfil", perfil.ClavePerfil);
                conexion.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    oPerfil.ClavePerfil = Convert.ToInt32(dr["ClavePerfil"]);
                    oPerfil.NombrePerfil = string.IsNullOrEmpty(dr["NombrePerfil"].ToString()) ? string.Empty : dr["NombrePerfil"].ToString();
                    oPerfil.Descripcion = string.IsNullOrEmpty(dr["Descripcion"].ToString()) ? string.Empty : dr["Descripcion"].ToString();
                }
                return oPerfil;
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

        public void GuardarPerfil(Perfil perfil)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEG_PerfilUpsert";
                cmd.Connection = conexion;
                cmd.Parameters.AddWithValue("@ClavePerfil", perfil.ClavePerfil);
                cmd.Parameters.AddWithValue("@Nombre", perfil.NombrePerfil);
                cmd.Parameters.AddWithValue("@Descripcion", perfil.Descripcion);
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

        public void EliminarPerfil(int clavePerfil)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEG_EliminarPerfil";
                cmd.Connection = conexion;
                cmd.Parameters.AddWithValue("@ClavePerfil", clavePerfil);
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
