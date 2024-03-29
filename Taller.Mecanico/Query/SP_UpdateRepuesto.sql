USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateRepuesto]    Script Date: 20/2/2024 13:50:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 14-02-2024
-- Description:	actualiza repuesto
-- =============================================
ALTER PROCEDURE [dbo].[SP_UpdateRepuesto]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Nombre nvarchar(50),
	@Precio decimal(18,6)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Repuesto
		SET Nombre =@Nombre , 
			Precio = @Precio
	WHERE Id= @Id

	SELECT @@ROWCOUNT;
END
