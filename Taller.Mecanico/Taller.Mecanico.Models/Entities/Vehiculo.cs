using System.ComponentModel.DataAnnotations;

namespace Taller.Mecanico.Models.Entities
{
    public abstract class Vehiculo
    {
        [Key]
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public Presupuesto Presupuesto { get; set; }
        public  int PresupuestoId { get; set; }

    }
}
