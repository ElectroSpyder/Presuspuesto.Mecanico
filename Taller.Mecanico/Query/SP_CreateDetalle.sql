USE [dbTaller]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea detalle
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateDetalle]
	
	@PresupuestoId int,
	@DesperfectoId int
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Detalle(PresupuestoId, DesperfectoId )
	VALUES (@PresupuestoId, @DesperfectoId )

	SELECT SCOPE_IDENTITY();
END
