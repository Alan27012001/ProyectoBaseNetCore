using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Paises()
        {
            //Proceso para menu
            ProcesoMostrarMenu();

            return View();
        }

        public IActionResult Estados()
        {
            //Proceso para menu
            ProcesoMostrarMenu();

            return View();
        }

        #region Perfiles
        public IActionResult Perfiles()
        {
            //Proceso para menu
            ProcesoMostrarMenu();
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

        public void ProcesoMostrarMenu()
        {
            string json = HttpContext.Session.GetString("json");
            ViewBag.Json = json;
        }
    }
}
