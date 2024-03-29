USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllDesperfecto]    Script Date: 20/2/2024 21:44:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllDesperfectoRepuestoByIdDesperfecto]
@Id integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [DesperfectosId]
		  ,[RepuestosId]
	  FROM [dbo].[DesperfectoRepuesto]
	  WHERE DesperfectosId = @Id

END
