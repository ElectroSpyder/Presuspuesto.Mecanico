USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteVehiculo]    Script Date: 18/2/2024 10:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 18-02-2024
-- Description:	borrar  ya sea Automovil o Moto
-- =============================================
ALTER PROCEDURE [dbo].[SP_DeleteVehiculo]
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM Vehiculo WHERE iD = @Id;

	SELECT @@ROWCOUNT;
END
