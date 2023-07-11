using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyectoBase.Entidades;
using ProyectoBase.Helpers;
using ProyectoBase.Logica;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProyectoBase.Controllers
{
    public class LoginController : Controller
    {
        protected Constantes constantes = new Constantes();
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ingresar(UsuarioViewModel modelo)
        {
            UsuarioLogica usuarioLogica = new UsuarioLogica();
            Usuario usuario = new Usuario();
            Sesion sesion = new Sesion();
            try
            {
                usuario.Cuenta = modelo.Cuenta;
                usuario.Contrasena = modelo.Contrasena;
                usuario = usuarioLogica.ConsultarUsuario(usuario);

                if(usuario.ClaveUsuario != 0)
                {
                    var identidad = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario.Cuenta) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identidad);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("Cuenta", usuario.Cuenta);

                    //Registrar la Sesion del usuario
                    sesion.IdUsuario = usuario.ClaveUsuario;
                    sesion.Fecha = DateTime.Now;
                    usuarioLogica.GuardarSesionUsuario(sesion);

                    return Redirect("~/Home/Index");
                }
                else
                {
                    constantes.seguridad = new Constantes.Seguridad();
                    ViewBag.Error = constantes.seguridad.cuentaUsuarioContrasena;
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "ERROR: " + ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                return View("Index");
            }
        }

        public IActionResult Salir()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}
