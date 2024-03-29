USE [master]
GO
/****** Object:  Database [dbTaller]    Script Date: 21/2/2024 16:18:47 ******/
CREATE DATABASE [dbTaller]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbTaller', FILENAME = N'E:\Project\Taller\Taller.Mecanico\dbTaller.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbTaller_log', FILENAME = N'E:\Project\Taller\Taller.Mecanico\dbTaller_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbTaller].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbTaller] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbTaller] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbTaller] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbTaller] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbTaller] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbTaller] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbTaller] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbTaller] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbTaller] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbTaller] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbTaller] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbTaller] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbTaller] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbTaller] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbTaller] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbTaller] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbTaller] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbTaller] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbTaller] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbTaller] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbTaller] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbTaller] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbTaller] SET RECOVERY FULL 
GO
ALTER DATABASE [dbTaller] SET  MULTI_USER 
GO
ALTER DATABASE [dbTaller] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbTaller] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbTaller] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbTaller] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbTaller', N'ON'
GO
USE [dbTaller]
GO
/****** Object:  Table [dbo].[Desperfecto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desperfecto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[ManoDeObra] [decimal](18, 0) NULL,
	[Tiempo] [int] NULL,
 CONSTRAINT [PK_Desperfecto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DesperfectoRepuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DesperfectoRepuesto](
	[DesperfectosId] [int] NOT NULL,
	[RepuestosId] [int] NOT NULL,
 CONSTRAINT [PK_DesperfectoRepuesto] PRIMARY KEY CLUSTERED 
(
	[DesperfectosId] ASC,
	[RepuestosId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[PresupuestoId] [int] NOT NULL,
	[DesperfectoId] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Detalle] PRIMARY KEY CLUSTERED 
(
	[PresupuestoId] ASC,
	[DesperfectoId] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presupuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presupuesto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Total] [decimal](18, 0) NULL,
	[VehiculoId] [int] NULL,
 CONSTRAINT [PK_Presupuesto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repuesto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Precio] [decimal](18, 6) NULL,
 CONSTRAINT [PK_Repuesto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculo]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](50) NULL,
	[Modelo] [nvarchar](50) NULL,
	[Patente] [nvarchar](50) NULL,
	[TipoVehiculo] [nchar](13) NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Tipo] [int] NULL,
	[CantidadPuertas] [int] NULL,
	[Cilindrada] [nvarchar](50) NULL,
 CONSTRAINT [PK_Vehiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DesperfectoRepuesto]  WITH CHECK ADD  CONSTRAINT [FK_DesperfectoRepuesto_Desperfecto] FOREIGN KEY([DesperfectosId])
REFERENCES [dbo].[Desperfecto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DesperfectoRepuesto] CHECK CONSTRAINT [FK_DesperfectoRepuesto_Desperfecto]
GO
ALTER TABLE [dbo].[DesperfectoRepuesto]  WITH CHECK ADD  CONSTRAINT [FK_DesperfectoRepuesto_Repuesto] FOREIGN KEY([RepuestosId])
REFERENCES [dbo].[Repuesto] ([Id])
GO
ALTER TABLE [dbo].[DesperfectoRepuesto] CHECK CONSTRAINT [FK_DesperfectoRepuesto_Repuesto]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Desperfecto] FOREIGN KEY([DesperfectoId])
REFERENCES [dbo].[Desperfecto] ([Id])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Desperfecto]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Presupuesto] FOREIGN KEY([PresupuestoId])
REFERENCES [dbo].[Presupuesto] ([Id])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Presupuesto]
GO
ALTER TABLE [dbo].[Presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_Presupuesto_Vehiculo] FOREIGN KEY([VehiculoId])
REFERENCES [dbo].[Vehiculo] ([Id])
GO
ALTER TABLE [dbo].[Presupuesto] CHECK CONSTRAINT [FK_Presupuesto_Vehiculo]
GO
/****** Object:  StoredProcedure [dbo].[SP_CargaRepuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
EXEC dbo.MassiveCharge 
*/

/*****************************************************************************************/
/*+                                                                                      */
/*+ Nombre  : dbo.MassiveCharge, update from Pedro Gonzalez  15-02-2024                                                        */
/*+ Objetivo: Insertar en la BD una serie de Respuestos con sus Precios                  */
/*+                                                                                      */
/*****************************************************************************************/

CREATE  PROC [dbo].[SP_CargaRepuesto] AS
BEGIN

/*+ Creación de la tabla Temporal que contendrá los Repuestos con sus precios*/

    CREATE TABLE #TMP_RESPUESTO (Nombre VARCHAR(100),
                                 Precio DECIMAL(18,6))

/*+ Se generan los registros en la tabla temporal que posteriormente se evaluarán para ver 
si procede su carga en la tabla definitiva de Repuestos*/

    BEGIN /*+ BEGIN INSERT EN LA TEMPORAL DE RESPUESTOS*/
        INSERT INTO #TMP_RESPUESTO VALUES ('B356963821', 17.61)
        INSERT INTO #TMP_RESPUESTO VALUES ('B881468337', 40.88)
        INSERT INTO #TMP_RESPUESTO VALUES ('B867719836', 87.76)
        INSERT INTO #TMP_RESPUESTO VALUES ('B397571688', 13.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B852883143', 47.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B461882670', 22.68)
        INSERT INTO #TMP_RESPUESTO VALUES ('B333520964', 82.28)
        INSERT INTO #TMP_RESPUESTO VALUES ('B388445039', 50.71)
        INSERT INTO #TMP_RESPUESTO VALUES ('B648201513', 21.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B436759416', 35.39)
        INSERT INTO #TMP_RESPUESTO VALUES ('B317533243', 22.84)
        INSERT INTO #TMP_RESPUESTO VALUES ('B666592414', 58.67)
        INSERT INTO #TMP_RESPUESTO VALUES ('B443568817', 53.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B316416378', 17.74)
        INSERT INTO #TMP_RESPUESTO VALUES ('B252543362', 16.98)
        INSERT INTO #TMP_RESPUESTO VALUES ('B453148609', 14.23)
        INSERT INTO #TMP_RESPUESTO VALUES ('B254958806', 41.19)
        INSERT INTO #TMP_RESPUESTO VALUES ('B356963821', 62.58)
        INSERT INTO #TMP_RESPUESTO VALUES ('B846487171', 92.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B397571688', 1.04)
        INSERT INTO #TMP_RESPUESTO VALUES ('B535169105', 90.14)
        INSERT INTO #TMP_RESPUESTO VALUES ('B628263302', 78.64)
        INSERT INTO #TMP_RESPUESTO VALUES ('B608816685', 93.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B660755442', 43.62)
        INSERT INTO #TMP_RESPUESTO VALUES ('B659053715', 90.59)
        INSERT INTO #TMP_RESPUESTO VALUES ('B556344166', 71.62)
        INSERT INTO #TMP_RESPUESTO VALUES ('B216140665', 93.15)
        INSERT INTO #TMP_RESPUESTO VALUES ('B843858581', 66.52)
        INSERT INTO #TMP_RESPUESTO VALUES ('B790077756', 8.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B916071768', 85.46)
        INSERT INTO #TMP_RESPUESTO VALUES ('B317533243', 7.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B343454513', 22.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B986574036', 65.10)
        INSERT INTO #TMP_RESPUESTO VALUES ('B662139869', 3.50)
        INSERT INTO #TMP_RESPUESTO VALUES ('B618792223', 6.87)
        INSERT INTO #TMP_RESPUESTO VALUES ('B578485476', 49.70)
        INSERT INTO #TMP_RESPUESTO VALUES ('B132813434', 32.58)
        INSERT INTO #TMP_RESPUESTO VALUES ('B776163235', 73.64)
        INSERT INTO #TMP_RESPUESTO VALUES ('B215908676', 92.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B871139440', 31.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B564893705', 18.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B634131771', 70.35)
        INSERT INTO #TMP_RESPUESTO VALUES ('B321187273', 91.96)
        INSERT INTO #TMP_RESPUESTO VALUES ('B444737823', 78.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B413525993', 9.93)
        INSERT INTO #TMP_RESPUESTO VALUES ('B229547877', 97.08)
        INSERT INTO #TMP_RESPUESTO VALUES ('B545788950', 11.84)
        INSERT INTO #TMP_RESPUESTO VALUES ('B658514562', 8.84)
        INSERT INTO #TMP_RESPUESTO VALUES ('B736313138', 78.47)
        INSERT INTO #TMP_RESPUESTO VALUES ('B840888802', 93.85)
        INSERT INTO #TMP_RESPUESTO VALUES ('B883572821', 21.57)
        INSERT INTO #TMP_RESPUESTO VALUES ('B493478663', 76.98)
        INSERT INTO #TMP_RESPUESTO VALUES ('B718838840', 7.41)
        INSERT INTO #TMP_RESPUESTO VALUES ('B183671709', 45.53)
        INSERT INTO #TMP_RESPUESTO VALUES ('B908384721', 14.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B566417680', 44.04)
        INSERT INTO #TMP_RESPUESTO VALUES ('B633833113', 33.28)
        INSERT INTO #TMP_RESPUESTO VALUES ('B829258206', 41.74)
        INSERT INTO #TMP_RESPUESTO VALUES ('B350041352', 85.13)
        INSERT INTO #TMP_RESPUESTO VALUES ('B548168477', 7.44)
        INSERT INTO #TMP_RESPUESTO VALUES ('B765657146', 89.79)
        INSERT INTO #TMP_RESPUESTO VALUES ('B830231322', 81.42)
        INSERT INTO #TMP_RESPUESTO VALUES ('B816385774', 9.30)
        INSERT INTO #TMP_RESPUESTO VALUES ('B857448796', 77.36)
        INSERT INTO #TMP_RESPUESTO VALUES ('B302875266', 54.89)
        INSERT INTO #TMP_RESPUESTO VALUES ('B790507487', 50.41)
        INSERT INTO #TMP_RESPUESTO VALUES ('B723629401', 65.36)
        INSERT INTO #TMP_RESPUESTO VALUES ('B595728629', 19.94)
        INSERT INTO #TMP_RESPUESTO VALUES ('B472436824', 65.69)
        INSERT INTO #TMP_RESPUESTO VALUES ('B235859870', 66.44)
        INSERT INTO #TMP_RESPUESTO VALUES ('B874178252', 42.38)
        INSERT INTO #TMP_RESPUESTO VALUES ('B777713850', 40.26)
        INSERT INTO #TMP_RESPUESTO VALUES ('B550221285', 8.72)
        INSERT INTO #TMP_RESPUESTO VALUES ('B816043247', 73.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B607313788', 15.95)
        INSERT INTO #TMP_RESPUESTO VALUES ('B396482694', 45.17)
        INSERT INTO #TMP_RESPUESTO VALUES ('B504021331', 24.52)
        INSERT INTO #TMP_RESPUESTO VALUES ('B651475349', 86.77)
        INSERT INTO #TMP_RESPUESTO VALUES ('B470409863', 11.81)
        INSERT INTO #TMP_RESPUESTO VALUES ('B264135435', 62.58)
        INSERT INTO #TMP_RESPUESTO VALUES ('B755636151', 33.88)
        INSERT INTO #TMP_RESPUESTO VALUES ('B382183955', 0.92)
        INSERT INTO #TMP_RESPUESTO VALUES ('B667316286', 0.29)
        INSERT INTO #TMP_RESPUESTO VALUES ('B783117048', 41.57)
        INSERT INTO #TMP_RESPUESTO VALUES ('B812952354', 86.25)
        INSERT INTO #TMP_RESPUESTO VALUES ('B621838237', 80.54)
        INSERT INTO #TMP_RESPUESTO VALUES ('B665465223', 53.69)
        INSERT INTO #TMP_RESPUESTO VALUES ('B881682635', 64.78)
        INSERT INTO #TMP_RESPUESTO VALUES ('B646289861', 72.01)
        INSERT INTO #TMP_RESPUESTO VALUES ('B852115667', 48.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B144635415', 34.23)
        INSERT INTO #TMP_RESPUESTO VALUES ('B874863828', 24.70)
        INSERT INTO #TMP_RESPUESTO VALUES ('B333841476', 41.57)
        INSERT INTO #TMP_RESPUESTO VALUES ('B587386017', 45.27)
        INSERT INTO #TMP_RESPUESTO VALUES ('B874270576', 42.38)
        INSERT INTO #TMP_RESPUESTO VALUES ('B300733136', 25.55)
        INSERT INTO #TMP_RESPUESTO VALUES ('B611446656', 60.12)
        INSERT INTO #TMP_RESPUESTO VALUES ('B801300387', 61.04)
        INSERT INTO #TMP_RESPUESTO VALUES ('B845153562', 60.09)
        INSERT INTO #TMP_RESPUESTO VALUES ('B943846621', 37.05)
    END /*+ END INSERT EN LA TEMPORAL DE RESPUESTOS*/

	BEGIN /*INICIO DE LOGICA*/
		DECLARE
			@Nombre varchar(50),
			@Precio decimal(18,6),
			@UpdatePrecio decimal(18,6),
			@UpdateNombre varchar(50),
			@Total nvarchar,
			@Estado int

		DECLARE	@TRepuestos table(Nombre varchar(50), Precio decimal(18,6))

		DECLARE cProcesoRepuesto CURSOR LOCAL FORWARD_ONLY FAST_FORWARD 
			FOR SELECT Nombre, Precio FROM #TMP_RESPUESTO
				
		OPEN cProcesoRepuesto

			FETCH NEXT FROM cProcesoRepuesto INTO @Nombre, @Precio
			WHILE @@FETCH_STATUS = 0

			BEGIN
				SET @Estado = 0

				DECLARE cUpdateIfExist CURSOR LOCAL FORWARD_ONLY FAST_FORWARD 
				FOR SELECT Nombre, Precio from Repuesto 
				
				OPEN cUpdateIfExist 

				FETCH NEXT FROM cUpdateIfExist INTO @UpdateNombre, @UpdatePrecio
				WHILE @@FETCH_STATUS = 0

					BEGIN
						IF @Nombre = @UpdateNombre
						BEGIN						
							UPDATE Repuesto SET Precio = @Precio + @UpdatePrecio WHERE Nombre = @Nombre ;
							SET @Estado = 1
						END

						FETCH NEXT FROM cUpdateIfExist INTO @UpdateNombre, @UpdatePrecio
					END

				CLOSE cUpdateIfExist  --final del cursor
				DEALLOCATE cUpdateIfExist
				
				IF @Estado = 0
					BEGIN
						IF @Precio < 20 
							BEGIN
								INSERT INTO Repuesto (Nombre, Precio) VALUES (@Nombre, @Precio)
							END
						ELSE
							BEGIN
								INSERT INTO @TRepuestos(Nombre, Precio) VALUES(@Nombre, @Precio)						
							END
					END
				FETCH NEXT FROM cProcesoRepuesto INTO @Nombre, @Precio
				
			END
			CLOSE cProcesoRepuesto
			DEALLOCATE cProcesoRepuesto

	END /*FIN DE LOGICA*/
	SELECT * FROM @TRepuestos
END   
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateDesperfecto]    Script Date: 21/2/2024 16:18:47 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateDetalle]    Script Date: 21/2/2024 16:18:47 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[SP_CreatePresupuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreatePresupuesto]
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
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateRepuesto]    Script Date: 21/2/2024 16:18:47 ******/
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
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateVehiculo]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Incerta un vehiculo ya sea Automovil o Moto
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateVehiculo]
	-- Add the parameters for the stored procedure here
	@Marca nvarchar(50),
    @Modelo nvarchar(50),
	@Patente nvarchar(50),	
	@TipoVehiculo nchar(13),
	@Descripcion nvarchar(50),
	@Tipo int,
	@CantidadPuertas int,
	@Cilindrada nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Vehiculo (Marca ,Modelo ,Patente, TipoVehiculo ,Descripcion ,Tipo ,CantidadPuertas ,Cilindrada )
	VALUES (@Marca , @Modelo , @Patente , @TipoVehiculo , @Descripcion , @Tipo , @CantidadPuertas , @Cilindrada )

	SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteDesperfecto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 18-02-2024
-- Description:	borrar  desperfecto
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteDesperfecto]
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
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePresupuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 18-02-2024
-- Description:	borrar  Presupuesto
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeletePresupuesto]
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM Presupuesto WHERE Id = @Id;

	SELECT @@ROWCOUNT;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteRepuesto]    Script Date: 21/2/2024 16:18:47 ******/
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

	SELECT @@ROWCOUNT;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteVehiculo]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 18-02-2024
-- Description:	borrar  ya sea Automovil o Moto
-- =============================================
CREATE PROCEDURE [dbo].[SP_DeleteVehiculo]
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
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllDesperfecto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllDesperfecto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Id
      ,Descripcion
      ,ManoDeObra
	  ,Tiempo	  
  FROM [dbo].Desperfecto

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllDesperfectoRepuestoByIdDesperfecto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllDesperfectoRepuestoByIdDesperfecto]
@Id integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [DesperfectosId]
		  ,[RepuestosId]
	  FROM [dbo].[DesperfectoRepuesto]
	  WHERE DesperfectosId = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllDetalleByIdPresupuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea detalle
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllDetalleByIdPresupuesto]
	
	@Id int
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [PresupuestoId]
      ,[DesperfectoId]
      ,[Id]
  FROM [dbo].[Detalle]
  WHERE PresupuestoId = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllPresupuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 20-02-2024
-- Description:	Obtiene todos los presupuestos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllPresupuesto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Nombre]
      ,[Apellido]
      ,[Email]
      ,[Total]
      ,[VehiculoId]
  FROM [dbo].[Presupuesto]

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllRepuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 14-02-2024
-- Description:	Obtiene todos los REPUESTOS
-- =============================================
CREATE  PROCEDURE [dbo].[SP_GetAllRepuesto]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Id
      ,Nombre, Precio
  FROM [dbo].Repuesto

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllVehiculo]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 11-02-2024
-- Description:	Obtiene todos los vehiculo ya sea Automovil o Moto
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllVehiculo]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT [Id]
      ,[Marca]
      ,[Modelo]
      ,[Patente]      
      ,[TipoVehiculo]
      ,[Descripcion]
      ,[Tipo]
      ,[CantidadPuertas]
      ,[Cilindrada]
  FROM [dbo].[Vehiculo]

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetPromedio]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetPromedio]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT avg(p.Total) as Promedio, v.Marca, v.Modelo
    FROM Presupuesto p    
    INNER JOIN Vehiculo v ON v.Id = p.VehiculoId
    GROUP BY v.Marca, v.Modelo

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetRepuestoMasUtilizado]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene todos los Desperfectos
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetRepuestoMasUtilizado]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT top 1 COUNT(r.id) as Cantidad,  MAX(r.Nombre) as Descripcion
    FROM Presupuesto p
    INNER JOIN Detalle de ON p.Id = de.PresupuestoId
    INNER JOIN Desperfecto d ON de.DesperfectoId = d.Id
    INNER JOIN DesperfectoRepuesto dr ON dr.DesperfectosId = d.Id
    INNER JOIN Repuesto r ON r.Id = dr.RepuestosId
    INNER JOIN Vehiculo v ON v.Id = p.VehiculoId
    GROUP BY v.Marca, v.Modelo
	order by cantidad desc

END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTotalPresupuestoPorVehiculo]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 13-02-2024
-- Description:	Obtiene suma de presupuestos segun tipo de vehiculo
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetTotalPresupuestoPorVehiculo]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT sum(p.Total) as Total,  v.TipoVehiculo
    FROM Presupuesto p    
    INNER JOIN Vehiculo v ON v.Id = p.VehiculoId
    GROUP BY v.TipoVehiculo

END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateDesperfecto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	Crea un desperfecto
-- =============================================
CREATE  PROCEDURE [dbo].[SP_UpdateDesperfecto]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Descripcion nvarchar(50),
	@ManoDeObra int,
	@Tiempo int,
	@PresupuestoId int

AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE Desperfecto
		SET Descripcion = @Descripcion,
		ManoDeObra = @ManoDeObra ,
		Tiempo = @Tiempo ,
		PresupuestoId =@PresupuestoId
	WHERE Id = @Id
	
	SELECT @@ROWCOUNT;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePresupuesto]    Script Date: 21/2/2024 16:18:47 ******/
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
	UPDATE Presupuesto 
	SET Nombre = @Nombre, 
		Apellido = @Apellido, 
		Email = @Email, 
		Total = @Total, 
		VehiculoId = @VehiculoId

	SELECT @@ROWCOUNT;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateRepuesto]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 14-02-2024
-- Description:	actualiza repuesto
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdateRepuesto]
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
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateVehiculo]    Script Date: 21/2/2024 16:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pedro Gonzalez
-- Create date: 10-02-2024
-- Description:	actualizar Automovil o Moto
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdateVehiculo]
	-- Add the parameters for the stored procedure here
	@Id int,
	@Marca nvarchar(50),
    @Modelo nvarchar(50),
	@Patente nvarchar(50),
	@PresupuestoId int,
	@TipoVehiculo nchar(13),
	@Descripcion nvarchar(50),
	@Tipo int,
	@CantidadPuertas int,
	@Cilindrada nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE Vehiculo
    -- Insert statements for procedure here
	SET Marca = @Marca ,
		Modelo = @Modelo,
		Patente = @Patente, 
		PresupuestoId = @PresupuestoId ,
		TipoVehiculo = @TipoVehiculo ,
		Descripcion = @Descripcion ,
		Tipo = @Tipo ,
		CantidadPuertas = @CantidadPuertas,
		Cilindrada = @Cilindrada 
	WHERE Id = @Id

	SELECT @@ROWCOUNT;
END
GO
USE [master]
GO
ALTER DATABASE [dbTaller] SET  READ_WRITE 
GO
