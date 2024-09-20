using AutoMapper;
using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace clases_asistenciaAPI.Services.ReportesAsistencium
{
    public class ReportesAsistenciumServices : IReportesAsistenciumServices
    {
        private readonly ClasesAsistenciaDbContext _db;
        private readonly IMapper _mapper;

        public ReportesAsistenciumServices(ClasesAsistenciaDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> DeleteReportesAsistencium(int ReporteId)
        {
            var reportesasistencium = await _db.ReportesAsistencia.FindAsync(ReporteId);
            if (reportesasistencium == null)
                return -1;

            _db.ReportesAsistencia.Remove(reportesasistencium);
            return await _db.SaveChangesAsync();
        }

        //public Task<object?> GetReporteAsistencia(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<ReportesAsistenciumResponse>> GetReportesAsistencia()
        {
            var reportesasistencium = await _db.ReportesAsistencia.ToListAsync();
            var reportesasistenciumList = _mapper.Map<List<ReportesAsistencia>, List<ReportesAsistenciumResponse>>(reportesasistencium);

            return reportesasistenciumList;
        }

        public async Task<ReportesAsistenciumResponse> GetReportesAsistencium(int ReporteId)
        {
            var reportesasistencium = await _db.ReportesAsistencia.FindAsync(ReporteId);
            var reporteasistenciumResponse = _mapper.Map<ReportesAsistencia, ReportesAsistenciumResponse>(reportesasistencium);

            return reporteasistenciumResponse;
        }

        //public Task<object?> GetReportesAsistencium()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<int> PostReportesAsistencium(ReportesAsistenciumRequest reportesAsistencium)
        {
            var reportesasistenciumRequest = _mapper.Map<ReportesAsistenciumRequest, ReportesAsistencia>(reportesAsistencium);
            await _db.ReportesAsistencia.AddAsync(reportesasistenciumRequest);
            await _db.SaveChangesAsync();
            return reportesasistenciumRequest.ReporteId;
        }

        public async Task<int> PutReportesAsistencium(int ReporteId, ReportesAsistenciumRequest reportesAsistencium)
        {
            var entity = await _db.ReportesAsistencia.FindAsync(ReporteId);
            if (entity == null)
                return -1;

            entity.EstudianteId = reportesAsistencium.EstudianteId;
            entity.ClaseId = reportesAsistencium.ClaseId;

            _db.ReportesAsistencia.Update(entity);
            return await _db.SaveChangesAsync();
        }
    }
}

