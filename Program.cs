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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseEndpoints();

app.Run();

