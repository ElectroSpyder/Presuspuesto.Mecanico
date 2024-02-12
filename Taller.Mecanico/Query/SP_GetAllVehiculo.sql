USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllVehiculo]    Script Date: 11/2/2024 23:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 11-02-2024
-- Description:	Obtiene todos los vehiculo ya sea Automovil o Moto
-- =============================================
ALTER PROCEDURE [dbo].[SP_GetAllVehiculo]
	-- Add the parameters for the stored procedure here
	--@Marca nvarchar(50),
 --   @Modelo nvarchar(50),
	--@Patente nvarchar(50),
	--@PresupuestoId int,
	--@TipoVehiculo nchar(13),
	--@Descripcion nvarchar(50),
	--@Tipo int,
	--@CantidadPuertas int,
	--@Cilindrada nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Marca]
      ,[Modelo]
      ,[Patente]
      ,[PresupuestoId]
      ,[TipoVehiculo]
      ,[Descripcion]
      ,[Tipo]
      ,[CantidadPuertas]
      ,[Cilindrada]
  FROM [dbo].[Vehiculo]

END
