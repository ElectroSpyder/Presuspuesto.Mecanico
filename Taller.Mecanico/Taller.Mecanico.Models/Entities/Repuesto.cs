using System.ComponentModel.DataAnnotations;

namespace Taller.Mecanico.Models.Entities
{
    public class Repuesto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public ICollection<Desperfecto> Desperfectos { get; set; }
    }
}
