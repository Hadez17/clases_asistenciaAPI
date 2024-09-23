using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;
using clases_asistenciaAPI.Services.Clase;
using clases_asistenciaAPI.Services.Usuario;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace clases_asistenciaAPI.Endpoints
{
    public static class UsuarioEndpoints
    {
        public static void Add(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/Api/usuario").WithTags("Usuario");

            group.MapGet("/", async (IUsuarioServices usuarioServices) => {
                var usuarios = await usuarioServices.GetUsuarios();
                //200 Ok: La solicitud se realizo correctamente 
                //Y devuelve la lista de clases
                return Results.Ok(usuarios);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Usuario",
                Description = "Muestra una lista de todos los usuarios"
            });

            group.MapGet("/{id}", async (int id, IUsuarioServices usuarioServices) =>
            {
                var usuario = await usuarioServices.GetUsuario(id);
                if (usuario == null)
                    return Results.NotFound(); //404 NotFound: El recurso solicitado no exciste
                else
                    return Results.Ok(usuario); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Obtener Usuario",
                Description = "Busca una Usuario por id"
            });

            group.MapPost("/", async (UsuarioRequest usuario, IUsuarioServices usuarioServices) =>
            {
                if (usuario == null)
                    return Results.BadRequest(); //400 BadRequest: La solicitud no se pudo procesar, error de formato
                var id = await usuarioServices.PostUsuario(usuario);
                //201 Created: El recurso se creo con exito, se devuelve la ubicación
                return Results.Created($"Api/usuario/{id}", usuario);
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Crear Usuario",
                Description = "Crear un nuevo usuario"
            });

            group.MapPut("/{id}", async (int id, UsuarioRequest usuario, IUsuarioServices usuarioServices) =>
            {

                var result = await usuarioServices.PutUsuario(id, usuario);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.Ok(result); //200 Ok: La solicitud se realizo correctamente y devuelve la clase
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Modificar Usuario",
                Description = "Actualiza un usuario existente"
            });

            group.MapDelete("/{id}", async (int id, IUsuarioServices usuarioServices) =>
            {
                var result = await usuarioServices.DeleteUsuario(id);
                if (result == -1)
                    return Results.NotFound();//404 NotFound: El recurso solicitado no existe
                else
                    return Results.NoContent(); //204 NoContent: Recurso eliminado
            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Eliminar Usuario",
                Description = "Eliminar un usuario existente"
            });

            group.MapPost("/login", async (UsuarioRequest usuario, IUsuarioServices usuarioServices, IConfiguration config) => {

                var login = await usuarioServices.Login(usuario);

                if(login is null)
                    return Results.Unauthorized(); //Retorna el estado 401: Unauthorized
                else
                {
                    var jwtSettings = config.GetSection("JwtSetting");  
                    var secretKey = jwtSettings.GetValue<string>("SecretKey");
                    var issuer = jwtSettings.GetValue<string>("Issuer");
                    var audience = jwtSettings.GetValue<string>("Audience");

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(secretKey);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {

                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, usuario.UsuarioNombre),
                            new Claim(ClaimTypes.Role, usuario.UsuarioRol)
                        }),
                        Expires = DateTime.UtcNow.AddHours(5),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                        SecurityAlgorithms.HmacSha256Signature)
                    };

                    //Crear token, usando parametros definidos
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    //Convertir el token a una cadena
                    var jwt = tokenHandler.WriteToken(token);

                    return Results.Ok(jwt);

                }

            }).WithOpenApi(O => new OpenApiOperation(O)
            {
                Summary = "Login Usuario",
                Description = "Generar token para inicio de sesión."
            });
        }
    }
}
