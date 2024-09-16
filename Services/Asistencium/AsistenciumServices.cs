using AutoMapper;
using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace clases_asistenciaAPI.Services.Asistencium
{
    public class AsistenciumServices : IAsistenciumServices
    {
        private readonly ClasesAsistenciaDbContext _db;
        private readonly IMapper _mapper;

        public AsistenciumServices(ClasesAsistenciaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //public object Asistencia { get; private set; }

        public async Task<int> DeleteAsistencium(int asistenciaId)
        {
            var asistencium = await _db.Asistencia.FindAsync(asistenciaId);
            if (asistencium == null)
                return -1;

            _db.Asistencia.Remove(asistencium);
            return await _db.SaveChangesAsync();
        }

        public async Task<List<AsistenciumResponse>> GetAsistencium()
        {
            var asistencium = await _db.Asistencia.ToListAsync();
            var asistenciumList = _mapper.Map<List<Asistencia>, List<AsistenciumResponse>>(asistencium);

            return asistenciumList;

        }

        public async Task<AsistenciumResponse> GetAsistencium(int asistenciaId)
        {
            var asistencium = await _db.Asistencia.FindAsync(asistenciaId);
            var asistenciumResponse = _mapper.Map<Asistencia, AsistenciumResponse>(asistencium);

            return asistenciumResponse;
        }

        public async Task<int> PostAsistencium(AsistenciumRequest asistencium)
        {
            var asistenciumRequest = _mapper.Map<AsistenciumRequest, Asistencia>(asistencium);
            await _db.Asistencia.AddAsync(asistenciumRequest);
            await _db.SaveChangesAsync();
            return asistenciumRequest.AsistenciaId;
        }  

        public async Task<int> PutAsistencium(int asistenciaId, AsistenciumRequest asistencium)
        {
            var entity = await _db.Asistencia.FindAsync(asistenciaId);
            if (entity == null)
                return -1;

            entity.Fecha = asistencium.Fecha;
            entity.Estado = asistencium.Estado;
            entity.ClaseId = asistencium.ClaseId;

            _db.Asistencia.Update(entity);

            return await _db.SaveChangesAsync();
        }
    }

}
