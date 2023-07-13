using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoBase.Entidades;
using ProyectoBase.Logica;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoBase.Controllers
{
    [Authorize] //Añadir para validacion de Cookies
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MenuLogica menuLogica = new MenuLogica();
            Menu menu = new Menu();

            //Recuperar la cuenta del usuario Logueado
            string cuentaUsuario = HttpContext.Session.GetString("Cuenta");

            if (string.IsNullOrEmpty(cuentaUsuario))
                return RedirectToAction("Index","Seguridad");

            //Consultar menu por perfil de cada usuario
            List<Menu> menuLista = menuLogica.ConsultarMenuPadre(Convert.ToInt32(cuentaUsuario));

            string json = JsonSerializer.Serialize(menuLista);
            ViewBag.Json = json;

            //Guardar Json para otros controller
            HttpContext.Session.SetString("json",json);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
