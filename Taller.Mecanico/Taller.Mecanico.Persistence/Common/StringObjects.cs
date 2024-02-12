namespace Taller.Mecanico.Persistence.Common
{
    public static class StringObjects
    {
        public static string ConnectionString =
                 "Data Source=DESKTOP-J7E0NLB;Initial Catalog=dbTaller;user id=sa;password=manolito2024;TrustServerCertificate=True";
        //Data Source=DESKTOP-J7E0NLB;Initial Catalog=dbTaller;User ID=sa;Password=***********;Trust Server Certificate=True
        #region scripts de Vehiculos

        public static string GetAutomovil = "SELECT * FROM Vehiculo WHERE Id = @Id";
        public static string GetMoto = "SELECT * FROM Moto WHERE Id = @Id";
        //public static string CreateVehiculo = "INSERT INTO Vehiculo (Marca ,Modelo ,Patente," +
        //    " PresupuestoId ,TipoVehiculo ,Descripcion ,Tipo ,CantidadPuertas ,Cilindrada )" +
        //    " VALUES (@Marca , @Modelo , @Patente , @PresupuestoId , @TipoVehiculo , @Descripcion " +
        //    " , @Tipo , @CantidadPuertas , @Cilindrada )";

        public static string CreateVehiculo = "SP_CreateVehiculo";
        public static string GetAllVehiculos = "SP_GetAllVehiculo";
        #endregion
    }
}
