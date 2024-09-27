using luponio_madereras.Models;
using Microsoft.EntityFrameworkCore;

namespace luponio_madereras.Service
{
    public class UsuarioService : InterfaceUsuarioService
    {
        private readonly Contexto _contexto;

        public UsuarioService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> login(Usuario usuario)
        {

            var usuarioExiste = await _contexto.Usuario.FirstOrDefaultAsync(x=>x.nombre.Equals(usuario.nombre) && x.password.Equals(usuario.password));
            if (usuarioExiste != null)
            {
                return true;
            }
            return false;
        }
    }

    public interface InterfaceUsuarioService
    {
        Task<bool> login(Usuario usuario);
    };
}
