using System.ComponentModel.DataAnnotations;

namespace Taller.Mecanico.Models.Entities
{
    public class DesperfectoRepuesto
    {
        [Key]
        public int Id { get; set; }
        public int DesperfectoId { get; set; }
        public int RepuestoId { get; set; }
    }
}
