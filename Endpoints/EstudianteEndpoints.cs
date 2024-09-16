using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Services.Estudiante;
using Microsoft.OpenApi.Models;

namespace clases_asistenciaAPI.Endpoints
{
    public static class EstudianteEndpoints
    {
            public static void Add(this IEndpointRouteBuilder routes)
            {
                var group = routes.MapGroup("/Api/Estudiante").WithTags("Estudiante");

                group.MapGet("/", async (IEstudianteServices estudianteServices) => {
                    var Estudiante = await estudianteServices.GetEstudiantes();
                    //200 Ok: La solicitud se realizo correctamente 
                    //Y devuelve la lista de clases
                    return Results.Ok(Estudiante);
                }).WithOpenApi(O => new OpenApiOperation(O)
                {
                    Summary = "Obtener Estudiante",
                    Description = "Muestra una lista de todas los estudiantes"
                });

                group.MapGet("/{id}", async (int id, IEstudianteServices estudianteServices) =>
                {
                    var estudiante = await estudianteServices.GetEstudiante(id);
                    if (estudiante == null)
                        return Results.NotFound(); //404 NotFound: El recurso solicitado no exciste
                    else
                        return Results.Ok(estudiante); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
                }).WithOpenApi(O => new OpenApiOperation(O)
                {
                    Summary = "Obtener Estudiante",
                    Description = "Busca un estudiante por id"
                });

                group.MapPost("/", async (EstudianteRequest estudiante, IEstudianteServices estudianteServices) =>
                {
                    if (estudiante == null)
                        return Results.BadRequest(); //400 BadRequest: La solicitud no se pudo procesar, error de formato
                    var id = await estudianteServices.PostEstudiante(estudiante);
                    //201 Created: El recurso se creo con exito, se devuelve la ubicación
                    return Results.Created($"Api/Estudiante/{id}", estudiante);
                }).WithOpenApi(O => new OpenApiOperation(O)
                {
                    Summary = "Crear Estudiante",
                    Description = "Crear un nuevo estudiante"
                });

                group.MapPut("/{id}", async (int id, EstudianteRequest estudiante, IEstudianteServices estudianteServices) =>
                {

                    var result = await estudianteServices.PutEstudiante(id, estudiante);
                    if (result == -1)
                        return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                    else
                        return Results.Ok(result); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
                }).WithOpenApi(O => new OpenApiOperation(O)
                {
                    Summary = "Modificar Estudiante",
                    Description = "Actualiza un estudiante existente"
                });

                group.MapDelete("/{id}", async (int id, IEstudianteServices estudianteServices) =>
                {
                    var result = await estudianteServices.DeleteEstudiante(id);
                    if (result == -1)
                        return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                    else
                        return Results.NoContent(); //204 NoContent: Recurso eliminado
                }).WithOpenApi(O => new OpenApiOperation(O)
                {
                    Summary = "Eliminar Estudiante",
                    Description = "Eliminar un estudiante existente"
                });

            }
    }
}
