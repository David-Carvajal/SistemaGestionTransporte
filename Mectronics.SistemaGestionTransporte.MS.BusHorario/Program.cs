using Mectronics.SistemaGestionTransporte.Repositorio;
using Mectronics.SistemaGestionTransporte.Repositorio.Repositorios;
using Mectronics.SistemaGestionTransporte.Servicio.Servicios;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IBusHorario;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductorHorario;
using Mectronics.SistemaGestionTransporte.Tranversales.Mapeos.AutoMapper;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//configurar CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});
// Agregar `IConfiguration` al contenedor de dependencias
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Registrar AutoMapper con el ensamblado que contiene los perfiles
builder.Services.AddAutoMapper(typeof(AutoMapeador));

//Inyeccion de Dependencias
builder.Services.AddScoped<IConexionBaseDatos, ConexionBaseDatos>();
builder.Services.AddScoped<IConductorHorarioRepositorio, ConductorHorarioRepositorio>();
builder.Services.AddScoped<IBusHorarioServicio, BusHorarioServicio>();
builder.Services.AddScoped<IBusHorarioRepositorio, BusHorarioRepositorio>();

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de BusHorario",
        Version = "v1",
        Description = "API para la gestión de Horarios de buses en el sistema de gestion de transporte.",
        Contact = new OpenApiContact
        {
            Name = "Soporte API",
            Email = "johandavidsalinascarvajal67@gmail.com"
        }
    });

    // Obtener la ruta del archivo XML de documentación
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Incluir comentarios XML en Swagger
    options.IncludeXmlComments(xmlPath);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();

