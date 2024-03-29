USE [dbTaller]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 14-02-2024
-- Description:	Obtiene todos los REPUESTOS
-- =============================================
CREATE  PROCEDURE [dbo].[SP_GetAllRepuesto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Id
      ,Nombre, Precio
  FROM [dbo].Repuesto

END
