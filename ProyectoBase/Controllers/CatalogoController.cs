using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public void ProcesoMostrarMenu()
        {
            string json = HttpContext.Session.GetString("json");
            ViewBag.Json = json;
        }
    }
}
