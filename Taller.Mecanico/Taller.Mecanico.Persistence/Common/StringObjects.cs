namespace Taller.Mecanico.Persistence.Common
{
    public static class StringObjects
    {
        public static string ConnectionString =            
                 "Server=DESKTOP-J7E0NLB;Database=dbTaller;user id=sa;password=manolito2024;Integrated Security=False;Trusted_Connection=False;";

        #region scripts de Vehiculos

        public static string GetAutomovil = "SELECT * FROM Vehicuko WHERE Id = @Id";

        #endregion
    }
}
