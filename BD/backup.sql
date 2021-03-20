USE [master]
GO
/****** Object:  Database [SmartAssembly]    Script Date: 20/3/2021 12:06:49 ******/
CREATE DATABASE [SmartAssembly]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SmartAssembly', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SmartAssembly.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SmartAssembly_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SmartAssembly_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SmartAssembly] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SmartAssembly].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SmartAssembly] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SmartAssembly] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SmartAssembly] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SmartAssembly] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SmartAssembly] SET ARITHABORT OFF 
GO
ALTER DATABASE [SmartAssembly] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SmartAssembly] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SmartAssembly] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SmartAssembly] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SmartAssembly] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SmartAssembly] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SmartAssembly] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SmartAssembly] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SmartAssembly] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SmartAssembly] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SmartAssembly] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SmartAssembly] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SmartAssembly] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SmartAssembly] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SmartAssembly] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SmartAssembly] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SmartAssembly] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SmartAssembly] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SmartAssembly] SET  MULTI_USER 
GO
ALTER DATABASE [SmartAssembly] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SmartAssembly] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SmartAssembly] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SmartAssembly] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SmartAssembly] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SmartAssembly', N'ON'
GO
ALTER DATABASE [SmartAssembly] SET QUERY_STORE = OFF
GO
USE [SmartAssembly]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Email] [varchar](100) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Number] [varchar](20) NOT NULL,
	[Adress] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Client_1] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [decimal](10, 2) NOT NULL,
	[Perfomance] [int] NOT NULL,
	[TypePart] [varchar](20) NOT NULL,
	[TypeFormat] [varchar](20) NOT NULL,
	[TypeMemory] [varchar](20) NOT NULL,
	[Socket] [varchar](50) NOT NULL,
	[HasIntegratedVideo] [bit] NOT NULL,
	[Channels] [int] NOT NULL,
	[VideoLevel] [int] NOT NULL,
	[FanLevel] [int] NOT NULL,
	[NeedHighFrecuency] [bit] NOT NULL,
	[Capacity] [int] NOT NULL,
	[FanSize] [int] NOT NULL,
	[MaxFrecuency] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[Watts] [int] NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component_Computer]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component_Computer](
	[ID_Component] [int] NOT NULL,
	[ID_Computer] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Computer]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Order] [int] NOT NULL,
	[TypeUse] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Computer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Employee_1] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderDelivery] [datetime] NOT NULL,
	[Email_Employee] [varchar](100) NULL,
	[Email_client] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Socket]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Socket](
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Socket] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeFormat]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeFormat](
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TypeFormat_1] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeMemory]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeMemory](
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TypeMemory_1] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePart]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePart](
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TypePart_1] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeUse]    Script Date: 20/3/2021 12:06:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeUse](
	[Name] [varchar](50) NOT NULL,
	[Cpu] [int] NULL,
	[Fan] [int] NULL,
	[Ram] [int] NULL,
	[Gpu] [int] NULL,
	[HDD] [int] NULL,
	[SSD] [int] NULL,
 CONSTRAINT [PK_TypeUse] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Client] ([Email], [Name], [Number], [Adress]) VALUES (N'juan@gmail', N'juan', N'123123123', N'berutti 2062')
GO
SET IDENTITY_INSERT [dbo].[Component] ON 

INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (1, N'Intel I3', CAST(12000.00 AS Decimal(10, 2)), 30, N'cpu', N'___', N'DDR4', N'1151', 1, 2, 10, 10, 0, 0, 0, 2633, 100, 50)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (3, N'intel i5', CAST(15000.00 AS Decimal(10, 2)), 50, N'cpu', N'___', N'DDR4', N'1151', 1, 2, 10, 10, 0, 0, 0, 2933, 100, 70)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (5, N'Intel i7', CAST(19000.00 AS Decimal(10, 2)), 70, N'cpu', N'___', N'DDR4', N'1151', 1, 2, 10, 10, 1, 0, 0, 3200, 99, 90)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (6, N'Ryzen 3', CAST(12000.00 AS Decimal(10, 2)), 40, N'cpu', N'___', N'DDR4', N'AM4', 0, 2, 0, 30, 1, 0, 0, 3200, 100, 60)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (8, N'Ryzen 5', CAST(15000.00 AS Decimal(10, 2)), 60, N'cpu', N'___', N'DDR4', N'AM4', 0, 2, 0, 30, 1, 0, 0, 3200, 100, 80)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (9, N'Ryzen 7', CAST(20000.00 AS Decimal(10, 2)), 75, N'cpu', N'___', N'DDR4', N'AM4', 0, 2, 0, 30, 1, 0, 0, 3200, 100, 100)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (10, N'Ryzen 3 G', CAST(13500.00 AS Decimal(10, 2)), 40, N'cpu', N'___', N'DDR4', N'AM4', 1, 2, 30, 20, 0, 0, 0, 2633, 100, 50)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (11, N'Ryzen 5 G', CAST(16500.00 AS Decimal(10, 2)), 60, N'cpu', N'___', N'DDR4', N'AM4', 1, 2, 30, 20, 0, 0, 0, 2933, 100, 60)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (13, N'ASUS 1151 3', CAST(7000.00 AS Decimal(10, 2)), 30, N'mother', N'MATX', N'DDR4', N'1151', 1, 2, 0, 0, 0, 0, 0, 2633, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (14, N'ASUS 1151 5', CAST(9000.00 AS Decimal(10, 2)), 40, N'mother', N'ATX', N'DDR4', N'1151', 1, 2, 0, 0, 0, 0, 0, 2933, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (16, N'ASUS 1151 7', CAST(12000.00 AS Decimal(10, 2)), 60, N'mother', N'ATX', N'DDR4', N'1151', 1, 4, 0, 0, 0, 0, 0, 3200, 99, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (17, N'ASROCK AM4 3', CAST(9000.00 AS Decimal(10, 2)), 30, N'mother', N'ITX', N'DDR4', N'AM4', 0, 2, 0, 0, 0, 0, 0, 2633, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (19, N'ASROCK AM4 5', CAST(11000.00 AS Decimal(10, 2)), 50, N'mother', N'ATX', N'DDR4', N'AM4', 0, 4, 0, 0, 0, 0, 0, 2933, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (20, N'ASROCK AM4 7', CAST(13000.00 AS Decimal(10, 2)), 70, N'mother', N'ATX', N'DDR4', N'AM4', 0, 4, 0, 0, 0, 0, 0, 3500, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (21, N'Gigabyte AM4', CAST(7500.00 AS Decimal(10, 2)), 30, N'mother', N'ITX', N'DDR4', N'AM4', 1, 4, 0, 0, 0, 0, 0, 2933, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (22, N'Gigabyte AM4', CAST(9000.00 AS Decimal(10, 2)), 40, N'mother', N'MATX', N'DDR4', N'AM4', 1, 2, 0, 0, 0, 0, 0, 2933, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (23, N'Fan Thermaltake', CAST(6000.00 AS Decimal(10, 2)), 30, N'fan', N'___', N'___', N'AM4-1151', 0, 0, 0, 30, 0, 0, 120, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (24, N'Fan EVGA', CAST(12000.00 AS Decimal(10, 2)), 60, N'fan', N'___', N'___', N'AM4-1151', 0, 0, 0, 60, 0, 0, 120, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (27, N'Fan thermaltake intel', CAST(5500.00 AS Decimal(10, 2)), 30, N'fan', N'___', N'___', N'1151', 0, 0, 0, 30, 0, 0, 240, 0, 99, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (28, N'RAM crucial 4gb', CAST(4000.00 AS Decimal(10, 2)), 30, N'ram', N'___', N'DDR4', N'___', 0, 0, 0, 0, 0, 4, 0, 2633, 98, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (29, N'RAM crucial 8gb', CAST(7000.00 AS Decimal(10, 2)), 30, N'ram', N'___', N'DDR4', N'___', 0, 0, 0, 0, 0, 8, 0, 2633, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (30, N'RAM corsair 4gb ', CAST(6000.00 AS Decimal(10, 2)), 50, N'ram', N'___', N'DDR4', N'___', 0, 0, 0, 0, 0, 4, 0, 3200, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (31, N'RAM corsair 8gb', CAST(9000.00 AS Decimal(10, 2)), 50, N'ram', N'___', N'DDR4', N'___', 0, 0, 0, 0, 0, 8, 0, 3200, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (32, N'Seagate 1000gb HDD', CAST(4300.00 AS Decimal(10, 2)), 20, N'hdd', N'___', N'___', N'___', 0, 0, 0, 0, 0, 1000, 0, 0, 99, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (33, N'kingston 240gb', CAST(4300.00 AS Decimal(10, 2)), 35, N'ssd', N'___', N'___', N'___', 0, 0, 0, 0, 0, 240, 0, 0, 99, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (35, N'kingston 480gb', CAST(8000.00 AS Decimal(10, 2)), 35, N'ssd', N'___', N'___', N'___', 0, 0, 0, 0, 0, 480, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (36, N'GTX 1060', CAST(43500.00 AS Decimal(10, 2)), 45, N'gpu', N'___', N'___', N'___', 0, 0, 45, 0, 0, 0, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (37, N'GTX 2060', CAST(180000.00 AS Decimal(10, 2)), 60, N'gpu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 0, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (38, N'GTX 3070', CAST(260000.00 AS Decimal(10, 2)), 80, N'gpu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 0, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (39, N'RX 550', CAST(12000.00 AS Decimal(10, 2)), 40, N'gpu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 0, 0, 0, 99, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (40, N'RX 570', CAST(43500.00 AS Decimal(10, 2)), 50, N'gpu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 0, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (41, N'RX 5500', CAST(94000.00 AS Decimal(10, 2)), 70, N'gpu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 0, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (42, N'SENTEY F10', CAST(4500.00 AS Decimal(10, 2)), 30, N'tower', N'MATX', N'___', N'___', 0, 0, 0, 0, 0, 0, 180, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (43, N'KOLONK F', CAST(7000.00 AS Decimal(10, 2)), 40, N'tower', N'ATX', N'___', N'___', 0, 0, 0, 0, 0, 0, 240, 0, 99, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (44, N'REDRAGON 500', CAST(5500.00 AS Decimal(10, 2)), 35, N'psu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 500, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (45, N'GAMEMAX 600', CAST(6000.00 AS Decimal(10, 2)), 40, N'psu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 600, 0, 0, 99, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (46, N'ADATA 750', CAST(10000.00 AS Decimal(10, 2)), 45, N'psu', N'___', N'___', N'___', 0, 0, 0, 0, 0, 750, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (47, N'WiFI usb', CAST(3000.00 AS Decimal(10, 2)), 30, N'accesory', N'___', N'___', N'___', 0, 0, 0, 0, 0, 0, 0, 0, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (48, N'RAM adata 4gb', CAST(5000.00 AS Decimal(10, 2)), 30, N'ram', N'___', N'___', N'___', 0, 0, 0, 0, 0, 4, 0, 0, 10, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (49, N'RAM adata 8gb', CAST(9500.00 AS Decimal(10, 2)), 30, N'ram', N'___', N'___', N'___', 0, 0, 0, 0, 0, 8, 0, 0, 10, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (50, N'WD 1000gb', CAST(4500.00 AS Decimal(10, 2)), 25, N'hdd', N'___', N'___', N'___', 0, 0, 0, 0, 0, 1000, 0, 0, 10, 20)
SET IDENTITY_INSERT [dbo].[Component] OFF
GO
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (5, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (16, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (27, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (43, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (45, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (47, 1019)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (5, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (16, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (27, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (43, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (45, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (47, 1020)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (5, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (16, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (27, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (43, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (45, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (47, 1021)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (5, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (16, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (27, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (43, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (45, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (47, 1022)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (5, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (16, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (27, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (43, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (45, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (47, 1023)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (5, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (16, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (27, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (43, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (45, 1024)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (47, 1024)
GO
SET IDENTITY_INSERT [dbo].[Computer] ON 

INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (1019, 1, N'design')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (1020, 2, N'design')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (1021, 3, N'design')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (1022, 4, N'design')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (1023, 5, N'design')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (1024, 6, N'design')
SET IDENTITY_INSERT [dbo].[Computer] OFF
GO
INSERT [dbo].[Employee] ([Email]) VALUES (N'franco@gmail.com')
INSERT [dbo].[Employee] ([Email]) VALUES (N'kati@gmail.com')
INSERT [dbo].[Employee] ([Email]) VALUES (N'vilu@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [Price], [OrderDate], [OrderDelivery], [Email_Employee], [Email_client]) VALUES (1, CAST(65400.00 AS Decimal(18, 2)), CAST(N'2021-03-17T23:55:37.137' AS DateTime), CAST(N'2021-03-18T23:55:37.137' AS DateTime), N'franco@gmail.com', N'juan@gmail')
INSERT [dbo].[Order] ([ID], [Price], [OrderDate], [OrderDelivery], [Email_Employee], [Email_client]) VALUES (2, CAST(65400.00 AS Decimal(18, 2)), CAST(N'2021-03-18T00:05:05.323' AS DateTime), CAST(N'2021-03-19T00:05:05.323' AS DateTime), N'kati@gmail.com', N'juan@gmail')
INSERT [dbo].[Order] ([ID], [Price], [OrderDate], [OrderDelivery], [Email_Employee], [Email_client]) VALUES (3, CAST(65400.00 AS Decimal(18, 2)), CAST(N'2021-03-18T00:05:41.257' AS DateTime), CAST(N'2021-03-19T00:05:41.257' AS DateTime), N'vilu@gmail.com', N'juan@gmail')
INSERT [dbo].[Order] ([ID], [Price], [OrderDate], [OrderDelivery], [Email_Employee], [Email_client]) VALUES (4, CAST(65400.00 AS Decimal(18, 2)), CAST(N'2021-03-18T00:05:56.477' AS DateTime), CAST(N'2021-03-19T00:05:56.477' AS DateTime), N'kati@gmail.com', N'juan@gmail')
INSERT [dbo].[Order] ([ID], [Price], [OrderDate], [OrderDelivery], [Email_Employee], [Email_client]) VALUES (5, CAST(65400.00 AS Decimal(18, 2)), CAST(N'2021-03-18T00:11:18.540' AS DateTime), CAST(N'2021-03-19T00:11:18.540' AS DateTime), N'franco@gmail.com', N'juan@gmail')
INSERT [dbo].[Order] ([ID], [Price], [OrderDate], [OrderDelivery], [Email_Employee], [Email_client]) VALUES (6, CAST(65400.00 AS Decimal(18, 2)), CAST(N'2021-03-18T00:15:46.383' AS DateTime), CAST(N'2021-03-19T00:15:46.383' AS DateTime), N'vilu@gmail.com', N'juan@gmail')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[Socket] ([Name]) VALUES (N'___')
INSERT [dbo].[Socket] ([Name]) VALUES (N'1151')
INSERT [dbo].[Socket] ([Name]) VALUES (N'1155')
INSERT [dbo].[Socket] ([Name]) VALUES (N'AM4')
GO
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'___')
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'ATX')
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'ITX')
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'MATX')
GO
INSERT [dbo].[TypeMemory] ([Name]) VALUES (N'___')
INSERT [dbo].[TypeMemory] ([Name]) VALUES (N'DDR3')
INSERT [dbo].[TypeMemory] ([Name]) VALUES (N'DDR4')
INSERT [dbo].[TypeMemory] ([Name]) VALUES (N'DDR5')
GO
INSERT [dbo].[TypePart] ([Name]) VALUES (N'accesory')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'cpu')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'fan')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'gpu')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'hdd')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'mother')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'psu')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'ram')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'ssd')
INSERT [dbo].[TypePart] ([Name]) VALUES (N'tower')
GO
INSERT [dbo].[TypeUse] ([Name], [Cpu], [Fan], [Ram], [Gpu], [HDD], [SSD]) VALUES (N'design', 60, 50, 16, 60, 1000, 480)
INSERT [dbo].[TypeUse] ([Name], [Cpu], [Fan], [Ram], [Gpu], [HDD], [SSD]) VALUES (N'development', 40, 30, 8, 10, 0, 240)
INSERT [dbo].[TypeUse] ([Name], [Cpu], [Fan], [Ram], [Gpu], [HDD], [SSD]) VALUES (N'gaming', 30, 30, 8, 40, 1000, 120)
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_TypeFormat]  DEFAULT ('___') FOR [TypeFormat]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_TypeMemory]  DEFAULT ('___') FOR [TypeMemory]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_Socket]  DEFAULT ('___') FOR [Socket]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_HasIntegratedVideo]  DEFAULT ((0)) FOR [HasIntegratedVideo]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_Channels]  DEFAULT ((0)) FOR [Channels]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_VideoLevel]  DEFAULT ((0)) FOR [VideoLevel]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_FanLevel]  DEFAULT ((0)) FOR [FanLevel]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_NeedHighFrecuency]  DEFAULT ((0)) FOR [NeedHighFrecuency]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_Capacity]  DEFAULT ((0)) FOR [Capacity]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_Size]  DEFAULT ((0)) FOR [FanSize]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_MaxFrecuency]  DEFAULT ((0)) FOR [MaxFrecuency]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_Stock]  DEFAULT ((10)) FOR [Stock]
GO
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_Watts]  DEFAULT ((20)) FOR [Watts]
GO
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_TypeFormat] FOREIGN KEY([TypeFormat])
REFERENCES [dbo].[TypeFormat] ([Name])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_TypeFormat]
GO
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_TypeMemory] FOREIGN KEY([TypeMemory])
REFERENCES [dbo].[TypeMemory] ([Name])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_TypeMemory]
GO
ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_TypePart] FOREIGN KEY([TypePart])
REFERENCES [dbo].[TypePart] ([Name])
GO
ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_TypePart]
GO
ALTER TABLE [dbo].[Component_Computer]  WITH CHECK ADD  CONSTRAINT [FK_Component_Computer_Component] FOREIGN KEY([ID_Component])
REFERENCES [dbo].[Component] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Component_Computer] CHECK CONSTRAINT [FK_Component_Computer_Component]
GO
ALTER TABLE [dbo].[Component_Computer]  WITH CHECK ADD  CONSTRAINT [FK_Component_Computer_Computer] FOREIGN KEY([ID_Computer])
REFERENCES [dbo].[Computer] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Component_Computer] CHECK CONSTRAINT [FK_Component_Computer_Computer]
GO
ALTER TABLE [dbo].[Computer]  WITH CHECK ADD  CONSTRAINT [FK_Computer_Order] FOREIGN KEY([ID_Order])
REFERENCES [dbo].[Order] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Computer] CHECK CONSTRAINT [FK_Computer_Order]
GO
ALTER TABLE [dbo].[Computer]  WITH CHECK ADD  CONSTRAINT [FK_Computer_TypeUse] FOREIGN KEY([TypeUse])
REFERENCES [dbo].[TypeUse] ([Name])
GO
ALTER TABLE [dbo].[Computer] CHECK CONSTRAINT [FK_Computer_TypeUse]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client1] FOREIGN KEY([Email_client])
REFERENCES [dbo].[Client] ([Email])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee1] FOREIGN KEY([Email_Employee])
REFERENCES [dbo].[Employee] ([Email])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee1]
GO
USE [master]
GO
ALTER DATABASE [SmartAssembly] SET  READ_WRITE 
GO
