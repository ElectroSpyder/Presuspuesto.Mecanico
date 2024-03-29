USE [dbTaller]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePresupuesto]    Script Date: 20/2/2024 18:48:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
ALTER PROCEDURE [dbo].[SP_CreatePresupuesto]
	-- Add the parameters for the stored procedure here
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@Email nvarchar(50),
	@Total decimal(18,6),
	@VehiculoId int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Presupuesto(Nombre, Apellido, Email, Total, VehiculoId )
	VALUES ( @Nombre, @Apellido, @Email, @Total, @VehiculoId )

	SELECT SCOPE_IDENTITY();
END
