using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Entidades;
using ProyectoBase.Logica;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Controllers
{
    [Authorize]
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Paises
        public IActionResult Paises()
        {
            //Proceso para menu
            ProcesoMostrarMenu();

            //Obtener nombre de perfil por cuenta
            MostrarNombrePerfilEnMenu();

            return View();
        }
        #endregion

        #region Estados
        public IActionResult Estados()
        {
            //Proceso para menu
            ProcesoMostrarMenu();

            //Obtener nombre de perfil por cuenta
            MostrarNombrePerfilEnMenu();

            return View();
        }
        #endregion

        #region Perfiles
        public IActionResult Perfiles()
        {
            //Proceso para menu
            ProcesoMostrarMenu();

            //Obtener nombre de perfil por cuenta
            MostrarNombrePerfilEnMenu();

            return View();
        }

        public JsonResult ListarPerfil()
        {
            PerfilLogica perfilLogica = new PerfilLogica();
            List<Perfil> lstPerfiles = new List<Perfil>();
            lstPerfiles = perfilLogica.ConsultarPerfiles();
            return Json(new { data = lstPerfiles});
        }

        public JsonResult ConsultarPerfil(PerfilViewModel modelo)
        {
            PerfilLogica perfilLogica = new PerfilLogica();
            Perfil perfil = new Perfil();
            perfil.ClavePerfil = modelo.ClavePerfil;
            perfil = perfilLogica.ConsultarPerfil(perfil);
            return Json(perfil);
        }

        [HttpPost]
        public JsonResult GuardarPerfil(PerfilViewModel oPerfil)
        {
            PerfilLogica perfilLogica = new PerfilLogica();
            Perfil perfil = new Perfil();
            bool respuesta = true;
            if (ModelState.IsValid)
            {
                perfil.ClavePerfil = oPerfil.ClavePerfil;
                perfil.NombrePerfil = oPerfil.NombrePerfil;
                perfil.Descripcion = oPerfil.Descripcion;
                perfilLogica.GuardarPerfil(perfil);
            }
            else
            {
                respuesta = false;
            }
            return Json(new{ resultado = respuesta });
        }

        public JsonResult EliminarPerfil(int clavePerfil)
        {
            bool respuesta = true;
            PerfilLogica perfilLogica = new PerfilLogica();
            try
            {
                perfilLogica.EliminarPerfil(clavePerfil);
            }
            catch
            {
                respuesta = false;
            }
            return Json(new { resultado = respuesta });
        }
        #endregion

        #region Usuarios
        public IActionResult Usuarios()
        {
            //Proceso para menu
            ProcesoMostrarMenu();

            //Obtener nombre de perfil por cuenta
            MostrarNombrePerfilEnMenu();

            //Llenado de combo de Perfiles
            PerfilLogica perfilLogica = new PerfilLogica();
            List<Perfil> lstPerfiles = new List<Perfil>();
            lstPerfiles = perfilLogica.ConsultarPerfiles();
            ViewBag.Perfiles = new SelectList(lstPerfiles, "ClavePerfil", "NombrePerfil");

            return View();
        }

        public JsonResult ListarUsuario()
        {
            UsuarioLogica usuarioLogica = new UsuarioLogica();
            List<Usuario> lstUsuarios = new List<Usuario>();
            lstUsuarios = usuarioLogica.ConsultarUsuarios();
            return Json(new { data = lstUsuarios });
        }

        public JsonResult ConsultarUsuario(UsuarioViewModel modelo)
        {
            UsuarioLogica usuarioLogica = new UsuarioLogica();
            Usuario usuario = new Usuario();
            usuario.ClaveUsuario = modelo.ClaveUsuario;
            usuario = usuarioLogica.ConsultarUsuario(usuario);

            return Json(usuario);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(UsuarioGuardarViewModel oUsuario)
        {
            UsuarioLogica usuarioLogica = new UsuarioLogica();
            Usuario usuario = new Usuario();
            bool respuesta = true;
            if (ModelState.IsValid)
            {
                usuario.ClaveUsuario = oUsuario.ClaveUsuario;
                usuario.Contrasena = oUsuario.Contrasena;
                usuario.Activo = oUsuario.Activo;
                usuario.Cuenta = oUsuario.Cuenta;
                usuario.EsAdmin = oUsuario.EsAdmin;
                usuario.NombreTrabajador = oUsuario.NombreTrabajador;
                usuario.ClaveDepartamento = oUsuario.ClaveDepartamento;
                usuario.NombreDepartamento = oUsuario.NombreDepartamento;
                usuario.ClavePerfil = oUsuario.ClavePerfil;
                usuario.NombrePuesto = oUsuario.NombrePuesto;
                usuario.ClavePuesto = oUsuario.ClavePuesto;
                usuario.ClaveArea = oUsuario.ClaveArea;
                usuario.Correo = oUsuario.Correo;

                usuarioLogica.GuardarUsuario(usuario);
            }
            else
            {
                respuesta = false;
            }
            return Json(new { resultado = respuesta });
        }

        public JsonResult EliminarUsuario(int claveUsuario)
        {
            bool respuesta = true;
            UsuarioLogica usuarioLogica = new UsuarioLogica();
            try
            {
                usuarioLogica.EliminarUsuario(claveUsuario);
            }
            catch
            {
                respuesta = false;
            }
            return Json(new { resultado = respuesta });
        }
        #endregion

        #region Procesos Menu
        public void ProcesoMostrarMenu()
        {
            string json = HttpContext.Session.GetString("json");
            ViewBag.Json = json;
        }

        public void MostrarNombrePerfilEnMenu()
        {
            ViewBag.Perfil = HttpContext.Session.GetString("NombrePerfil");
        }

        #endregion
    }
}
