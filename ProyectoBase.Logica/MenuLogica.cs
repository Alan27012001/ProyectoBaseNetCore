using ProyectoBase.Datos;
using ProyectoBase.Entidades;
using System;
using System.Collections.Generic;

namespace ProyectoBase.Logica
{
    public class MenuLogica
    {
        MenuDato menuDato;
        public List<Menu> ConsultarMenuPadre(int cuentaUsuario)
        {
            menuDato = new MenuDato();
            return menuDato.ConsultarMenuPadre(cuentaUsuario);
        }
    }
}
