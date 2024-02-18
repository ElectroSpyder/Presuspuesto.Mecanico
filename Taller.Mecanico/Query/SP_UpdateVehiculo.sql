USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateVehiculo]    Script Date: 18/2/2024 10:30:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	actualizar Automovil o Moto
-- =============================================
ALTER PROCEDURE [dbo].[SP_UpdateVehiculo]
	-- Add the parameters for the stored procedure here
	@Marca nvarchar(50),
    @Modelo nvarchar(50),
	@Patente nvarchar(50),
	@PresupuestoId int,
	@TipoVehiculo nchar(13),
	@Descripcion nvarchar(50),
	@Tipo int,
	@CantidadPuertas int,
	@Cilindrada nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Vehiculo
    -- Insert statements for procedure here
	SET Marca = @Marca ,
		Modelo = @Modelo,
		Patente = @Patente, 
		PresupuestoId = @PresupuestoId ,
		TipoVehiculo = @TipoVehiculo ,
		Descripcion = @Descripcion ,
		Tipo = @Tipo ,
		CantidadPuertas = @CantidadPuertas,
		Cilindrada = @Cilindrada 

	SELECT @@ROWCOUNT;
END
