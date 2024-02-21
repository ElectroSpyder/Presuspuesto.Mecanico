namespace Taller.Mecanico.Models.Context
{
    using Microsoft.EntityFrameworkCore;
    using Taller.Mecanico.Models.Entities;

    public class TallerContext : DbContext
    {
        public TallerContext(DbContextOptions<TallerContext> options) : base(options)
        {            
        }

        public DbSet <Presupuesto> Presupuesto { get; set; }
       // public DbSet <Vehiculo> Vehiculos { get; set; }
        public DbSet <Automovil> Automovil { get; set; }
        public DbSet<Moto> Moto { get; set; }
        public DbSet<Desperfecto> Desperfecto { get; set; }
        public DbSet<Repuesto> Repuesto { get; set; }
        public DbSet<DesperfectoRepuesto> DesperfectoRepuesto { get; set; }
        public DbSet<Detalle> Detalle { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehiculo>()
                .HasDiscriminator<string>("TipoVehiculo")
                .HasValue<Moto>("Moto")
                .HasValue<Automovil>("Automovil");
            
        }


    }
}
