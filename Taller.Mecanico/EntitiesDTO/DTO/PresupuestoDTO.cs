namespace EntitiesDTO.DTO
{
    public class PresupuestoDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public decimal Total { get; set; }
        //public ICollection<VehiculoDTO>? Vehiculos { get; set; }
        public ICollection<DesperfectoDTO> Desperfectos { get; set; }
    }
}
