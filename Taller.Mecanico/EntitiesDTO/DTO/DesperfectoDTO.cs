namespace EntitiesDTO.DTO
{
    public class DesperfectoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal ManoDeObra { get; set; }
        public int Tiempo { get; set; }       
        public int PresupuestoId { get; set; }
        //public ICollection<Repuesto> Repuestos { get; set; }
    }
}
