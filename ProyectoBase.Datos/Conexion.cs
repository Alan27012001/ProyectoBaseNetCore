using System;
using System.Data.SqlClient;

namespace ProyectoBase.Datos
{
    public class Conexion
    {
        #region PATRON SINGLETON
        private static Conexion instancia = null;
        public Conexion() { }
        public static Conexion obtenerInstancias()
        {
            if (instancia == null)
                instancia = new Conexion();

            return instancia;
        }
        #endregion

        public SqlConnection conexionBaseDatos()
        {
            try
            {
                var conexion = new SqlConnection();
                conexion.ConnectionString = @"Data Source=den1.mssql7.gear.host;initial catalog=proyectonetcore;User ID=proyectonetcore;Password=Mo0h_x5B4-4R;";
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
