USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllDesperfecto]    Script Date: 20/2/2024 18:51:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
ALTER PROCEDURE [dbo].[SP_GetAllDesperfecto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Id
      ,Descripcion
      ,ManoDeObra
	  ,Tiempo	  
  FROM [dbo].Desperfecto

END
