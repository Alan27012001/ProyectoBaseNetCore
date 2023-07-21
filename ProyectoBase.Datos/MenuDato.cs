using ProyectoBase.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Datos
{
    public class MenuDato
    {
        public List<Menu> ConsultarMenuPadre(int cuentaUsuario)
        {
            SqlConnection conexion = null;
            List<Menu> lstMenuResultado = new List<Menu>();
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
                List<Menu> lstMenu = new List<Menu>();
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                cmd = new SqlCommand("SEG_ConsultarMenuPadre", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cuenta", cuentaUsuario);
                conexion.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Menu oMenu = new Menu();

                    oMenu.IdMenu = Convert.ToInt32(dr["IdMenu"]);
                    oMenu.Descripcion = string.IsNullOrEmpty(dr["Descripcion"].ToString()) ? string.Empty : dr["Descripcion"].ToString();
                    oMenu.IdPerfil = Convert.ToInt32(dr["IdPerfil"]);

                    lstMenu.Add(oMenu);
                }
                
                lstMenuResultado = ConsultarSubMenu(lstMenu);

                return lstMenuResultado;
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

        public List<Menu> ConsultarSubMenu(List<Menu> oMenu)
        {
            SqlConnection conexion = null;       
            try
            {
                conexion = Conexion.obtenerInstancias().conexionBaseDatos();
               
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                foreach (var item in oMenu)
                {
                    //Obtener los SubMenu
                    cmd = new SqlCommand("SEG_ConsultarSubMenuPorModulo", conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdModulo", item.IdMenu);
                    cmd.Parameters.AddWithValue("@IdPerfil", item.IdPerfil);
                    conexion.Open();
                    dr = cmd.ExecuteReader();
                    item.SubMenu = new List<SubMenu>();
                    while (dr.Read())
                    {
                        SubMenu oSubMenu = new SubMenu();

                        oSubMenu.IdMenu = Convert.ToInt32(dr["IdMenu"]);
                        oSubMenu.IdModulo = Convert.ToInt32(dr["IdModulo"]);
                        oSubMenu.Menu = string.IsNullOrEmpty(dr["Menu"].ToString()) ? string.Empty : dr["Menu"].ToString();
                        oSubMenu.Url = string.IsNullOrEmpty(dr["Url"].ToString()) ? string.Empty : dr["Url"].ToString();
                        oSubMenu.IdPerfil = Convert.ToInt32(dr["IdPerfil"]);
                        oSubMenu.NombrePerfil = string.IsNullOrEmpty(dr["NombrePerfil"].ToString()) ? string.Empty : dr["NombrePerfil"].ToString();

                        item.SubMenu.Add(oSubMenu);
                    }
                    conexion.Close();
                }
                return oMenu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
