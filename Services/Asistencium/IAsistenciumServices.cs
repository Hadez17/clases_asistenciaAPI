using clases_asistenciaAPI.DTOs;

namespace clases_asistenciaAPI.Services.Asistencium
{
    public interface IAsistenciumServices
    {
        Task<int> PostAsistencium(AsistenciumRequest asistencium);
        Task<List<AsistenciumResponse>> GetAsistencium();
        Task<AsistenciumResponse> GetAsistencium(int asistenciaId);
        Task<int> PutAsistencium(int asistenciaId, AsistenciumRequest asistencium);
        Task<int> DeleteAsistencium(int asistenciaId);
    }
}
