using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Entidades
{
    public class UsuarioBloqueado
    {
        public int ClaveUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
        public int Cuenta { get; set; }
        public int NumeroIntentoLogin { get; set; }
        public DateTime FechaBloqueo { get; set; }

    }
}
