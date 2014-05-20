USE [master]
GO
/****** Object:  Database [BD_SANJACINTO]    Script Date: 05/17/2014 12:43:29 ******/
CREATE DATABASE [BD_SANJACINTO]
GO

USE [BD_SANJACINTO]
GO
/****** Object:  Table [dbo].[tb_usuario]    Script Date: 05/19/2014 00:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_usuario](
	[codigo] [int] NOT NULL,
	[apellidos] [nvarchar](50) NOT NULL,
	[nombres] [nvarchar](50) NOT NULL,
	[telefono] [nvarchar](50) NOT NULL,
	[licencia] [nvarchar](50) NOT NULL,
	[dni] [nvarchar](50) NOT NULL,
	[codigo_rol] [int] NOT NULL,
	[correo] [nvarchar](50) NULL,
	[clave] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_usuario] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_auto]    Script Date: 05/19/2014 00:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_auto](
	[codigo] [int] NOT NULL,
	[marca] [int] NOT NULL,
	[modelo] [int] NOT NULL,
	[precio] [decimal](10, 2) NOT NULL,
	[categoria] [int] NOT NULL,
	[estado] [int] NOT NULL,
	[placa] [nvarchar](50) NOT NULL,
	[imagen] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_auto] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_alquiler]    Script Date: 05/19/2014 00:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_alquiler](
	[codigo] [int] NOT NULL,
	[codigo_usuario] [int] NOT NULL,
	[fecha_inicio] [datetime] NULL,
	[fecha_fin] [datetime] NULL,
	[costo] [decimal](10, 2) NOT NULL,
	[costo_adicional] [decimal](10, 2) NULL,
	[igv] [decimal](10, 2) NOT NULL,
	[cant_dias] [int] NOT NULL,
	[monto_total] [decimal](10, 2) NOT NULL,
	[codigo_auto] [int] NOT NULL,
	[accesorios] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_alquiler] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_devolucion]    Script Date: 05/19/2014 00:26:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_devolucion](
	[codigo] [int] NOT NULL,
	[codigo_alquiler] [int] NOT NULL,
	[fecha_devolucion] [datetime] NOT NULL,
	[penalidad] [decimal](10, 2) NULL,
	[igv] [decimal](10, 2) NOT NULL,
	[monto_total] [decimal](10, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_tb_alquiler_tb_auto]    Script Date: 05/19/2014 00:26:14 ******/
ALTER TABLE [dbo].[tb_alquiler]  WITH CHECK ADD  CONSTRAINT [FK_tb_alquiler_tb_auto] FOREIGN KEY([codigo_auto])
REFERENCES [dbo].[tb_auto] ([codigo])
GO
ALTER TABLE [dbo].[tb_alquiler] CHECK CONSTRAINT [FK_tb_alquiler_tb_auto]
GO
/****** Object:  ForeignKey [FK_tb_alquiler_tb_usuario]    Script Date: 05/19/2014 00:26:14 ******/
ALTER TABLE [dbo].[tb_alquiler]  WITH CHECK ADD  CONSTRAINT [FK_tb_alquiler_tb_usuario] FOREIGN KEY([codigo_usuario])
REFERENCES [dbo].[tb_usuario] ([codigo])
GO
ALTER TABLE [dbo].[tb_alquiler] CHECK CONSTRAINT [FK_tb_alquiler_tb_usuario]
GO
/****** Object:  ForeignKey [FK_tb_devolucion_tb_alquiler]    Script Date: 05/19/2014 00:26:14 ******/
ALTER TABLE [dbo].[tb_devolucion]  WITH CHECK ADD  CONSTRAINT [FK_tb_devolucion_tb_alquiler] FOREIGN KEY([codigo_alquiler])
REFERENCES [dbo].[tb_alquiler] ([codigo])
GO
ALTER TABLE [dbo].[tb_devolucion] CHECK CONSTRAINT [FK_tb_devolucion_tb_alquiler]
GO
