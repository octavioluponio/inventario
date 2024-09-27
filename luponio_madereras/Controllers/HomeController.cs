using System.Diagnostics;
using luponio_madereras.Models;
using luponio_madereras.Service;
using Microsoft.AspNetCore.Mvc;

namespace luponio_madereras.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InterfaceUsuarioService _usuarioService;
        public HomeController(ILogger<HomeController> logger,InterfaceUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var usuarioExiste = await _usuarioService.login(usuario);
            if(usuarioExiste)
                return RedirectToAction("Index", "Cliente");
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
