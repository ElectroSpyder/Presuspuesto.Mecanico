namespace EntitiesDTO.DTO
{
    public class MotoDTO
    {
        //heredadas
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        //propias
        public string? Descripcion { get; set; }
        public string? Cilindrada { get; set; }
        public string TipoVehiculo { get { return "Moto"; } } 
    }
}
