using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Helpers
{
    public class Constantes
    {
        public const string Clase = "Constantes";

        public Seguridad seguridad { get; set; }

        #region Seguridad
        public partial class Seguridad
        {
            public string cuentaUsuarioContrasena = "Cuenta y/o contraseña incorrectos";
        }
        #endregion
    }
}
