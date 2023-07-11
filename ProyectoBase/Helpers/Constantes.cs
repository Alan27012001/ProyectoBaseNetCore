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
            public string cuentaBloqueadaUsuario = "Tu cuenta se encuentra bloqueada debido al exceso de Intentos(5), Favor de Comunicarse con el Area de TI.";

        }
        #endregion
    }
}
