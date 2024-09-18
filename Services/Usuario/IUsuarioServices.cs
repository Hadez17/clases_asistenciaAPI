using clases_asistenciaAPI.DTOs;

namespace clases_asistenciaAPI.Services.Usuario
{
    public interface IUsuarioServices
    {
        Task<int> PostUsuario(UsuarioRequest usuario);
        Task<List<UsuarioResponse>> GetUsuarios();
        Task<UsuarioResponse> GetUsuario(int usuarioId);
        Task<int> PutUsuario(int usuarioId, UsuarioRequest usuario);
        Task<int> DeleteUsuario(int usuarioId);

        Task<UsuarioResponse> Login(UsuarioRequest usuario);

    }
}

