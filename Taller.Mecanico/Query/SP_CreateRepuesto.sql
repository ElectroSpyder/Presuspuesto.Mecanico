USE [dbTaller]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 14-02-2024
-- Description:	Crea un repuesto
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateRepuesto]
	-- Add the parameters for the stored procedure here
	@Nombre nvarchar(50),
	@Precio decimal(18,6)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Repuesto(Nombre, Precio)
	VALUES (@Nombre, @Precio )

	SELECT SCOPE_IDENTITY();
END
