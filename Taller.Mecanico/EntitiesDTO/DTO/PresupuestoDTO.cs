namespace EntitiesDTO.DTO
{
    public class PresupuestoDTO
    {
        public PresupuestoDTO()
        {
            Desperfectos = [];
        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public decimal Total { get; set; }
        public VehiculoDTO Vehiculo { get; set; }
        public ICollection<DesperfectoDTO> Desperfectos { get; set; }
        public ICollection<decimal> Recargos { get; set; }
    }
}
