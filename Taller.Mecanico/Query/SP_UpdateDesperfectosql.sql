USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateDesperfecto]    Script Date: 18/2/2024 10:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
CREATE  PROCEDURE [dbo].[SP_UpdateDesperfecto]
	-- Add the parameters for the stored procedure here
	@Descripcion nvarchar(50),
	@ManoDeObra int,
	@Tiempo int,
	@PresupuestoId int

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE Desperfecto
	SET Descripcion = @Descripcion,
	ManoDeObra = @ManoDeObra ,
	Tiempo = @Tiempo ,
	PresupuestoId =@PresupuestoId
	
	SELECT @@ROWCOUNT;
END
