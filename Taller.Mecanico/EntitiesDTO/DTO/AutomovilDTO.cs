namespace EntitiesDTO.DTO
{
    public class AutomovilDTO
    {
        //heredadas
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        //propias
        public string? Descripcion { get; set; }
        public Tipo Tipo { get; set; }
        public int CantidadPuertas { get; set; }
        public string TipoVehiculo { get { return "Auto"; } } 
    }
}
