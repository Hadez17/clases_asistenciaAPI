using System;
using System.Collections.Generic;

namespace clases_asistenciaAPI.Models;

public partial class Asistencia
{
    public int AsistenciaId { get; set; }

    public int EstudianteId { get; set; }

    public int ClaseId { get; set; }

    public DateOnly Fecha { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Clases Clase { get; set; } = null!;

    public virtual Estudiante Estudiante { get; set; } = null!;
}
