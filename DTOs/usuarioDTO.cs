namespace clases_asistenciaAPI.DTOs
{
    public class UsuarioResponse
    {
        public int UsuarioId { get; set; }

        public string UsuarioNombre { get; set; } = null!;

        public string UsuarioPassword { get; set; } = null!;

        public string UsuarioRol { get; set; } = null!;
    }

    public class UsuarioRequest
    {
        //public int UsuarioId { get; set; }

        public string UsuarioNombre { get; set; } = null!;

        public string UsuarioPassword { get; set; } = null!;

        public string UsuarioRol { get; set; } = null!;
    }
}
