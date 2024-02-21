namespace EntitiesDTO.DTO
{
    public enum Tipo
    {
        compacto, sedan, monovolumen, utilitario, lujo
    }
    public class VehiculoDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }

        public string? Descripcion { get; set; }
        public Tipo Tipo { get; set; }
        public int CantidadPuertas { get; set; }

        public string? Cilindrada { get; set; }

        public string TipoVehiculo {get; set; }
    }
}
