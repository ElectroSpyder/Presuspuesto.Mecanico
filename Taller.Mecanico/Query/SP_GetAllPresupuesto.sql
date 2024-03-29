USE [dbTaller]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 20-02-2024
-- Description:	Obtiene todos los presupuestos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllPresupuesto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Nombre]
      ,[Apellido]
      ,[Email]
      ,[Total]
      ,[VehiculoId]
  FROM [dbo].[Presupuesto]

END
