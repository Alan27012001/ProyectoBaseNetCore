using ProyectoBase.Datos;
using ProyectoBase.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoBase.Logica
{
    public class UsuarioLogica
    {
        UsuarioDato usuarioDato;
        public Usuario ConsultarUsuarioLogin(Usuario usuario)
        {
            usuarioDato = new UsuarioDato();
            string contrasena = usuario.Contrasena.ToString();
            string resultadoEncriptacion = string.Empty;
            resultadoEncriptacion = Encriptar(contrasena);
            usuario.Contrasena = resultadoEncriptacion;
            return usuarioDato.ConsultarUsuarioLogin(usuario);
        }

        public UsuarioBloqueado ConsultarUsuarioBloqueadoPorIntento(UsuarioBloqueado usuarioBloqueado)
        {
            usuarioDato = new UsuarioDato();
            return usuarioDato.ConsultarUsuarioBloqueadoPorIntento(usuarioBloqueado);
        }

        public void GuardarSesionUsuario(Sesion sesion)
        {
            if (sesion != null)
            {
                usuarioDato = new UsuarioDato();
                usuarioDato.GuardarSesionUsuario(sesion);
            }           
        }

        public List<Usuario> ConsultarUsuarios()
        {
            usuarioDato = new UsuarioDato();
            return usuarioDato.ConsultarUsuarios();
        }

        public Usuario ConsultarUsuario(Usuario usuario)
        {
            usuarioDato = new UsuarioDato();
            Usuario oUsuario = usuarioDato.ConsultarUsuario(usuario);
            string contrasenaDesencriptada = Desencriptar(oUsuario.Contrasena);
            oUsuario.Contrasena = contrasenaDesencriptada;
            return oUsuario;
        }

        public void GuardarUsuario(Usuario usuario)
        {
            usuarioDato = new UsuarioDato();
            if (!string.IsNullOrEmpty(usuario.Contrasena))
            {
                string contrasenaEncriptada = Encriptar(usuario.Contrasena);
                usuario.Contrasena = contrasenaEncriptada;
            }
            usuarioDato.GuardarUsuario(usuario);
        }

        public void EliminarUsuario(int claveUsuario)
        {
            if (claveUsuario != 0)
            {
                usuarioDato = new UsuarioDato();
                usuarioDato.EliminarUsuario(claveUsuario);
            }
        }

        public string Encriptar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return null;

            byte[] bytes = Encoding.UTF8.GetBytes(texto); 
            return Convert.ToBase64String(bytes);
        }

        public string Desencriptar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return null;

            byte[] bytes = Convert.FromBase64String(texto);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
