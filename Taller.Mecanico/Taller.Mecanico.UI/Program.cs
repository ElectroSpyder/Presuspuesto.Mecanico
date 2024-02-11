using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Taller.Mecanico.Logic.Implementacion;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Models.Context;
using Taller.Mecanico.Persistence.UnitOfWork.Implementacion;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TallerContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IVehiculoService, VehiculoService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

/*

  services.AddDbContext<dbActuContext>(cfg =>
            {
                //cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));   Produccion
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));     //  Base Test 
            });
 */
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

