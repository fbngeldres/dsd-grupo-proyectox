USE [master]
GO

CREATE DATABASE [BD_SANJACINTO]
GO

USE [BD_SANJACINTO]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_marca](
	[codigo] [int] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_marca] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_estado](
	[codigo] [int] NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_estado] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_modelo](
	[codigo] [int] NOT NULL,
	[descripcion] [nvarchar](50) NULL,
	[codigo_marca] [int] NULL,
 CONSTRAINT [PK_tb_modelo] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

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

ALTER TABLE [dbo].[tb_alquiler]  WITH CHECK ADD  CONSTRAINT [FK_tb_alquiler_tb_auto] FOREIGN KEY([codigo_auto])
REFERENCES [dbo].[tb_auto] ([codigo])
GO
ALTER TABLE [dbo].[tb_alquiler] CHECK CONSTRAINT [FK_tb_alquiler_tb_auto]
GO

ALTER TABLE [dbo].[tb_alquiler]  WITH CHECK ADD  CONSTRAINT [FK_tb_alquiler_tb_usuario] FOREIGN KEY([codigo_usuario])
REFERENCES [dbo].[tb_usuario] ([codigo])
GO
ALTER TABLE [dbo].[tb_alquiler] CHECK CONSTRAINT [FK_tb_alquiler_tb_usuario]
GO

ALTER TABLE [dbo].[tb_auto]  WITH CHECK ADD  CONSTRAINT [FK_tb_auto_tb_estado] FOREIGN KEY([estado])
REFERENCES [dbo].[tb_estado] ([codigo])
GO
ALTER TABLE [dbo].[tb_auto] CHECK CONSTRAINT [FK_tb_auto_tb_estado]
GO

ALTER TABLE [dbo].[tb_auto]  WITH CHECK ADD  CONSTRAINT [FK_tb_auto_tb_marca] FOREIGN KEY([marca])
REFERENCES [dbo].[tb_marca] ([codigo])
GO
ALTER TABLE [dbo].[tb_auto] CHECK CONSTRAINT [FK_tb_auto_tb_marca]
GO

ALTER TABLE [dbo].[tb_auto]  WITH CHECK ADD  CONSTRAINT [FK_tb_auto_tb_modelo] FOREIGN KEY([modelo])
REFERENCES [dbo].[tb_modelo] ([codigo])
GO
ALTER TABLE [dbo].[tb_auto] CHECK CONSTRAINT [FK_tb_auto_tb_modelo]
GO

ALTER TABLE [dbo].[tb_devolucion]  WITH CHECK ADD  CONSTRAINT [FK_tb_devolucion_tb_alquiler] FOREIGN KEY([codigo_alquiler])
REFERENCES [dbo].[tb_alquiler] ([codigo])
GO
ALTER TABLE [dbo].[tb_devolucion] CHECK CONSTRAINT [FK_tb_devolucion_tb_alquiler]
GO

ALTER TABLE [dbo].[tb_modelo]  WITH CHECK ADD  CONSTRAINT [FK_tb_modelo_tb_marca] FOREIGN KEY([codigo_marca])
REFERENCES [dbo].[tb_marca] ([codigo])
GO
ALTER TABLE [dbo].[tb_modelo] CHECK CONSTRAINT [FK_tb_modelo_tb_marca]
GO

INSERT INTO tb_marca(codigo, descripcion) VALUES (1, 'TOYOTA');
INSERT INTO tb_marca(codigo, descripcion) VALUES (2, 'VOLKSWAGEN');
INSERT INTO tb_marca(codigo, descripcion) VALUES (3, 'VOLVO');
INSERT INTO tb_marca(codigo, descripcion) VALUES (4, 'SUZUKI');
INSERT INTO tb_marca(codigo, descripcion) VALUES (5, 'MITSUBISHI');
INSERT INTO tb_marca(codigo, descripcion) VALUES (6, 'HONDA');
INSERT INTO tb_marca(codigo, descripcion) VALUES (7, 'HYUNDAI');
INSERT INTO tb_marca(codigo, descripcion) VALUES (8, 'KIA');

INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (1, 'RAV4', 1);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (2, 'Yaris', 1);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (3, 'Prius', 1);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (4, 'Golf', 2);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (5, 'Beetle', 2);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (6, 'Tiguan', 2);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (7, 'XC60', 3);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (8, 'S60', 3);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (9, 'V40', 3);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (10, 'SWIFT', 4);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (11, 'GRAND VITARA', 4);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (12, 'SX4', 4);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (13, 'ASX', 5);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (14, 'Montero', 5);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (15, 'Outlander', 5);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (16, 'Civic', 6);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (17, 'CR-V', 6);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (18, 'Accord', 6);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (19, 'ix35', 7);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (20, 'i30', 7);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (21, 'Santa Fe', 7);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (22, 'Sportage', 8);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (23, 'Sorento', 8);
INSERT INTO tb_modelo(codigo, descripcion, codigo_marca) VALUES (24, 'Optima', 8);

INSERT INTO tb_estado(codigo, descripcion) VALUES (1, 'Libre');
INSERT INTO tb_estado(codigo, descripcion) VALUES (2, 'Alquilado');
INSERT INTO tb_estado(codigo, descripcion) VALUES (3, 'En mantenimiento');