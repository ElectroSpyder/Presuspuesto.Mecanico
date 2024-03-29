USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateDesperfecto]    Script Date: 20/2/2024 13:51:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
ALTER  PROCEDURE [dbo].[SP_UpdateDesperfecto]
	-- Add the parameters for the stored procedure here
	@Id int,
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
	WHERE Id = @Id
	
	SELECT @@ROWCOUNT;
END
