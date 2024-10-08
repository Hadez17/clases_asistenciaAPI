﻿using System;
using System.Collections.Generic;

namespace clases_asistenciaAPI.Models;

public partial class Clases
{
    public int ClaseId { get; set; }

    public string ClaseNombre { get; set; } = null!;

    public string? ClaseDescripcion { get; set; }

    public string Horario { get; set; } = null!;

    public int? UsuarioId { get; set; }

    public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

    public virtual ICollection<Estudiantes> Estudiantes { get; set; } = new List<Estudiantes>();

    public virtual ICollection<ReportesAsistencia> ReportesAsistencia { get; set; } = new List<ReportesAsistencia>();

    public virtual Usuarios? Usuario { get; set; }
}
