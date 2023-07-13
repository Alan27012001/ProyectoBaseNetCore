using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Entidades
{
    public class Menu
    {
        public int IdMenu { get; set; }
        public string Descripcion { get; set; }
        public int? IdModulo { get; set; }
        public string Url { get; set; }
        public int IdPerfil { get; set; }
        public ICollection<Menu> CollectionMenu { get; set; }
        public List<SubMenu> SubMenu { get; set; }
    }
}
