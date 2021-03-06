CREATE DATABASE [reservashotel]
GO
USE [reservashotel]
GO
/****** Object:  Table [dbo].[Habitacion]    Script Date: 30/12/2021 15:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitacion](
	[idhabitacion] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nvarchar](50) NULL,
	[descripcion] [nvarchar](max) NULL,
	[idhotel] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idhabitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 30/12/2021 15:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[idhotel] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[pais] [nvarchar](100) NULL,
	[latitud] [nvarchar](100) NULL,
	[longitud] [nvarchar](100) NULL,
	[descripcion] [nvarchar](max) NULL,
	[activo] [bit] NULL,
	[numerohabitaciones] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idhotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 30/12/2021 15:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[idreserva] [int] IDENTITY(1,1) NOT NULL,
	[idusuario] [int] NULL,
	[idhotel] [int] NULL,
	[idhabitacion] [int] NULL,
	[fechaentrada] [datetime] NULL,
	[fechasalida] [datetime] NULL,
	[fechareserva] [datetime] NULL,
	[estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idreserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 30/12/2021 15:12:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[apellidos] [nvarchar](100) NULL,
	[mail] [nvarchar](150) NULL,
	[direccion] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Habitacion] ON 

INSERT [dbo].[Habitacion] ([idhabitacion], [tipo], [descripcion], [idhotel]) VALUES (1, N'Indivual', N'Habitación Sencilla', 1)
INSERT [dbo].[Habitacion] ([idhabitacion], [tipo], [descripcion], [idhotel]) VALUES (2, N'Indivual', N'Habitación Sencilla', 1)
INSERT [dbo].[Habitacion] ([idhabitacion], [tipo], [descripcion], [idhotel]) VALUES (3, N'Indivual', N'Habitación Sencilla', 1)
INSERT [dbo].[Habitacion] ([idhabitacion], [tipo], [descripcion], [idhotel]) VALUES (4, N'Indivual', N'Habitación Sencilla', 2)
INSERT [dbo].[Habitacion] ([idhabitacion], [tipo], [descripcion], [idhotel]) VALUES (5, N'Indivual', N'Habitación Sencilla', 2)
SET IDENTITY_INSERT [dbo].[Habitacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([idhotel], [nombre], [pais], [latitud], [longitud], [descripcion], [activo], [numerohabitaciones]) VALUES (1, N'Hotel A', N'Colombia', N'10.963889', N'-74.796387', N'Hotel ubicado en Barranquilla', 1, 3)
INSERT [dbo].[Hotel] ([idhotel], [nombre], [pais], [latitud], [longitud], [descripcion], [activo], [numerohabitaciones]) VALUES (2, N'Hotel B', N'Colombia', N'6.230833', N'-75.590553', N'Hotel ubicado en Medellin', 1, 2)
SET IDENTITY_INSERT [dbo].[Hotel] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idusuario], [nombre], [apellidos], [mail], [direccion]) VALUES (1, N'Pepito', N'Perez', N'pperez@domain.com', N'Calle 5')
INSERT [dbo].[Usuario] ([idusuario], [nombre], [apellidos], [mail], [direccion]) VALUES (2, N'Juana', N'Fonseca', N'jfonseca@domain.com', N'Calle 6')
INSERT [dbo].[Usuario] ([idusuario], [nombre], [apellidos], [mail], [direccion]) VALUES (3, N'Alberto', N'Rivera', N'arivera@domain.com', N'Calle 7')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__7A21290482B643EB]    Script Date: 30/12/2021 15:12:52 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Habitacion]  WITH CHECK ADD FOREIGN KEY([idhotel])
REFERENCES [dbo].[Hotel] ([idhotel])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([idhabitacion])
REFERENCES [dbo].[Habitacion] ([idhabitacion])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([idhotel])
REFERENCES [dbo].[Hotel] ([idhotel])
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD FOREIGN KEY([idusuario])
REFERENCES [dbo].[Usuario] ([idusuario])
GO
