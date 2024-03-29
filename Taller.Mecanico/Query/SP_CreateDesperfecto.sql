USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateDesperfecto]    Script Date: 20/2/2024 18:47:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
ALTER PROCEDURE [dbo].[SP_CreateDesperfecto]
	-- Add the parameters for the stored procedure here
	@Descripcion nvarchar(50),
	@ManoDeObra int,
	@Tiempo int
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Desperfecto(Descripcion , ManoDeObra , Tiempo )
	VALUES (@Descripcion , @ManoDeObra , @Tiempo )

	SELECT SCOPE_IDENTITY();
END
