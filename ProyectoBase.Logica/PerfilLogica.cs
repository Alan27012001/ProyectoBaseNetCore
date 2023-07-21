using ProyectoBase.Datos;
using ProyectoBase.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Logica
{
    public class PerfilLogica
    {
        PerfilDato perfilDato;
        public List<Perfil> ConsultarPerfiles()
        {
            perfilDato = new PerfilDato();
            return perfilDato.ConsultarPerfiles();
        }

        public Perfil ConsultarPerfil(Perfil perfil)
        {
            perfilDato = new PerfilDato();
            return perfilDato.ConsultarPerfil(perfil);
        }

        public void GuardarPerfil(Perfil perfil)
        {
            perfilDato = new PerfilDato();
            perfilDato.GuardarPerfil(perfil);
        }

        public void EliminarPerfil(int clavePerfil)
        {
            if(clavePerfil != 0)
            {
                perfilDato = new PerfilDato();
                perfilDato.EliminarPerfil(clavePerfil);
            }
        }
    }
}
