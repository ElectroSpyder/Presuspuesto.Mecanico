USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateDetalle]    Script Date: 20/2/2024 21:09:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea detalle
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllDetalleByIdPresupuesto]
	
	@Id int
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [PresupuestoId]
      ,[DesperfectoId]
      ,[Id]
  FROM [dbo].[Detalle]
  WHERE PresupuestoId = @Id

END
