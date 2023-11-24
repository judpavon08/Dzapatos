USE [master]
GO
/****** Object:  Database [Dzapatos1]    Script Date: 23/11/2023 10:12:03 ******/
CREATE DATABASE [Dzapatos1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dzapatos1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dzapatos1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Dzapatos1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Dzapatos1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Dzapatos1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dzapatos1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dzapatos1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dzapatos1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dzapatos1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dzapatos1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dzapatos1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dzapatos1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dzapatos1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dzapatos1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dzapatos1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dzapatos1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dzapatos1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dzapatos1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dzapatos1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dzapatos1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dzapatos1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Dzapatos1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dzapatos1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dzapatos1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dzapatos1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dzapatos1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dzapatos1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dzapatos1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dzapatos1] SET RECOVERY FULL 
GO
ALTER DATABASE [Dzapatos1] SET  MULTI_USER 
GO
ALTER DATABASE [Dzapatos1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dzapatos1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dzapatos1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dzapatos1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Dzapatos1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Dzapatos1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dzapatos1', N'ON'
GO
ALTER DATABASE [Dzapatos1] SET QUERY_STORE = OFF
GO
USE [Dzapatos1]
GO
/****** Object:  Table [dbo].[BODEGA]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BODEGA](
	[ID_BODEGA] [int] NOT NULL,
	[NOMBRE_BODEGA] [varchar](30) NULL,
	[ID_PRODUCTO] [char](5) NULL,
	[DIRECCION] [varchar](30) NULL,
 CONSTRAINT [PK__BODEGA__49832761E2DD49E5] PRIMARY KEY CLUSTERED 
(
	[ID_BODEGA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIA]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA](
	[ID_CATEGORIA] [int] NOT NULL,
	[Estado] [bit] NULL,
	[Descripcion] [varchar](100) NULL,
	[Nombre_Categoria] [varchar](100) NULL,
	[Nombre] [varchar](100) NULL,
	[FechaIngreso] [datetime] NULL,
 CONSTRAINT [PK__CATEGORI__4BD51FA5ACF3869E] PRIMARY KEY CLUSTERED 
(
	[ID_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[COLOR]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COLOR](
	[ID_COLOR] [int] NOT NULL,
	[NOMBRE_COLOR] [varchar](30) NULL,
 CONSTRAINT [PK__COLOR__4B477D777EF9DCBC] PRIMARY KEY CLUSTERED 
(
	[ID_COLOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_fac_compra]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_fac_compra](
	[id_detalle_compra] [int] NOT NULL,
	[id_producto] [int] NULL,
	[id_fac_compra] [int] NULL,
	[cantidad] [varchar](30) NULL,
	[precio] [varchar](30) NULL,
	[rebajas] [varchar](30) NULL,
	[iva] [varchar](30) NULL,
	[monto_pago] [varchar](30) NULL,
	[monto_devolucion] [varchar](30) NULL,
	[tipo_transaccion] [varchar](30) NULL,
 CONSTRAINT [PK__detalle___BD16E27921375519] PRIMARY KEY CLUSTERED 
(
	[id_detalle_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DETALLE_FACTURA_venta]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_FACTURA_venta](
	[ID_DETALLE_FACTURA_venta] [int] NOT NULL,
	[ID_PRODUCTO] [int] NULL,
	[CANTIDAD] [decimal](18, 0) NULL,
	[DESCRIPCION] [varchar](30) NULL,
	[PRECIO_UNITARIO] [decimal](18, 0) NULL,
	[total_monto] [decimal](18, 0) NULL,
	[total_devolucion] [decimal](18, 0) NULL,
	[TOTAL] [decimal](18, 0) NULL,
	[IVA] [decimal](18, 0) NULL,
	[NUM_FACTURA] [int] NULL,
 CONSTRAINT [PK__DETALLE___E45BB1BF40D2553D] PRIMARY KEY CLUSTERED 
(
	[ID_DETALLE_FACTURA_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[factura_compra]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[factura_compra](
	[id_fac_compra] [int] NOT NULL,
	[destinatario] [varchar](30) NULL,
	[ubicacion] [varchar](30) NULL,
	[nombre_empresa] [varchar](30) NULL,
	[nombre_proveedor] [varchar](30) NULL,
	[cliente] [varchar](30) NULL,
	[fecha] [varchar](30) NULL,
 CONSTRAINT [PK__factura___B4F5DBF299AD96BA] PRIMARY KEY CLUSTERED 
(
	[id_fac_compra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FACTURA_venta]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURA_venta](
	[NUM_FACTURA] [int] NOT NULL,
	[Nombre_empresa] [varchar](30) NULL,
	[Nombre_cliente] [varchar](30) NULL,
	[Logo_empresa] [varchar](30) NULL,
	[ID_USUARIO] [int] NULL,
	[FECHA] [datetime] NULL,
 CONSTRAINT [PK__FACTURA___AE58D4E84D77C409] PRIMARY KEY CLUSTERED 
(
	[NUM_FACTURA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LINEA_TELEFONICA]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LINEA_TELEFONICA](
	[ID_LINEA_TELEFONICA] [int] NOT NULL,
	[claro] [varchar](30) NULL,
	[tigo] [varchar](30) NULL,
	[convencioal] [varchar](30) NULL,
	[ID_PROVEEDOR] [int] NULL,
 CONSTRAINT [PK__LINEA_TE__5BEA0147B6242B3A] PRIMARY KEY CLUSTERED 
(
	[ID_LINEA_TELEFONICA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARCA]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCA](
	[ID_MARCA] [int] NOT NULL,
	[estado] [bit] NULL,
	[NOMBRE_MARCA] [varchar](30) NULL,
 CONSTRAINT [PK__MARCA__A9FDC4BBC21410E3] PRIMARY KEY CLUSTERED 
(
	[ID_MARCA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARCA_CATEGORIA]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCA_CATEGORIA](
	[ID_MARCA] [int] NOT NULL,
	[ID_CATEGORIA] [int] NULL,
 CONSTRAINT [PK_MARCA_CATEGORIA] PRIMARY KEY CLUSTERED 
(
	[ID_MARCA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATERIAL]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATERIAL](
	[ID_MATERIAL] [int] NOT NULL,
	[estado] [bit] NULL,
	[detalles_material] [varchar](30) NULL,
	[NOMBRE_MATERIAL] [varchar](30) NULL,
 CONSTRAINT [PK__MATERIAL__B47FC5A3499AB4EE] PRIMARY KEY CLUSTERED 
(
	[ID_MATERIAL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUC_PROVEEDOR]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUC_PROVEEDOR](
	[ID_PRODUCTO] [int] NOT NULL,
	[ID_PROVEEDOR] [int] NULL,
 CONSTRAINT [PK_PRODUC_PROVEEDOR] PRIMARY KEY CLUSTERED 
(
	[ID_PRODUCTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[ID_PRODUCTO] [int] NOT NULL,
	[descripcion] [varchar](30) NULL,
	[NOMBRE_PRODUCTO] [varchar](30) NULL,
	[ID_COLOR] [int] NULL,
	[EXISTENCIA] [nvarchar](1000) NULL,
	[ID_MARCA] [int] NULL,
	[ID_MATERIAL] [int] NULL,
	[ID_CATEGORIA] [int] NULL,
	[ID_BODEGA] [int] NULL,
	[ID_TALLA] [int] NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK__PRODUCTO__88BD03574830E8FE] PRIMARY KEY CLUSTERED 
(
	[ID_PRODUCTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVEEDOR]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVEEDOR](
	[ID_PROVEEDOR] [int] NOT NULL,
	[CIUDAD_PROVEEDOR] [varchar](30) NULL,
	[CORREO_ELECTRONICO] [varchar](50) NULL,
	[NOMBRE_CONTACTO] [varchar](30) NULL,
	[id_fac_compra] [int] NULL,
	[NOMBRE_EMPRESA] [varchar](20) NULL,
	[Estado] [bit] NULL,
 CONSTRAINT [PK__PROVEEDO__733DB4C4CED327E0] PRIMARY KEY CLUSTERED 
(
	[ID_PROVEEDOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TABLA_USUARIO]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TABLA_USUARIO](
	[ID_USUARIO] [int] NOT NULL,
	[Nombre_Completo] [nvarchar](50) NULL,
	[Correo] [nvarchar](max) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Estado] [bit] NULL,
	[Fecha_Creacion] [datetime] NULL,
 CONSTRAINT [PK_TABLA_USUARIO] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TALLA]    Script Date: 23/11/2023 10:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TALLA](
	[ID_TALLA] [int] NOT NULL,
	[NUM_TALLA] [varchar](50) NULL,
 CONSTRAINT [PK__TALLA__6E1990BEB6A5CEA4] PRIMARY KEY CLUSTERED 
(
	[ID_TALLA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (0, N'Amarillo repetido')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (1, N'Rojo')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (2, N'Azul')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (3, N'Verde')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (4, N'Negro')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (5, N'Blanco')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (6, N'Amarillo')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (7, N'Marrón')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (8, N'Gris')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (9, N'Rosa')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (10, N'Morado')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (11, N'Celeste')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (20, N'20')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (21, N'21')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (22, N'22')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (23, N'Verde agua')
GO
INSERT [dbo].[COLOR] ([ID_COLOR], [NOMBRE_COLOR]) VALUES (24, N'Amarillo repetido 2')
GO
INSERT [dbo].[MARCA] ([ID_MARCA], [estado], [NOMBRE_MARCA]) VALUES (1, 1, N'Nike')
GO
INSERT [dbo].[MARCA] ([ID_MARCA], [estado], [NOMBRE_MARCA]) VALUES (2, 0, N'Dios')
GO
INSERT [dbo].[MARCA] ([ID_MARCA], [estado], [NOMBRE_MARCA]) VALUES (3, 1, N'Modificado')
GO
INSERT [dbo].[MARCA] ([ID_MARCA], [estado], [NOMBRE_MARCA]) VALUES (4, 1, N'Reebok')
GO
INSERT [dbo].[MARCA] ([ID_MARCA], [estado], [NOMBRE_MARCA]) VALUES (5, 0, N'Converse')
GO
INSERT [dbo].[MARCA] ([ID_MARCA], [estado], [NOMBRE_MARCA]) VALUES (15, 0, N'Vans')
GO
INSERT [dbo].[MARCA] ([ID_MARCA], [estado], [NOMBRE_MARCA]) VALUES (16, 1, N'Champions')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (1, 1, N'Detalles 1', N'Material 1')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (2, 0, N'Detalles 2', N'Material 2')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (3, 1, N'Detalles 3', N'Material 3')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (4, 0, N'Detalles 4', N'Material 4')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (5, 1, N'Detalles 5', N'Material 5')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (6, 0, N'Detalles 6', N'Material 6')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (7, 1, N'Detalles 7', N'Material 7')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (8, 0, N'Detalles 8', N'Material 8')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (9, 1, N'Detalles 9', N'Material 9')
GO
INSERT [dbo].[MATERIAL] ([ID_MATERIAL], [estado], [detalles_material], [NOMBRE_MATERIAL]) VALUES (10, 0, N'Detalles 10', N'Material 10')
GO
INSERT [dbo].[TALLA] ([ID_TALLA], [NUM_TALLA]) VALUES (1, N'S')
GO
INSERT [dbo].[TALLA] ([ID_TALLA], [NUM_TALLA]) VALUES (2, N'X')
GO
INSERT [dbo].[TALLA] ([ID_TALLA], [NUM_TALLA]) VALUES (3, N'Super!!!!')
GO
ALTER TABLE [dbo].[detalle_fac_compra]  WITH CHECK ADD  CONSTRAINT [FK__detalle_f__id_fa__3F466844] FOREIGN KEY([id_fac_compra])
REFERENCES [dbo].[factura_compra] ([id_fac_compra])
GO
ALTER TABLE [dbo].[detalle_fac_compra] CHECK CONSTRAINT [FK__detalle_f__id_fa__3F466844]
GO
ALTER TABLE [dbo].[detalle_fac_compra]  WITH CHECK ADD  CONSTRAINT [FK__detalle_f__id_pr__398D8EEE] FOREIGN KEY([id_producto])
REFERENCES [dbo].[PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[detalle_fac_compra] CHECK CONSTRAINT [FK__detalle_f__id_pr__398D8EEE]
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_venta]  WITH CHECK ADD  CONSTRAINT [FK__DETALLE_F__ID_PR__2D27B809] FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_venta] CHECK CONSTRAINT [FK__DETALLE_F__ID_PR__2D27B809]
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_venta]  WITH CHECK ADD  CONSTRAINT [FK__DETALLE_F__NUM_F__2E1BDC42] FOREIGN KEY([NUM_FACTURA])
REFERENCES [dbo].[FACTURA_venta] ([NUM_FACTURA])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_venta] CHECK CONSTRAINT [FK__DETALLE_F__NUM_F__2E1BDC42]
GO
ALTER TABLE [dbo].[FACTURA_venta]  WITH CHECK ADD  CONSTRAINT [FK_FACTURA_venta_TABLA_USUARIO] FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[TABLA_USUARIO] ([ID_USUARIO])
GO
ALTER TABLE [dbo].[FACTURA_venta] CHECK CONSTRAINT [FK_FACTURA_venta_TABLA_USUARIO]
GO
ALTER TABLE [dbo].[LINEA_TELEFONICA]  WITH CHECK ADD  CONSTRAINT [FK_LINEA_TELEFONICA_PROVEEDOR] FOREIGN KEY([ID_PROVEEDOR])
REFERENCES [dbo].[PROVEEDOR] ([ID_PROVEEDOR])
GO
ALTER TABLE [dbo].[LINEA_TELEFONICA] CHECK CONSTRAINT [FK_LINEA_TELEFONICA_PROVEEDOR]
GO
ALTER TABLE [dbo].[MARCA_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK__MARCA_CAT__ID_CA__5812160E] FOREIGN KEY([ID_CATEGORIA])
REFERENCES [dbo].[CATEGORIA] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[MARCA_CATEGORIA] CHECK CONSTRAINT [FK__MARCA_CAT__ID_CA__5812160E]
GO
ALTER TABLE [dbo].[MARCA_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK__MARCA_CAT__ID_MA__59063A47] FOREIGN KEY([ID_MARCA])
REFERENCES [dbo].[MARCA] ([ID_MARCA])
GO
ALTER TABLE [dbo].[MARCA_CATEGORIA] CHECK CONSTRAINT [FK__MARCA_CAT__ID_MA__59063A47]
GO
ALTER TABLE [dbo].[PRODUC_PROVEEDOR]  WITH CHECK ADD  CONSTRAINT [FK__PRODUC_PR__ID_PR__300424B4] FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[PRODUCTO] ([ID_PRODUCTO])
GO
ALTER TABLE [dbo].[PRODUC_PROVEEDOR] CHECK CONSTRAINT [FK__PRODUC_PR__ID_PR__300424B4]
GO
ALTER TABLE [dbo].[PRODUC_PROVEEDOR]  WITH CHECK ADD  CONSTRAINT [FK__PRODUC_PR__ID_PR__30F848ED] FOREIGN KEY([ID_PROVEEDOR])
REFERENCES [dbo].[PROVEEDOR] ([ID_PROVEEDOR])
GO
ALTER TABLE [dbo].[PRODUC_PROVEEDOR] CHECK CONSTRAINT [FK__PRODUC_PR__ID_PR__30F848ED]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_BODEGA] FOREIGN KEY([ID_BODEGA])
REFERENCES [dbo].[BODEGA] ([ID_BODEGA])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_BODEGA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_CATEGORIA] FOREIGN KEY([ID_CATEGORIA])
REFERENCES [dbo].[CATEGORIA] ([ID_CATEGORIA])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_CATEGORIA]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_COLOR] FOREIGN KEY([ID_COLOR])
REFERENCES [dbo].[COLOR] ([ID_COLOR])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_COLOR]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_MATERIAL] FOREIGN KEY([ID_MATERIAL])
REFERENCES [dbo].[MATERIAL] ([ID_MATERIAL])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_MATERIAL]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCTO_TALLA] FOREIGN KEY([ID_TALLA])
REFERENCES [dbo].[TALLA] ([ID_TALLA])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [FK_PRODUCTO_TALLA]
GO
ALTER TABLE [dbo].[PROVEEDOR]  WITH CHECK ADD  CONSTRAINT [FK_PROVEEDOR_factura_compra] FOREIGN KEY([id_fac_compra])
REFERENCES [dbo].[factura_compra] ([id_fac_compra])
GO
ALTER TABLE [dbo].[PROVEEDOR] CHECK CONSTRAINT [FK_PROVEEDOR_factura_compra]
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_Color]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Editar_Color](
@ID_COLOR char (5),
@NOMBRE_COLOR varchar (30))
as
begin
update COLOR set  NOMBRE_COLOR=@NOMBRE_COLOR where ID_COLOR=@ID_COLOR end

GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_Marca]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Editar_Marca](
@ID_MARCA char(5),
@Estado bit,
@NOMBRE_MARCA varchar (30))
as
begin 
update MARCA set Estado=@Estado, NOMBRE_MARCA=@NOMBRE_MARCA where ID_MARCA = @ID_MARCA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_Material]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_Editar_Material](
@ID_MATERIAL CHAR(5),
@detalles_material varchar(30),
@Estado bit,
@NOMBRE_MATERIAL VARCHAR(30))
as
begin 
 Update MATERIAL set detalles_material=@detalles_material,Estado = @Estado, NOMBRE_MATERIAL = @NOMBRE_MATERIAL where ID_MATERIAL = @ID_MATERIAL 
end 
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_PRODUCTO]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_Editar_PRODUCTO](
@ID_PRODUCTO CHAR(5),
@descripcion varchar (30),
@Estado bit,
@NOMBRE_PRODUCTO varchar(30))
As
Begin 
 Update PRODUCTO set descripcion= @descripcion ,Estado = @Estado, NOMBRE_PRODUCTO = @NOMBRE_PRODUCTO where ID_PRODUCTO = @ID_PRODUCTO 
End
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_Talla]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Editar_Talla](
@ID_TALLA char (5),
@NUM_TALLA varchar (30))
as
begin
update TALLA set  NUM_TALLA=@NUM_TALLA where ID_TALLA=@ID_TALLA end
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar_Categoria]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_Eliminar_Categoria] (
@ID_CATEGORIA CHAR(5)
)
as
begin
	delete from CATEGORIA where ID_CATEGORIA = @ID_CATEGORIA 
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Color]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Eliminar_Color](
@ID_COLOR CHAR(5)
)
as 
begin
delete from COLOR where ID_COLOR=@ID_COLOR
end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Marca]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Eliminar_Marca](
@ID_MARCA CHAR(5)
)
as 
begin
delete from MARCA where ID_MARCA=@ID_MARCA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar_Material]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Eliminar_Material] (
@ID_MATERIAL CHAR(5)
)
as
begin
	delete from MATERIAL where ID_MATERIAL = @ID_MATERIAL
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar_PRODUCTO]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Eliminar_PRODUCTO] (
@ID_PRODUCTO CHAR(5)
)
as
begin
	delete from PRODUCTO where ID_PRODUCTO = @ID_PRODUCTO 
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar_Proveedor]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Eliminar_Proveedor](
@ID_PROVEEDOR CHAR(5)
)
as
begin
	delete from PROVEEDOR where ID_PROVEEDOR = @ID_PROVEEDOR 
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_Eliminar_Talla]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Eliminar_Talla](
@ID_TALLA CHAR(5)
)
as 
begin
delete from TALLA where ID_TALLA=@ID_TALLA
end

GO
/****** Object:  StoredProcedure [dbo].[sp_Guardar_Color]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Guardar_Color](
@NOMBRE_COLOR VARCHAR (30))
AS 
begin
insert into COLOR(NOMBRE_COLOR) values (@NOMBRE_COLOR) end
GO
/****** Object:  StoredProcedure [dbo].[sp_Guardar_MARCA]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Guardar_MARCA](
@Estado bit,
@Nombre_Marca varchar(50))
as 
begin
 insert into MARCA (Estado, NOMBRE_MARCA) values (@Estado, @Nombre_Marca) end
GO
/****** Object:  StoredProcedure [dbo].[sp_Guardar_Material]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_Guardar_Material](
@Estado bit,
@detalles_material varchar(30),
@NOMBRE_MATERIAL VARCHAR(30))
as
begin 
  Insert into MATERIAL(Estado,detalles_material, NOMBRE_MATERIAL) values(@Estado,@detalles_material, @NOMBRE_MATERIAL)
end 
GO
/****** Object:  StoredProcedure [dbo].[sp_Guardar_PRODUCTO]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_Guardar_PRODUCTO](
@descripcion varchar (30),
@Estado bit,
@NOMBRE_PRODUCTO VARCHAR(30))
as
begin 
  Insert into PRODUCTO(descripcion,Estado, NOMBRE_PRODUCTO) values(@descripcion,@Estado, @NOMBRE_PRODUCTO)
End 
GO
/****** Object:  StoredProcedure [dbo].[sp_Guardar_Proveedor]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Guardar_Proveedor](
@CIUDAD_PROVEEDOR varchar(30),
@CORREO_ELECTRONICO varchar(50),
@NOMBRE_CONTACTO varchar(30),
@id_fac_compra char (5),
@NOMBRE_EMPRESA varchar(20),
@Estado bit)
as
begin
	insert into PROVEEDOR(CIUDAD_PROVEEDOR,CORREO_ELECTRONICO,NOMBRE_CONTACTO,id_fac_compra,NOMBRE_EMPRESA,Estado) values (@CIUDAD_PROVEEDOR,@CORREO_ELECTRONICO,@NOMBRE_CONTACTO,@id_fac_compra,@NOMBRE_EMPRESA,@Estado)
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Guardar_Talla]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Guardar_Talla](
@NUM_TALLA VARCHAR (30))
AS 
begin
insert into TALLA(NUM_TALLA) values (@NUM_TALLA) end
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Categoria]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Listar_Categoria]
as
begin
	select * from CATEGORIA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Color]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Listar_Color]
as 
begin
select * from COLOR
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Marca]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Listar_Marca]
as 
begin
select * from MARCA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Material]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Listar_Material]
as
begin
	select * from MATERIAL 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_PRODUCTO]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Listar_PRODUCTO]
as
begin
	select * from PRODUCTO
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Proveedor]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Listar_Proveedor]
as
begin
	select * from PROVEEDOR
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Talla]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Listar_Talla]
as 
begin
select * from TALLA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Obtener_Categoria]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Obtener_Categoria] (
@ID_CATEGORIA CHAR(5)
)
as
begin
	select * from CATEGORIA where  ID_CATEGORIA=@ID_CATEGORIA 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Obtener_Color]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Obtener_Color](
@ID_COLOR CHAR (5)
)
as
begin
	select * from COLOR where ID_COLOR=@ID_COLOR
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Obtener_Marca]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Obtener_Marca](
@ID_MARCA CHAR (5)
)
as
begin
	select * from MARCA where ID_MARCA=@ID_MARCA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Obtener_Material]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Obtener_Material] (
@ID_MATERIAL CHAR(5)
)
as
begin
	select * from MATERIAL where  ID_MATERIAL=@ID_MATERIAL
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Obtener_PRODUCTO]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Obtener_PRODUCTO] (
@ID_PRODUCTO CHAR(5)
)
as
begin
	select * from PRODUCTO where  ID_PRODUCTO=@ID_PRODUCTO 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Obtener_Proveedor]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Obtener_Proveedor](
@ID_PROVEEDOR CHAR(5)
)
as
begin
	select * from PROVEEDOR where  ID_PROVEEDOR=@ID_PROVEEDOR 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Obtener_Talla]    Script Date: 23/11/2023 10:12:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Obtener_Talla](
@ID_TALLA CHAR (5)
)
as
begin
	select * from TALLA where ID_TALLA=@ID_TALLA
end
GO
USE [master]
GO
ALTER DATABASE [Dzapatos1] SET  READ_WRITE 
GO
