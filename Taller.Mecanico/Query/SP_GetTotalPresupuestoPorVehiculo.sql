USE [dbTaller]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene suma de presupuestos segun tipo de vehiculo
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetTotalPresupuestoPorVehiculo]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT sum(p.Total) as Total,  v.TipoVehiculo
    FROM Presupuesto p    
    INNER JOIN Vehiculo v ON v.Id = p.VehiculoId
    GROUP BY v.TipoVehiculo

END
