using AutoMapper;
using Microsoft.EntityFrameworkCore;
using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;

namespace clases_asistenciaAPI.Services.Usuario
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ClasesAsistenciaDbContext _db;
        private readonly IMapper _mapper;

        public UsuarioServices(ClasesAsistenciaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteUsuario(int usuarioId)
        {
            var usuario = await _db.Usuarios.FindAsync(usuarioId);
            if (usuario == null)
                return -1;

            _db.Usuarios.Remove(usuario);

            return await _db.SaveChangesAsync();
        }

        public async Task<UsuarioResponse> GetUsuario(int usuarioId)
        {
            var usuario = await _db.Usuarios.FindAsync(usuarioId);
            var usuarioResponse = _mapper.Map<Usuarios, UsuarioResponse>(usuario);

            return usuarioResponse;
        }

        public async Task<List<UsuarioResponse>> GetUsuarios()
        {
            var usuarios = await _db.Usuarios.ToListAsync();
            var usuariosList = _mapper.Map<List<Usuarios>, List<UsuarioResponse>>(usuarios);

            return usuariosList;
        }

        public async Task<UsuarioResponse> Login(UsuarioRequest usuario)
        {
            var usuarioEntity = await _db.Usuarios.FirstOrDefaultAsync(
                o=> o.UsuarioNombre == usuario.UsuarioNombre
                && o.UsuarioPassword == usuario.UsuarioPassword
                );
            var usuarioResponse = _mapper.Map<Usuarios, UsuarioResponse>(usuarioEntity);

            return usuarioResponse;
        }

        public async Task<int> PostUsuario(UsuarioRequest usuario)
        {
            var entity = _mapper.Map<UsuarioRequest, Usuarios>(usuario);

            await _db.Usuarios.AddAsync(entity);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> PutUsuario(int usuarioId, UsuarioRequest usuario)
        {
            var entity = await _db.Usuarios.FindAsync(usuarioId);
            if (entity == null)
                return -1;

            entity.UsuarioNombre = usuario.UsuarioNombre;
            entity.UsuarioPassword = usuario.UsuarioPassword;
            entity.UsuarioRol = usuario.UsuarioRol;

            _db.Usuarios.Update(entity);

            return await _db.SaveChangesAsync();
        }
    }
}
