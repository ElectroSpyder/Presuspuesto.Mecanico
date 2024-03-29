USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteDesperfecto]    Script Date: 18/2/2024 10:27:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 18-02-2024
-- Description:	borrar  desperfecto
-- =============================================
ALTER PROCEDURE [dbo].[SP_DeleteDesperfecto]
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM Desperfecto WHERE Id = @Id;

	SELECT @@ROWCOUNT;
END
