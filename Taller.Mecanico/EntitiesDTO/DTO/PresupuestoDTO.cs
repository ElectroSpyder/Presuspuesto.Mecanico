namespace EntitiesDTO.DTO
{
    public class PresupuestoDTO
    {
        public PresupuestoDTO()
        {
            Detalle = [];
            Desperfectos = [];
        }
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public decimal Total { get; set; }
        public int VehiculoId { get; set; }
        public VehiculoDTO Vehiculo { get; set; }
        public ICollection<DetalleDTO> Detalle { get; set; }
        public ICollection<DesperfectoDTO> Desperfectos { get; set; }
        public ICollection<decimal> Recargos { get; set; }
    }
}
