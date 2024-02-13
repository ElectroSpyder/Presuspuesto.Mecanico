USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateVehiculo]    Script Date: 13/2/2024 11:24:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateDesperfecto]
	-- Add the parameters for the stored procedure here
	@Descripcion nvarchar(50),
	@ManoDeObra int,
	@Tiempo int,
	@PresupuestoId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Desperfecto(Descripcion , ManoDeObra , Tiempo ,PresupuestoId )
	VALUES (@Descripcion , @ManoDeObra , @Tiempo , @PresupuestoId )

	SELECT SCOPE_IDENTITY();
END
