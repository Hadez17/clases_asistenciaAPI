using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Services.Clase;
using Microsoft.OpenApi.Models;

namespace clases_asistenciaAPI.Endpoints
{
    public static class ClasesEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/Api/Clases").WithTags("Clases");

            group.MapGet("/", async (IClaseServices claseServices) => {
                var Clases = await claseServices.GetClase();
                //200 Ok: La solicitud se realizo correctamente 
                //Y devuelve la lista de clases
                return Results.Ok(Clases);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Clases", 
                Description = "Muestra una lista de todas las clases"
            })/*.RequireAuthorization()*/;

            group.MapGet("/{id}", async (int id, IClaseServices claseServices) =>
            {
                var clase = await claseServices.GetClase(id);
                if (clase == null)
                    return Results.NotFound(); //404 NotFound: El recurso solicitado no exciste
                else
                    return Results.Ok(clase); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Clase",
                Description = "Busca una clase por id"
            })/*.RequireAuthorization()*/;

            group.MapPost("/", async (ClaseRequest clase, IClaseServices claseServices) =>
            {
                if (clase == null)
                    return Results.BadRequest(); //400 BadRequest: La solicitud no se pudo procesar, error de formato
               var id = await claseServices.PostClase(clase);
                //201 Created: El recurso se creo con exito, se devuelve la ubicación
                return Results.Created($"Api/Clases/{id}", clase);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Crear Clase",
                Description = "Crear una nueva clase"
            })/*.RequireAuthorization()*/;

            group.MapPut("/{id}", async (int id, ClaseRequest clase, IClaseServices claseServices) =>
            {
   
                var result = await claseServices.PutClase(id, clase);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.Ok(result); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Modificar Clase",
                Description = "Actualiza una clase existente"
            })/*.RequireAuthorization()*/;

            group.MapDelete("/{id}", async (int id, IClaseServices claseServices) =>
            {
                var result = await claseServices.DeleteClase(id);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.NoContent(); //204 NoContent: Recurso eliminado
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Eliminar Clase",
                Description = "Eliminar una clase existente"
            })/*.RequireAuthorization()*/;

        }
    }
}
