namespace EntitiesDTO.DTO
{
    public class RequestDesperfecto
    {
        public RequestDesperfecto()
        {
            Repuestos = new List<RequestRepuesto>();
        }
        public int Id { get; set; }
        public IEnumerable<RequestRepuesto> Repuestos { get; set; }
    }
}
