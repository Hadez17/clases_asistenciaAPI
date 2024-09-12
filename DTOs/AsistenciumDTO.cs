using clases_asistenciaAPI.Models;

namespace clases_asistenciaAPI.DTOs
{
    public class AsistenciumResponse
    {
        public int AsistenciaId { get; set; }

        public int EstudianteId { get; set; }

        public int ClaseId { get; set; }

        public DateOnly Fecha { get; set; }

        public string Estado { get; set; } = null!;

        public virtual ClaseResponse Clase { get; set; } = null!;

        public virtual EstudianteResponse Estudiante { get; set; } = null!;
    }

    public class AsistenciumRequest
    {
        //public int AsistenciaId { get; set; }

        public int EstudianteId { get; set; }

        public int ClaseId { get; set; }

        public DateOnly Fecha { get; set; }

        public string Estado { get; set; } = null!;

    }
}
