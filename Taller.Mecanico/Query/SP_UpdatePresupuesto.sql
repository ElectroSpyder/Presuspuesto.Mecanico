USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePresupuesto]    Script Date: 18/2/2024 11:03:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdatePresupuesto]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@Email nvarchar(50),
	@Total decimal(18,6)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE Presupuesto
	SET Nombre = @Nombre,
		Apellido = @Apellido, 
		Email = @Email,
		Total = @Total
	WHERE Id = @Id

	SELECT @@ROWCOUNT;
END
