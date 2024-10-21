using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Endpoints;
using clases_asistenciaAPI.Models;
using clases_asistenciaAPI.Services.Asistencium;
using clases_asistenciaAPI.Services.Clase;
using clases_asistenciaAPI.Services.Estudiante;
using clases_asistenciaAPI.Services.ReportesAsistencium;
using clases_asistenciaAPI.Services.Usuario;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT en el siguiente formato: Bearer {token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                }
            },
            new string [] {}
        }
    });
});

builder.Services.AddDbContext<ClasesAsistenciaDbContext>(
    o=>o.UseSqlServer(builder.Configuration.GetConnectionString("AsistenciaDbConnection"))
    );

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Registro de sevicio para Clase
builder.Services.AddScoped<IClaseServices, ClaseServices>();
builder.Services.AddScoped<IUsuarioServices, UsuarioServices>();
// Registro de sevicio para Estudiante
builder.Services.AddScoped<IEstudianteServices, EstudianteServices>();
builder.Services.AddScoped<IEstudianteServices, EstudianteServices>();
// Registro de sevicio para Asistencia
builder.Services.AddScoped<IAsistenciumServices, AsistenciumServices>();
builder.Services.AddScoped<IAsistenciumServices, AsistenciumServices>();
// Registro de sevicio para Reporte de Asistencia
builder.Services.AddScoped<IReportesAsistenciumServices, ReportesAsistenciumServices>();
builder.Services.AddScoped<IReportesAsistenciumServices, ReportesAsistenciumServices>();

var jwtSettings = builder.Configuration.GetSection("JwtSetting");
var secretKey = jwtSettings.GetValue<string>("SecretKey");

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(
options =>
{
    //Esquema por defecto
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
    options =>
    {
        //Permite usar HTTP en lugar de HTTPS 
        options.RequireHttpsMetadata = false;
        //Guardar token en el contexto de autenticación
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
            ValidAudience = jwtSettings.GetValue<string>("Audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints();

app.Run();

public partial class Program {}

