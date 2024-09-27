using luponio_madereras.Models;
using luponio_madereras.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace luponio_madereras.Controllers
{
    public class ProductoController : Controller
    {
        private readonly InterfaceProductoService _productoService;
        private readonly InterfaceCategoriaService _categoriaService;
        private readonly InterfaceProveedorService _proveedorService;


        public ProductoController(InterfaceProductoService productoService,InterfaceCategoriaService categoriaService,
            InterfaceProveedorService proveedorService)
        {
            _productoService = productoService;
            _categoriaService = categoriaService;
            _proveedorService = proveedorService;
        }


        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.getProductos();
            return View(productos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaService.getCategorias();
            var proveedores = await _proveedorService.getProveedores();

            ViewBag.Categorias = new SelectList(categorias, "idCategoria", "Nombre");
            ViewBag.Proveedores = new SelectList(proveedores, "idproveedor", "nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto nuevoProducto)
        {
            if (ModelState.IsValid)
            {
                await _productoService.addProducto(nuevoProducto);
                return RedirectToAction("Index");
            }
            return View(nuevoProducto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var productos = await _productoService.getProductos();
            var productoEncontrado = productos.FirstOrDefault(c => c.idproducto == id);
            if (productoEncontrado == null)
            {
                return NotFound();
            }
            var categorias = await _categoriaService.getCategorias();
            var proveedores = await _proveedorService.getProveedores();

            ViewBag.Categorias = new SelectList(categorias, "idCategoria", "Nombre");
            ViewBag.Proveedores = new SelectList(proveedores, "idproveedor", "nombre");
            return View(productoEncontrado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto updateProducto)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _productoService.updateProducto(updateProducto);
                if (resultado == null)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            return View(updateProducto);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _productoService.deleteProducto(id);
            if (!resultado)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
