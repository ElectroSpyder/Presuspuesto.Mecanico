using Microsoft.EntityFrameworkCore;
using Taller.Mecanico.Logic.Implementacion;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Models.Context;
using Taller.Mecanico.Persistence.Repository.Implementacion;
using Taller.Mecanico.Persistence.Repository.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Implementacion;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<TallerContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddTransient<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddTransient<IVehiculoService, VehiculoService>();
builder.Services.AddTransient<IDesperfectoService, DesperfectoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
    
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

app.Run();
