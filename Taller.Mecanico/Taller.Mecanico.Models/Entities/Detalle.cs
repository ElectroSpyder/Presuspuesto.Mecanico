using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Mecanico.Models.Entities
{
    public class Detalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public int PresupuestoId { get; set; }
        [Key]
        public int DesperfectoId { get; set; }
    }
}
