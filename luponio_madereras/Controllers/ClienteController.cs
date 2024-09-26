using luponio_madereras.Models;
using luponio_madereras.Service;
using Microsoft.AspNetCore.Mvc;

namespace luponio_madereras.Controllers
{
    public class ClienteController : Controller
    {
        private readonly InterfaceClienteService _clienteService;

        public ClienteController(InterfaceClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.getClientes();
            return View(clientes);
        }

        // Acción para agregar una nueva categoría
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente nuevoCliente)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.addCliente(nuevoCliente);
                return RedirectToAction("Index");
            }
            return View(nuevoCliente);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var clientes = await _clienteService.getClientes();
            var clienteEncontrado = clientes.FirstOrDefault(c => c.idcliente == id);
            if (clienteEncontrado == null)
            {
                return NotFound();
            }
            return View(clienteEncontrado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cliente updateCliente)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _clienteService.updateCliente(updateCliente);
                if (resultado == null)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            return View(updateCliente);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _clienteService.deleteCliente(id);
            if (!resultado)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
