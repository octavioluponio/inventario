using luponio_madereras.Models;
using luponio_madereras.Service;
using Microsoft.AspNetCore.Mvc;

namespace luponio_madereras.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly InterfaceProveedorService _proveedorService;

        public ProveedorController(InterfaceProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }


        public async Task<IActionResult> Index()
        {
            var proveedores = await _proveedorService.getProveedores();
            return View(proveedores);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Proveedor nuevoProveedor)
        {
            if (ModelState.IsValid)
            {
                await _proveedorService.addProveedor(nuevoProveedor);
                return RedirectToAction("Index");
            }
            return View(nuevoProveedor);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var proveedores = await _proveedorService.getProveedores();
            var proveedorEncontrado = proveedores.FirstOrDefault(c => c.idproveedor == id);
            if (proveedorEncontrado == null)
            {
                return NotFound();
            }
            return View(proveedorEncontrado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Proveedor updateProveedor)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _proveedorService.updateProveedor(updateProveedor);
                if (resultado == null)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            return View(updateProveedor);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _proveedorService.deleteProveedor(id);
            if (!resultado)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
