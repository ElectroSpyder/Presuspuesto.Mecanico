namespace Taller.Mecanico.Persistence.Common
{
    public static class StringObjects
    {
        public static string ConnectionString =            
                 "Server=DESKTOP-J7E0NLB;Database=dbTaller;user id=sa;password=manolito2024;Integrated Security=False;Trusted_Connection=False;";

        #region scripts de Vehiculos

        public static string GetAutomovil = "SELECT * FROM Vehiculo WHERE Id = @Id";
        public static string GetMoto = "SELECT * FROM Moto WHERE Id = @Id";
        //public static string CreateVehiculo = "INSERT INTO Vehiculo (Marca ,Modelo ,Patente," +
        //    " PresupuestoId ,TipoVehiculo ,Descripcion ,Tipo ,CantidadPuertas ,Cilindrada )" +
        //    " VALUES (@Marca , @Modelo , @Patente , @PresupuestoId , @TipoVehiculo , @Descripcion " +
        //    " , @Tipo , @CantidadPuertas , @Cilindrada )";

        public static string CreateVehiculo = "SP_CreateVehiculo";

        #endregion
    }
}
