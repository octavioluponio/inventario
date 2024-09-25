using luponio_madereras.Models;
using Microsoft.EntityFrameworkCore;

namespace luponio_madereras.Service
{
    public class CategoriaService : InterfaceCategoriaService
    {

        private readonly Contexto _contexto;

        public CategoriaService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Categoria> addCategoria(Categoria nuevaCategoria)
        {
            _contexto.Categoria.Add(nuevaCategoria);
            await _contexto.SaveChangesAsync();
            return nuevaCategoria;
        }

        public async Task<bool> deleteCategoria(int id)
        {
            var categoria = await _contexto.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return false;
            }
            _contexto.Categoria.Remove(categoria);
            await _contexto.SaveChangesAsync();
            return true; 
        }

        public async Task<List<Categoria>> getCategorias()
        {
            return await _contexto.Categoria.ToListAsync();
        }

        public async Task<Categoria> updateCategoria(Categoria updateCategoria)
        {
            var categoriaExistente = await _contexto.Categoria.FindAsync(updateCategoria.idCategoria);
            if (categoriaExistente == null)
            {
                return null;
            }
            categoriaExistente.Nombre = updateCategoria.Nombre;
            await _contexto.SaveChangesAsync();
            return categoriaExistente; 
        }
    }

    public interface InterfaceCategoriaService
    {
        Task<Categoria> addCategoria(Categoria nuevaCategoria);
        Task<bool> deleteCategoria(int id);
        Task<Categoria> updateCategoria(Categoria updateCategoria);
        Task<List<Categoria>> getCategorias();
    };
}
