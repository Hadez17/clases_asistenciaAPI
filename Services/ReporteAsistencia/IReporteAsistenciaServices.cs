using clases_asistenciaAPI.DTOs;

namespace clases_asistenciaAPI.Services.ReportesAsistencium
{
    public interface IReportesAsistenciumServices
    {
        Task<int> PostReportesAsistencium(ReportesAsistenciumRequest reportesAsistencium);
        Task<List<ReportesAsistenciumResponse>> GetReportesAsistencia();
        Task<ReportesAsistenciumResponse> GetReportesAsistencium(int ReporteId);
        Task<int> PutReportesAsistencium(int ReporteId, ReportesAsistenciumRequest reportesAsistencium);
        Task<int> DeleteReportesAsistencium(int ReporteId);
        Task<object?> GetReporteAsistencia(int id);
        Task<object?> GetReportesAsistencium();
    }
}
