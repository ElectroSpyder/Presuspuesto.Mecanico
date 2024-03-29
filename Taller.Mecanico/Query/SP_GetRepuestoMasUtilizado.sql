USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllDesperfecto]    Script Date: 21/2/2024 10:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetRepuestoMasUtilizado]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT top 1 COUNT(r.id) as Cantidad,  MAX(r.Nombre) as Descripcion
    FROM Presupuesto p
    INNER JOIN Detalle de ON p.Id = de.PresupuestoId
    INNER JOIN Desperfecto d ON de.DesperfectoId = d.Id
    INNER JOIN DesperfectoRepuesto dr ON dr.DesperfectosId = d.Id
    INNER JOIN Repuesto r ON r.Id = dr.RepuestosId
    INNER JOIN Vehiculo v ON v.Id = p.VehiculoId
    GROUP BY v.Marca, v.Modelo
	order by cantidad desc

END
