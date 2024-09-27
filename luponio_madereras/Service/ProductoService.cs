using luponio_madereras.Models;
using Microsoft.EntityFrameworkCore;

namespace luponio_madereras.Service
{
    public class ProductoService : InterfaceProductoService
    {

        private readonly Contexto _contexto;

        public ProductoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Producto> addProducto(Producto nuevoProducto)
        {
            _contexto.Producto.Add(nuevoProducto);
            await _contexto.SaveChangesAsync();
            return nuevoProducto;
        }

        public async Task<bool> deleteProducto(int id)
        {
            var Producto = await _contexto.Producto.FindAsync(id);
            if (Producto == null)
            {
                return false;
            }
            _contexto.Producto.Remove(Producto);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<List<Producto>> getProductos()
        {
            return await _contexto.Producto
                .Include(c=>c.Categoria)
                .Include(p=>p.Proveedor)
                .ToListAsync();
        }

        public async Task<Producto> updateProducto(Producto updateProducto)
        {
            var productoExistente = await _contexto.Producto.FindAsync(updateProducto.idproducto);
            if (productoExistente == null)
            {
                return null;
            }
            productoExistente.nombre = updateProducto.nombre;
            productoExistente.stock = updateProducto.stock;
            productoExistente.idcategoria = updateProducto.idcategoria;
            productoExistente.idproveedor = updateProducto.idproveedor;
            await _contexto.SaveChangesAsync();
            return productoExistente;
        }
    }

    public interface InterfaceProductoService
    {
        Task<Producto> addProducto(Producto nuevoProducto);
        Task<bool> deleteProducto(int id);
        Task<Producto> updateProducto(Producto updateProducto);
        Task<List<Producto>> getProductos();

        
        
    };
}
