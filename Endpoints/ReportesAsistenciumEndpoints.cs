using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Services.ReportesAsistencium;
using Microsoft.OpenApi.Models;

namespace clases_asistenciaAPI.Endpoints
{
    public static class ReportesAsistenciumEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/Api/ReportesAsistencia").WithTags("ReportesAsistencia");

            group.MapGet("/", async (IReportesAsistenciumServices reportesasistenciumServices) => {
                var ReportesAsistencium = await reportesasistenciumServices.GetReportesAsistencia();
                //200 Ok: La solicitud se realizo correctamente 
                //Y devuelve la lista de clases
                return Results.Ok(ReportesAsistencium);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Reportes de Asistencia",
                Description = "Muestra una lista para reportes de asistencias"
            })/*.RequireAuthorization()*/;

            group.MapGet("/{id}", async (int id, IReportesAsistenciumServices reportesasistenciumServices) =>
            {
                var ReportesAsistencium = await reportesasistenciumServices.GetReportesAsistencium(id);
                if (ReportesAsistencium == null)
                    return Results.NotFound(); //404 NotFound: El recurso solicitado no exciste
                else
                    return Results.Ok(ReportesAsistencium); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Reportes de asistencias",
                Description = "Busca un reporte de asistencia por id"
            })/*.RequireAuthorization()*/;

            group.MapPost("/", async (ReportesAsistenciumRequest reportesasistencia, IReportesAsistenciumServices reportesasistenciumServices) =>
            {
                if (reportesasistencia == null)
                    return Results.BadRequest(); //400 BadRequest: La solicitud no se pudo procesar, error de formato
                var id = await reportesasistenciumServices.PostReportesAsistencium(reportesasistencia);
                //201 Created: El recurso se creo con exito, se devuelve la ubicación
                return Results.Created($"Api/ReportesAsistencium/{id}", reportesasistencia);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Crear un Reporte de Asistencia",
                Description = "Crear un nuevo reporte de asistencia"
            })/*.RequireAuthorization()*/;

            group.MapPut("/{id}", async (int id, ReportesAsistenciumRequest reportesasistencium, IReportesAsistenciumServices reportesasistenciumServices) =>
            {

                var result = await reportesasistenciumServices.PutReportesAsistencium(id, reportesasistencium);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.Ok(result); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Modificar un reporte de Asistencia",
                Description = "Actualiza un reporte de asistencia existente"
            })/*.RequireAuthorization()*/;

            group.MapDelete("/{id}", async (int id, IReportesAsistenciumServices reportesasistenciumServices) =>
            {
                var result = await reportesasistenciumServices.DeleteReportesAsistencium(id);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.NoContent(); //204 NoContent: Recurso eliminado
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Eliminar un Reporte de Asistencia",
                Description = "Eliminar un Reporte de asistencia existente"
            })/*.RequireAuthorization()*/;

        }
    }
}
