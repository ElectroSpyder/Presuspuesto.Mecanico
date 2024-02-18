USE [dbTaller]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 18-02-2024
-- Description:	borrar  Repuesto
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteRepuesto]
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM Repuesto WHERE Id = @Id;

	SELECT SCOPE_IDENTITY();
END
