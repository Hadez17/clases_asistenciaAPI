using AutoMapper;
using Microsoft.EntityFrameworkCore;
using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;

namespace clases_asistenciaAPI.Services.Clase
{
    public class ClaseServices : IClaseServices
    {
        private readonly ClasesAsistenciaDbContext _db;
        private readonly IMapper _mapper;

        public ClaseServices(ClasesAsistenciaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteClase(int claseId)
        {
            var clase = await _db.Clases.FindAsync(claseId);
            if (clase == null)
                return -1;

            _db.Clases.Remove(clase);

            return await _db.SaveChangesAsync();
        }

        public async Task<List<ClaseResponse>> GetClase()
        {
            var clase = await _db.Clases.ToListAsync();
            var clasesList = _mapper.Map<List<Clases>, List<ClaseResponse>>(clase);

            return clasesList;
        }

        public async Task<ClaseResponse> GetClase(int ClaseId)
        {
            var clase = await _db.Clases.FindAsync(ClaseId);
            var claseResponse = _mapper.Map<Clases, ClaseResponse>(clase);

            return claseResponse;
        }

        public async Task<int> PostClase(ClaseRequest clase)
        {
            var claseRequest = _mapper.Map<ClaseRequest, Clases>(clase);
            await _db.Clases.AddAsync(claseRequest);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> PutClase(int claseId, ClaseRequest clase)
        {
            var entity = await _db.Clases.FindAsync(claseId);
            if (entity == null)
                return -1;

            entity.ClaseNombre = clase.ClaseNombre;
            entity.ClaseDescripcion = clase.ClaseDescripcion;
            entity.UsuarioId = clase.UsuarioId;

            _db.Clases.Update(entity);

            return await _db.SaveChangesAsync();

        }
    }
}
