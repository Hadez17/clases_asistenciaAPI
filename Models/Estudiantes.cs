﻿using System;
using System.Collections.Generic;

namespace clases_asistenciaAPI.Models;

public partial class Estudiantes
{
    public int EstudianteId { get; set; }

    public string EstudianteNombre { get; set; } = null!;

    public string EstudianteApellido { get; set; } = null!;

    public int ClaseId { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual Clases Clase { get; set; } = null!;

    public virtual ICollection<ReportesAsistencia> ReportesAsistencia { get; set; } = new List<ReportesAsistencia>();
}
