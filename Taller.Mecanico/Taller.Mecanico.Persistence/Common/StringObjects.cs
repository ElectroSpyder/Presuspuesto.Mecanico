namespace Taller.Mecanico.Persistence.Common
{
    public static class StringObjects
    {
        public static string ConnectionString =
                 "Data Source=DESKTOP-J7E0NLB;Initial Catalog=dbTaller;user id=sa;password=manolito2024;TrustServerCertificate=True";
        //Data Source=DESKTOP-J7E0NLB;Initial Catalog=dbTaller;User ID=sa;Password=***********;Trust Server Certificate=True
        #region scripts de Vehiculos

        public static string GetAutomovil = "SELECT * FROM Vehiculo WHERE Id = @Id";
        public static string GetDesperfecto = "SELECT * FROM Desperfecto WHERE Id = @Id";
        public static string GetRepuesto = "SELECT * FROM Repuesto WHERE Id = @Id";      

        public static string CreateVehiculo = "SP_CreateVehiculo";
        public static string GetAllVehiculos = "SP_GetAllVehiculo";
        public static string DeleteVehiculo = "SP_DeleteVehiculo";
        public static string UpdateVehiculo = "SP_UpdateVehiculo";

        public static string GetAllDesperfectos = "SP_GetAllDesperfecto";
        public static string CreateDesperfecto = "SP_CreateDesperfecto";
        public static string DeleteDespertecto = "SP_DeleteDesperfecto";
        public static string UpdateDesperfecto = "SP_UpdateDesperfecto";

        public static string GetAllRepuesto = "SP_GetAllRepuesto";
        public static string CreateRepuesto = "SP_CreateRepuesto";
        public static string DeleteRepuesto = "SP_DeleteRepuesto";
        public static string UpdateRepuesto = "SP_UpdateRepuesto";

        public static string CreatePresupuesto = "SP_CreatePresupuesto";
        public static string DeletePresupuesto = "SP_DeletePresupuesto";
        public static string UpdatePresupuesto = "SP_UpdatePresupuesto";
        public static string GetAllPresupuesto = "SP_GetAllPresupuesto";

        public static string CreateDetalle = "SP_CreateDetalle";
        public static string GetAllDetalleByIdPresupuesto = "SP_GetAllDetalleByIdPresupuesto";
        public static string GetAllDesperfectoRepuestoByIdDesperfecto = "SP_GetAllDesperfectoRepuestoByIdDesperfecto";

        public static string GetRepuestoMasUtilizado = "SP_GetRepuestoMasUtilizado";
        public static string GetPromedio = "SP_GetPromedio";
        #endregion
    }
}
