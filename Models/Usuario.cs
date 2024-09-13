using System;
using System.Collections.Generic;

namespace clases_asistenciaAPI.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string UsuarioNombre { get; set; } = null!;

    public string UsuarioPassword { get; set; } = null!;

    public string UsuarioRol { get; set; } = null!;

    public virtual ICollection<Clases> Clases { get; set; } = new List<Clases>();
}
