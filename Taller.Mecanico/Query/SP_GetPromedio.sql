USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetRepuestoMasUtilizado]    Script Date: 21/2/2024 12:06:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetPromedio]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT avg(p.Total) as Promedio, v.Marca, v.Modelo
    FROM Presupuesto p    
    INNER JOIN Vehiculo v ON v.Id = p.VehiculoId
    GROUP BY v.Marca, v.Modelo

END
