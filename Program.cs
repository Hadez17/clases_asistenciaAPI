using clases_asistenciaAPI.DTOs;
using clases_asistenciaAPI.Models;
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/clases/", () => {
    return "Lista de clases";
});

app.MapGet("/api/clases/{id}", (int id) => {
    return $"Buscando clase con id: {id}";
});

app.MapPost("/api/clases/", (ClaseRequest clase) => {
    return $"Guardando clase con claseId: {clase.UsuarioId}";
});

app.MapPut("/api/clases/{id}", (int id, ClaseRequest clase) => {
    return $"Modificando clase con id: {id}";
});

app.MapDelete("/api/clases/{id}", (int id) => {
    return $"Eliminando clase con id: {id}";
});

app.Run();

