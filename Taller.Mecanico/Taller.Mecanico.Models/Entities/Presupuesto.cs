using System.ComponentModel.DataAnnotations;

namespace Taller.Mecanico.Models.Entities
{
    public class Presupuesto
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public decimal Total { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public int VehiculoId { get; set; }
        
    }
}
