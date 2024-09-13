using System;
using System.Collections.Generic;

namespace clases_asistenciaAPI.Models;

public partial class ReportesAsistencium
{
    public int ReporteId { get; set; }

    public int EstudianteId { get; set; }

    public int ClaseId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int TotalAsistencias { get; set; }

    public int TotalAusencias { get; set; }

    public virtual Clase Clase { get; set; } = null!;

    public virtual Estudiantes Estudiante { get; set; } = null!;
}
