using AutoMapper;
using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;

namespace clases_asistenciaAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            //Modelo - > DTO
            CreateMap<Asistencia, AsistenciumResponse>();
            CreateMap<Clases, ClaseResponse>();
            CreateMap<Estudiantes, EstudianteResponse>();
            CreateMap<ReportesAsistencium, ReportesAsistenciumResponse>();
            CreateMap<Usuario, UsuarioResponse>();

            //DTO - > Modelo
            CreateMap<AsistenciumRequest, Asistencia>();
            CreateMap<ClaseRequest, Clases>();
            CreateMap<EstudianteRequest, Estudiantes>();
            CreateMap<ReportesAsistenciumRequest, ReportesAsistencium>();
            CreateMap<UsuarioRequest, Usuario>();



        }
    }
}
