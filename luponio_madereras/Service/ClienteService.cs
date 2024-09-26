using luponio_madereras.Models;
using Microsoft.EntityFrameworkCore;

namespace luponio_madereras.Service
{
    public class ClienteService : InterfaceClienteService
    {

        private readonly Contexto _contexto;

        public ClienteService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<Cliente> addCliente(Cliente nuevoCliente)
        {
            _contexto.Cliente.Add(nuevoCliente);
            await _contexto.SaveChangesAsync();
            return nuevoCliente;
        }

        public async Task<bool> deleteCliente(int id)
        {
            var cliente = await _contexto.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return false;
            }
            _contexto.Cliente.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cliente>> getClientes()
        {
            return await _contexto.Cliente.ToListAsync();
        }

        public async Task<Cliente> updateCliente(Cliente updateCliente)
        {
            var clienteExistente = await _contexto.Cliente.FindAsync(updateCliente.idcliente);
            if (clienteExistente == null)
            {
                return null;
            }
            clienteExistente.nombre = updateCliente.nombre;
            clienteExistente.direccion = updateCliente.direccion;
            clienteExistente.telefono = updateCliente.telefono;
            clienteExistente.email = updateCliente.email;
            await _contexto.SaveChangesAsync();
            return clienteExistente;
        }
    }

    public interface InterfaceClienteService
    {
        Task<Cliente> addCliente(Cliente nuevoCliente);
        Task<bool> deleteCliente(int id);
        Task<Cliente> updateCliente(Cliente updateCliente);
        Task<List<Cliente>> getClientes();
    };
}