using luponio_madereras.Models;
using luponio_madereras.Service;
using Microsoft.AspNetCore.Mvc;

namespace luponio_madereras.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly InterfaceCategoriaService _categoriaService;

        public CategoriaController(InterfaceCategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

       
        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.getCategorias();
            return View(categorias);
        }

        // Acción para agregar una nueva categoría
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria nuevaCategoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.addCategoria(nuevaCategoria);
                return RedirectToAction("Index");
            }
            return View(nuevaCategoria);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categorias = await _categoriaService.getCategorias();
            var categoriaEncontrada = categorias.FirstOrDefault(c => c.idCategoria == id);
            if (categoriaEncontrada == null)
            {
                return NotFound();
            }
            return View(categoriaEncontrada);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria updateCategoria)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _categoriaService.updateCategoria(updateCategoria);
                if (resultado == null)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            return View(updateCategoria);
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _categoriaService.deleteCategoria(id);
            if (!resultado)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
