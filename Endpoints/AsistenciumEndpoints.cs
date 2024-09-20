using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Services.Asistencium;
using Microsoft.OpenApi.Models;

namespace clases_asistenciaAPI.Endpoints
{
    public static class AsistenciumEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/Api/Asistencia").WithTags("Asistencia");

            group.MapGet("/", async (IAsistenciumServices asistenciumServices) => {
                var Asistencium = await asistenciumServices.GetAsistencium();
                //200 Ok: La solicitud se realizo correctamente 
                //Y devuelve la lista de clases
                return Results.Ok(Asistencium);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Asistencia",
                Description = "Muestra una lista de todas las asistencias"
            });/*.RequireAuthorization();*/

            group.MapGet("/{id}", async (int id, IAsistenciumServices asistenciumServices) =>
            {
                var Asistencium = await asistenciumServices.GetAsistencium(id);
                if (Asistencium == null)
                    return Results.NotFound(); //404 NotFound: El recurso solicitado no exciste
                else
                    return Results.Ok(Asistencium); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Asistencia",
                Description = "Busca una asistencia por id"
            });/*.RequireAuthorization();*/

            group.MapPost("/", async (AsistenciumRequest asistencia, IAsistenciumServices asistenciumServices) =>
            {
                if (asistencia == null)
                    return Results.BadRequest(); //400 BadRequest: La solicitud no se pudo procesar, error de formato
                var id = await asistenciumServices.PostAsistencium(asistencia);
                //201 Created: El recurso se creo con exito, se devuelve la ubicación
                return Results.Created($"Api/Asistencium/{id}", asistencia);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Crear Asistencia",
                Description = "Crear una nueva asistencia"
            });/*.RequireAuthorization();*/

            group.MapPut("/{id}", async (int id, AsistenciumRequest Asistencium, IAsistenciumServices asistenciumServices) =>
            {

                var result = await asistenciumServices.PutAsistencium(id, Asistencium);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.Ok(result); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Modificar Asistencia",
                Description = "Actualiza una asistencia existente"
            });/*.RequireAuthorization();*/

            group.MapDelete("/{id}", async (int id, IAsistenciumServices asistenciumServices) =>
            {
                var result = await asistenciumServices.DeleteAsistencium(id);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.NoContent(); //204 NoContent: Recurso eliminado
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Eliminar Asistencia",
                Description = "Eliminar una asistencia existente"
            });/*.RequireAuthorization();*/

        }
    }
}
