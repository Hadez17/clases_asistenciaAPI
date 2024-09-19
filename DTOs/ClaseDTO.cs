using clases_asistenciaAPI.Models;

namespace clases_asistenciaAPI.DTOs
{
    public class ClaseResponse
    {
        public int ClaseId { get; set; }

        public string ClaseNombre { get; set; } = null!;

        public string? ClaseDescripcion { get; set; }

        public string Horario { get; set; } = null!;

        public int? UsuarioId { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        public virtual ICollection<Estudiantes> Estudiantes { get; set; } = new List<Estudiantes>();

        public virtual ICollection<ReportesAsistencia> ReportesAsistencia { get; set; } = new List<ReportesAsistencia>();

        public virtual UsuarioResponse Usuario { get; set; }
    }

    public class ClaseRequest
    {
        //public int ClaseId { get; set; }

        public string ClaseNombre { get; set; } = null!;

        public string? ClaseDescripcion { get; set; }

        public string Horario { get; set; } = null!;

        public int? UsuarioId { get; set; }

        //public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        //public virtual ICollection<Estudiantes> Estudiantes { get; set; } = new List<Estudiantes>();

        //public virtual ICollection<ReportesAsistencia> ReportesAsistencia { get; set; } = new List<ReportesAsistencia>();
    }
}
