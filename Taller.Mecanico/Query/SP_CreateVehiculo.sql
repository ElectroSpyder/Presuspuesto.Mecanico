-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Incerta un vehiculo ya sea Automovil o Moto
-- =============================================
CREATE PROCEDURE SP_CreateVehiculo
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

    -- Insert statements for procedure here
	INSERT INTO Vehiculo (Marca ,Modelo ,Patente, PresupuestoId ,TipoVehiculo ,Descripcion ,Tipo ,CantidadPuertas ,Cilindrada )
	VALUES (@Marca , @Modelo , @Patente , @PresupuestoId , @TipoVehiculo , @Descripcion , @Tipo , @CantidadPuertas , @Cilindrada )

	SELECT SCOPE_IDENTITY();
END
GO
