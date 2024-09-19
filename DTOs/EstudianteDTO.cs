using clases_asistenciaAPI.Models;

namespace clases_asistenciaAPI.DTOs
{
    public class EstudianteResponse
    {
        public int EstudianteId { get; set; }

        public string EstudianteNombre { get; set; } = null!;

        public string EstudianteApellido { get; set; } = null!;

        public int ClaseId { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        public virtual ClaseResponse Clase { get; set; } = null!;

        public virtual ICollection<ReportesAsistencia> ReportesAsistencia { get; set; } = new List<ReportesAsistencia>();
    }

    public class EstudianteRequest
    {
        //public int EstudianteId { get; set; }

        public string EstudianteNombre { get; set; } = null!;

        public string EstudianteApellido { get; set; } = null!;

        public int ClaseId { get; set; }

        //public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        //public virtual ICollection<ReportesAsistencia> ReportesAsistencia { get; set; } = new List<ReportesAsistencia>();
    }
}
