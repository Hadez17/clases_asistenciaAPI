using clases_asistenciaAPI.DTOs;

namespace clases_asistenciaAPI.Services.Estudiante
{
    public interface IEstudianteServices
    {
        Task<int> PostEstudiante(EstudianteRequest estudiante);
        Task<List<EstudianteResponse>> GetEstudiantes();
        Task<EstudianteResponse> GetEstudiante(int estudianteId);
        Task<int> PutEstudiante(int estudianteId, EstudianteRequest estudiante);
        Task<int> DeleteEstudiante(int estudianteId);
    }
}
