using luponio_madereras.Models;
using Microsoft.EntityFrameworkCore;

namespace luponio_madereras.Service
{
    public class ProveedorService : InterfaceProveedorService
    {

        private readonly Contexto _contexto;

        public ProveedorService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Proveedor> addProveedor(Proveedor nuevoProveedor)
        {
            _contexto.Proveedor.Add(nuevoProveedor);
            await _contexto.SaveChangesAsync();
            return nuevoProveedor;
        }

        public async Task<bool> deleteProveedor(int id)
        {
            var proveedor = await _contexto.Proveedor.FindAsync(id);
            if (proveedor == null)
            {
                return false;
            }
            _contexto.Proveedor.Remove(proveedor);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<List<Proveedor>> getProveedores()
        {
            return await _contexto.Proveedor.ToListAsync();
        }

        public async Task<Proveedor> updateProveedor(Proveedor updateProveedor)
        {
            var proveedorExistente = await _contexto.Proveedor.FindAsync(updateProveedor.idproveedor);
            if (proveedorExistente == null)
            {
                return null;
            }
            proveedorExistente.nombre = updateProveedor.nombre;
            proveedorExistente.direccion = updateProveedor.direccion;
            proveedorExistente.telefono = updateProveedor.telefono;
            proveedorExistente.email = updateProveedor.email;
            await _contexto.SaveChangesAsync();
            return proveedorExistente;
        }
    }

    public interface InterfaceProveedorService
    {
        Task<Proveedor> addProveedor(Proveedor nuevoProveedor);
        Task<bool> deleteProveedor(int id);
        Task<Proveedor> updateProveedor(Proveedor updateProveedor);
        Task<List<Proveedor>> getProveedores();
    };
}
