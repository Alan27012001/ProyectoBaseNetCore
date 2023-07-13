using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Entidades
{
    public class SubMenu
    {
        public int IdMenu { get; set; }
        public int IdModulo { get; set; }
        public string Menu { get; set; }
        public string Url { get; set; }
        public int IdPerfil { get; set; }
        public string NombrePerfil { get; set; }
    }
}
