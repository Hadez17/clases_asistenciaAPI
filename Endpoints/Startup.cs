namespace clases_asistenciaAPI.Endpoints
{
    public static class Startup
    {
        public static void UseEndpoints(this WebApplication app) {
            ClasesEndpoints.Add(app);
            EstudianteEndpoints.Add(app);
            AsistenciumEndpoints.Add(app);
            ReportesAsistenciumEndpoints.Add(app);
        }
    }
}
