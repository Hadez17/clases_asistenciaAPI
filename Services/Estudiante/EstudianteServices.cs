using AutoMapper;
using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace clases_asistenciaAPI.Services.Estudiante
{
    public class EstudianteServices : IEstudianteServices
    {
        private readonly ClasesAsistenciaDbContext _db;
        private readonly IMapper _mapper;

        public EstudianteServices(ClasesAsistenciaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteEstudiante(int estudianteId)
        {
            var estudiante = await _db.Estudiantes.FindAsync(estudianteId);
            if (estudiante == null)
                return -1;

            _db.Estudiantes.Remove(estudiante);
            return await _db.SaveChangesAsync();
        }

        public async Task<EstudianteResponse> GetEstudiante(int estudianteId)
        {
            var estudiante = await _db.Estudiantes.FindAsync(estudianteId);
            var estudianteResponse = _mapper.Map<Estudiantes, EstudianteResponse>(estudiante);

            return estudianteResponse;
        }

        public async Task<List<EstudianteResponse>> GetEstudiantes()
        {
            var estudiantes = await _db.Estudiantes.ToListAsync();
            var estudiantesList = _mapper.Map<List<Estudiantes>, List<EstudianteResponse>>(estudiantes);

            return estudiantesList;
        }

        public async Task<int> PostEstudiante(EstudianteRequest estudiante)
        {
            var estudianteRequest = _mapper.Map<EstudianteRequest, Estudiantes>(estudiante);
            await _db.Estudiantes.AddAsync(estudianteRequest);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> PutEstudiante(int estudianteId, EstudianteRequest estudiante)
        {
            var entity = await _db.Estudiantes.FindAsync(estudianteId);
            if (entity == null)
                return -1;

            entity.EstudianteNombre = estudiante.EstudianteNombre;
            entity.EstudianteApellido = estudiante.EstudianteApellido;
            entity.ClaseId = estudiante.ClaseId;

            _db.Estudiantes.Update(entity);

            return await _db.SaveChangesAsync();
        }
    }
}