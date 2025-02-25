using Mectronics.SistemaGestionTransporte.Repositorio;
using Mectronics.SistemaGestionTransporte.Repositorio.Repositorios;
using Mectronics.SistemaGestionTransporte.Servicio.Servicios;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IConductor;
using Mectronics.SistemaGestionTransporte.Tranversales.Interfaces.IUsuario;
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
builder.Services.AddScoped<IConductorServicio, ConductorServicio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IConductorRepositorio, ConductorRepositorio>();

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Conductor",
        Version = "v1",
        Description = "API para la gestión de Conductores en el sistema de gestion de transporte.",
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

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
