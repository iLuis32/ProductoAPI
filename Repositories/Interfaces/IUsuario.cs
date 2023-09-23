using ProductoAPI.DTOs;

namespace ProductoAPI.Repositories.Interfaces
{
    public interface IUsuario
    {
        Task<UsuarioDTO> Login(UsuarioLogin usuario);

        string GenerarToken(UsuarioDTO usuario);
    }
}
