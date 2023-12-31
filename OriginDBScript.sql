USE [master]
GO
/****** Object:  Database [OriginSolutions]    Script Date: 1/9/2023 11:42:52 ******/
CREATE DATABASE [OriginSolutions]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OriginSolutions', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OriginSolutions.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OriginSolutions_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OriginSolutions_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OriginSolutions] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OriginSolutions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OriginSolutions] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OriginSolutions] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OriginSolutions] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OriginSolutions] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OriginSolutions] SET ARITHABORT OFF 
GO
ALTER DATABASE [OriginSolutions] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OriginSolutions] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OriginSolutions] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OriginSolutions] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OriginSolutions] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OriginSolutions] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OriginSolutions] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OriginSolutions] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OriginSolutions] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OriginSolutions] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OriginSolutions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OriginSolutions] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OriginSolutions] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OriginSolutions] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OriginSolutions] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OriginSolutions] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OriginSolutions] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OriginSolutions] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OriginSolutions] SET  MULTI_USER 
GO
ALTER DATABASE [OriginSolutions] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OriginSolutions] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OriginSolutions] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OriginSolutions] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OriginSolutions] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OriginSolutions] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OriginSolutions] SET QUERY_STORE = OFF
GO
USE [OriginSolutions]
GO

/****** Object:  Table [dbo].[Tarjeta]    Script Date: 1/9/2023 11:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[IdTarjeta] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](50) NOT NULL,
	[Pin] [nchar](10) NOT NULL,
	[Activa] [bit] NOT NULL,
	[Saldo] [decimal](18, 0) NOT NULL,
	[IntentosRestantes] [int] NOT NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[IdTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoOperacion]    Script Date: 1/9/2023 11:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoOperacion](
	[IdTipo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TipoOperacion] PRIMARY KEY CLUSTERED 
(
	[IdTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 1/9/2023 11:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[IdOperacion] [int] IDENTITY(1,1) NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[IdTipo] [int] NOT NULL,
	[Hora] [smalldatetime] NOT NULL,
	[Monto] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Operacion] PRIMARY KEY CLUSTERED 
(
	[IdOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Operacion] ON 

INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (1, 3, 1, CAST(N'2023-01-01T00:00:00' AS SmallDateTime), NULL)
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (3, 3, 2, CAST(N'2023-01-01T00:00:00' AS SmallDateTime), CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (4, 3, 1, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), NULL)
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (6, 7, 1, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), NULL)
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (7, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (8, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (9, 7, 1, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), NULL)
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (10, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (11, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (12, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (13, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (14, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(-1 AS Decimal(18, 0)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [IdTipo], [Hora], [Monto]) VALUES (15, 7, 2, CAST(N'2023-08-31T00:00:00' AS SmallDateTime), CAST(1 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Operacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarjeta] ON 

INSERT [dbo].[Tarjeta] ([IdTarjeta], [Numero], [Pin], [Activa], [Saldo], [IntentosRestantes]) VALUES (3, N'1234123412341234', N'1234      ', 0, CAST(0 AS Decimal(18, 0)), -1)
INSERT [dbo].[Tarjeta] ([IdTarjeta], [Numero], [Pin], [Activa], [Saldo], [IntentosRestantes]) VALUES (6, N'1111222233334444', N'4321      ', 1, CAST(1 AS Decimal(18, 0)), 3)
INSERT [dbo].[Tarjeta] ([IdTarjeta], [Numero], [Pin], [Activa], [Saldo], [IntentosRestantes]) VALUES (7, N'4444333322221111', N'1111      ', 1, CAST(360 AS Decimal(18, 0)), 3)
SET IDENTITY_INSERT [dbo].[Tarjeta] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoOperacion] ON 

INSERT [dbo].[TipoOperacion] ([IdTipo], [Descripcion]) VALUES (1, N'Balance')
INSERT [dbo].[TipoOperacion] ([IdTipo], [Descripcion]) VALUES (2, N'Retiro')
SET IDENTITY_INSERT [dbo].[TipoOperacion] OFF
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Tarjeta] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjeta] ([IdTarjeta])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Tarjeta]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_TipoOperacion] FOREIGN KEY([IdTipo])
REFERENCES [dbo].[TipoOperacion] ([IdTipo])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_TipoOperacion]
GO
/****** Object:  Trigger [dbo].[RestarSaldo]    Script Date: 1/9/2023 11:42:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[RestarSaldo]
on [dbo].[Operacion]
FOR insert
as
BEGIN
	declare @idTarjeta int =
	(select IdTarjeta FROM inserted)
	declare @idTipo int =
	(select IdTipo FROM inserted)
	
	IF @idTipo = 2
    BEGIN
	update Tarjeta 
	set Saldo = Saldo - (SELECT Monto from inserted)
	WHERE IdTarjeta = @idTarjeta
	END
END;
GO
ALTER TABLE [dbo].[Operacion] ENABLE TRIGGER [RestarSaldo]
GO
USE [master]
GO
ALTER DATABASE [OriginSolutions] SET  READ_WRITE 
GO
