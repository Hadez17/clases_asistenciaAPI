using clases_asistenciaAPI.DTOs;

namespace clases_asistenciaAPI.Services.Clase
{
    public interface IClaseServices
    {
        Task<int> PostClase(ClaseRequest clase);
        Task<List<ClaseResponse>> GetClase();
        Task<ClaseResponse> GetClase(int ClaseId);
        Task<int> PutClase(int claseId, ClaseRequest clase);
        Task<int> DeleteClase(int claseId);
    }
}
