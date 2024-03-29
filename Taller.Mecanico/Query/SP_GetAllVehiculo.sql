USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllVehiculo]    Script Date: 20/2/2024 18:51:55 ******/
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
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Marca]
      ,[Modelo]
      ,[Patente]      
      ,[TipoVehiculo]
      ,[Descripcion]
      ,[Tipo]
      ,[CantidadPuertas]
      ,[Cilindrada]
  FROM [dbo].[Vehiculo]

END
