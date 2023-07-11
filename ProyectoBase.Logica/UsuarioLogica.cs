using ProyectoBase.Datos;
using ProyectoBase.Entidades;
using System;
using System.Text;

namespace ProyectoBase.Logica
{
    public class UsuarioLogica
    {
        public Usuario ConsultarUsuario(Usuario usuario)
        {
            UsuarioDato usuarioDato = new UsuarioDato();
            string contrasena = usuario.Contrasena.ToString();
            string resultadoEncriptacion = string.Empty;
            resultadoEncriptacion = Encriptar(contrasena);
            usuario.Contrasena = resultadoEncriptacion;
            return usuarioDato.ConsultarUsuario(usuario);
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
