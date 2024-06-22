using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.services;
using Core.Server;
using FluentValidation;
using Infraestructure.Filters;
using Infraestructure.Repositories;
using Infraestructure.Validators;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using FluentValidation.AspNetCore;
using Core.Exceptions;
using Core.DTOs;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CadenaConexion");
builder.Services.AddDbContext<pruebatecnicaDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FilterExceptions));
});
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Lee todos los profile de toda la solucion;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuracion de validaciones
builder.Services.AddScoped<IValidator<Empleado>, EmpleadoValidator>();
builder.Services.AddScoped<IValidator<RegistroEntradaUpdateDto>, RegistroEntradaUpdateDtoValidator>();
builder.Services.AddScoped<IValidator<RegistroEntrada>, RegistroEntradaValidator>();
builder.Services.AddScoped<IValidator<TipoEmpledo>, TipoEmpledoValidator>();
builder.Services.AddScoped<IValidator<TipoNovedad>, TipoNovedadValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
#endregion

#region Configuracion de inyeccion de dependencias 
builder.Services.AddScoped<IAdminInterfaces, AdminInterfaces>();
builder.Services.AddTransient<IEmpleadoService, EmpleadoService>();
builder.Services.AddTransient<IRegistroEntradaService, RegistroEntradaService>();
builder.Services.AddTransient<ITipoEmpledoService, TipoEmpledoService>();
builder.Services.AddTransient<ITipoNovedadService, TipoNovedadService>();
#endregion

var app = builder.Build();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
