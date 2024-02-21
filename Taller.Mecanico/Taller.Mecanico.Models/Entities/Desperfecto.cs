using System.ComponentModel.DataAnnotations;

namespace Taller.Mecanico.Models.Entities
{
    public class Desperfecto
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal ManoDeObra { get; set; }
        public int Tiempo { get; set; }
        public ICollection<Repuesto> Repuestos { get; set; }
    }
}
