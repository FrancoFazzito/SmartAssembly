USE [master]
GO
/****** Object:  Database [SmartAssembly]    Script Date: 26/3/2021 21:27:04 ******/
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
/****** Object:  Table [dbo].[Client]    Script Date: 26/3/2021 21:27:04 ******/
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
/****** Object:  Table [dbo].[Component]    Script Date: 26/3/2021 21:27:04 ******/
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
	[TypeFormat] [varchar](20) NULL,
	[TypeMemory] [varchar](20) NULL,
	[Socket] [varchar](50) NULL,
	[HasIntegratedVideo] [bit] NULL,
	[Channels] [int] NULL,
	[VideoLevel] [int] NULL,
	[FanLevel] [int] NULL,
	[NeedHighFrecuency] [bit] NULL,
	[Capacity] [int] NULL,
	[FanSize] [int] NULL,
	[MaxFrecuency] [int] NULL,
	[Stock] [int] NOT NULL,
	[Watts] [int] NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component_Computer]    Script Date: 26/3/2021 21:27:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component_Computer](
	[ID_Component] [int] NOT NULL,
	[ID_Computer] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Computer]    Script Date: 26/3/2021 21:27:04 ******/
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
/****** Object:  Table [dbo].[Computer_Error]    Script Date: 26/3/2021 21:27:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computer_Error](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Computer] [int] NOT NULL,
	[ID_Component_Error] [int] NULL,
	[ID_Component_Replace] [int] NULL,
	[Commentary] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ComputerError] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 26/3/2021 21:27:04 ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 26/3/2021 21:27:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[DateRequested] [datetime] NOT NULL,
	[DateToDelivery] [datetime] NOT NULL,
	[Email_Employee] [varchar](100) NULL,
	[Email_client] [varchar](100) NOT NULL,
	[Commentary] [varchar](max) NULL,
	[OrderState] [int] NOT NULL,
	[DateDelivered] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_State]    Script Date: 26/3/2021 21:27:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_State](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Order_State] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeFormat]    Script Date: 26/3/2021 21:27:04 ******/
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
/****** Object:  Table [dbo].[TypeMemory]    Script Date: 26/3/2021 21:27:04 ******/
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
/****** Object:  Table [dbo].[TypePart]    Script Date: 26/3/2021 21:27:04 ******/
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
/****** Object:  Table [dbo].[TypeUse]    Script Date: 26/3/2021 21:27:04 ******/
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

INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (1, N'Intel I3', CAST(12000.00 AS Decimal(10, 2)), 30, N'cpu', N'_', N'DDR4', N'1151', 1, 2, 10, 10, 0, NULL, NULL, 2633, 100, 50)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (3, N'intel i5', CAST(15000.00 AS Decimal(10, 2)), 50, N'cpu', N'_', N'DDR4', N'1151', 1, 2, 10, 10, 0, NULL, NULL, 2933, 100, 70)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (5, N'Intel i7', CAST(19000.00 AS Decimal(10, 2)), 70, N'cpu', N'_', N'DDR4', N'1151', 1, 2, 10, 10, 1, NULL, NULL, 3200, 100, 90)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (6, N'Ryzen 3', CAST(12000.00 AS Decimal(10, 2)), 40, N'cpu', N'_', N'DDR4', N'AM4', 0, 2, NULL, 30, 1, NULL, NULL, 3200, 100, 60)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (8, N'Ryzen 5', CAST(15000.00 AS Decimal(10, 2)), 60, N'cpu', N'_', N'DDR4', N'AM4', 0, 2, NULL, 30, 1, NULL, NULL, 3200, 37, 80)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (9, N'Ryzen 7', CAST(20000.00 AS Decimal(10, 2)), 75, N'cpu', N'_', N'DDR4', N'AM4', 0, 2, NULL, 30, 1, NULL, NULL, 3200, 100, 100)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (10, N'Ryzen 3 G', CAST(13500.00 AS Decimal(10, 2)), 40, N'cpu', N'_', N'DDR4', N'AM4', 1, 2, 30, 20, 0, NULL, NULL, 2633, 100, 50)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (11, N'Ryzen 5 G', CAST(16500.00 AS Decimal(10, 2)), 60, N'cpu', N'_', N'DDR4', N'AM4', 1, 2, 30, 20, 0, NULL, NULL, 2933, 996, 60)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (13, N'ASUS 1151 3', CAST(7000.00 AS Decimal(10, 2)), 30, N'mother', N'MATX', N'DDR4', N'1151', 1, 2, NULL, NULL, 0, NULL, NULL, 2633, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (14, N'ASUS 1151 5', CAST(9000.00 AS Decimal(10, 2)), 40, N'mother', N'ATX', N'DDR4', N'1151', 1, 2, NULL, NULL, 0, NULL, NULL, 2933, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (16, N'ASUS 1151 7', CAST(12000.00 AS Decimal(10, 2)), 60, N'mother', N'ATX', N'DDR4', N'1151', 1, 4, NULL, NULL, 0, NULL, NULL, 3200, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (17, N'ASROCK AM4 3', CAST(9000.00 AS Decimal(10, 2)), 30, N'mother', N'ITX', N'DDR4', N'AM4', 0, 2, NULL, NULL, 0, NULL, NULL, 2633, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (19, N'ASROCK AM4 5', CAST(11000.00 AS Decimal(10, 2)), 50, N'mother', N'ATX', N'DDR4', N'AM4', 0, 4, NULL, NULL, 0, NULL, NULL, 2933, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (20, N'ASROCK AM4 7', CAST(13000.00 AS Decimal(10, 2)), 70, N'mother', N'ATX', N'DDR4', N'AM4', 0, 4, NULL, NULL, 0, NULL, NULL, 3500, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (21, N'Gigabyte AM4', CAST(7500.00 AS Decimal(10, 2)), 30, N'mother', N'ITX', N'DDR4', N'AM4', 1, 4, NULL, NULL, 0, NULL, NULL, 2933, 933, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (22, N'Gigabyte AM4', CAST(9000.00 AS Decimal(10, 2)), 40, N'mother', N'MATX', N'DDR4', N'AM4', 1, 2, NULL, NULL, 0, NULL, NULL, 2933, 1000, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (23, N'Fan Thermaltake', CAST(6000.00 AS Decimal(10, 2)), 30, N'fan', N'_', N'_', N'AM4-1151', 0, NULL, NULL, 30, 0, NULL, 120, NULL, 933, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (24, N'Fan EVGA', CAST(12000.00 AS Decimal(10, 2)), 60, N'fan', N'_', N'_', N'AM4-1151', 0, NULL, NULL, 60, 0, NULL, 120, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (27, N'Fan thermaltake intel', CAST(5500.00 AS Decimal(10, 2)), 30, N'fan', N'_', N'_', N'1151', 0, NULL, NULL, 30, 0, NULL, 240, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (28, N'RAM crucial 4gb', CAST(4000.00 AS Decimal(10, 2)), 30, N'ram', N'_', N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 4, NULL, 2633, 866, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (29, N'RAM crucial 8gb', CAST(7000.00 AS Decimal(10, 2)), 30, N'ram', N'_', N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 8, NULL, 2633, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (30, N'RAM corsair 4gb ', CAST(6000.00 AS Decimal(10, 2)), 50, N'ram', N'_', N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 4, NULL, 3200, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (31, N'RAM corsair 8gb', CAST(9000.00 AS Decimal(10, 2)), 50, N'ram', N'_', N'DDR4', NULL, 0, NULL, NULL, NULL, 0, 8, NULL, 3200, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (32, N'Seagate 1000gb HDD', CAST(4300.00 AS Decimal(10, 2)), 20, N'hdd', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 933, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (33, N'kingston 240gb', CAST(4300.00 AS Decimal(10, 2)), 35, N'ssd', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 240, NULL, NULL, 933, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (35, N'kingston 480gb', CAST(8000.00 AS Decimal(10, 2)), 35, N'ssd', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 480, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (36, N'GTX 1060', CAST(43500.00 AS Decimal(10, 2)), 45, N'gpu', N'_', N'_', NULL, 0, NULL, 45, NULL, 0, NULL, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (37, N'GTX 2060', CAST(180000.00 AS Decimal(10, 2)), 60, N'gpu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (38, N'GTX 3070', CAST(260000.00 AS Decimal(10, 2)), 80, N'gpu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (39, N'RX 550', CAST(12000.00 AS Decimal(10, 2)), 40, N'gpu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 933, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (40, N'RX 570', CAST(43500.00 AS Decimal(10, 2)), 50, N'gpu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (41, N'RX 5500', CAST(94000.00 AS Decimal(10, 2)), 70, N'gpu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (42, N'SENTEY F10', CAST(4500.00 AS Decimal(10, 2)), 30, N'tower', N'MATX', N'_', NULL, 0, NULL, NULL, NULL, 0, NULL, 180, NULL, 933, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (43, N'KOLONK F', CAST(7000.00 AS Decimal(10, 2)), 40, N'tower', N'ATX', N'_', NULL, 0, NULL, NULL, NULL, 0, NULL, 240, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (44, N'REDRAGON 500', CAST(5500.00 AS Decimal(10, 2)), 35, N'psu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 500, NULL, NULL, 933, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (45, N'GAMEMAX 600', CAST(6000.00 AS Decimal(10, 2)), 40, N'psu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 600, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (46, N'ADATA 750', CAST(10000.00 AS Decimal(10, 2)), 45, N'psu', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 750, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (47, N'WiFI usb', CAST(3000.00 AS Decimal(10, 2)), 30, N'accesory', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 0, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (48, N'RAM adata 4gb', CAST(5000.00 AS Decimal(10, 2)), 30, N'ram', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 4, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (49, N'RAM adata 8gb', CAST(9500.00 AS Decimal(10, 2)), 30, N'ram', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 8, NULL, NULL, 100, 20)
INSERT [dbo].[Component] ([ID], [Name], [Price], [Perfomance], [TypePart], [TypeFormat], [TypeMemory], [Socket], [HasIntegratedVideo], [Channels], [VideoLevel], [FanLevel], [NeedHighFrecuency], [Capacity], [FanSize], [MaxFrecuency], [Stock], [Watts]) VALUES (50, N'WD 1000gb', CAST(4500.00 AS Decimal(10, 2)), 25, N'hdd', N'_', N'_', NULL, 0, NULL, NULL, NULL, 0, 1000, NULL, NULL, 100, 20)
SET IDENTITY_INSERT [dbo].[Component] OFF
GO
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2221)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2222)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2223)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2224)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2225)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2226)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2227)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2228)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2229)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (11, 2234)
GO
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2235)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2236)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2237)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2238)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2239)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2240)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (11, 2230)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2231)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2232)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2233)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2233)
GO
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2241)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2242)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (8, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (21, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (28, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (23, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (39, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (32, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (33, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (42, 2243)
INSERT [dbo].[Component_Computer] ([ID_Component], [ID_Computer]) VALUES (44, 2243)
GO
SET IDENTITY_INSERT [dbo].[Computer] ON 

INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2221, 1098, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2222, 1098, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2223, 1098, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2224, 1099, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2225, 1099, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2226, 1099, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2227, 1100, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2228, 1100, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2229, 1100, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2230, 1101, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2231, 1102, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2232, 1102, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2233, 1102, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2234, 1103, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2235, 1104, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2236, 1104, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2237, 1104, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2238, 1105, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2239, 1105, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2240, 1105, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2241, 1106, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2242, 1106, N'gaming')
INSERT [dbo].[Computer] ([ID], [ID_Order], [TypeUse]) VALUES (2243, 1106, N'gaming')
SET IDENTITY_INSERT [dbo].[Computer] OFF
GO
SET IDENTITY_INSERT [dbo].[Computer_Error] ON 

INSERT [dbo].[Computer_Error] ([ID], [ID_Computer], [ID_Component_Error], [ID_Component_Replace], [Commentary]) VALUES (1033, 2230, 8, 11, N' error de inicio')
INSERT [dbo].[Computer_Error] ([ID], [ID_Computer], [ID_Component_Error], [ID_Component_Replace], [Commentary]) VALUES (1034, 2234, 8, 11, N' error de inicio')
SET IDENTITY_INSERT [dbo].[Computer_Error] OFF
GO
INSERT [dbo].[Employee] ([Email]) VALUES (N'franco@gmail.com')
INSERT [dbo].[Employee] ([Email]) VALUES (N'kati@gmail.com')
INSERT [dbo].[Employee] ([Email]) VALUES (N'vilu@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1098, CAST(202800.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:22:50.733' AS DateTime), CAST(N'2021-03-29T21:22:50.733' AS DateTime), N'franco@gmail.com', N'juan@gmail', N'maincra 0', 2, NULL)
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1099, CAST(202800.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:22:50.810' AS DateTime), CAST(N'2021-03-29T21:22:50.810' AS DateTime), N'kati@gmail.com', N'juan@gmail', N'maincra 0', 2, NULL)
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1100, CAST(202800.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:22:50.883' AS DateTime), CAST(N'2021-03-29T21:22:50.883' AS DateTime), N'vilu@gmail.com', N'juan@gmail', N'maincra 0', 3, CAST(N'2021-03-26T21:22:50.907' AS DateTime))
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1101, CAST(67600.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:22:50.927' AS DateTime), CAST(N'2021-03-27T21:22:50.927' AS DateTime), N'kati@gmail.com', N'juan@gmail', N' error de inicio', 4, NULL)
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1102, CAST(202800.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:22:50.967' AS DateTime), CAST(N'2021-03-29T21:22:50.967' AS DateTime), N'franco@gmail.com', N'juan@gmail', N'maincra', 1, NULL)
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1103, CAST(67600.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:24:42.997' AS DateTime), CAST(N'2021-03-27T21:24:42.997' AS DateTime), N'vilu@gmail.com', N'juan@gmail', N' error de inicio', 4, NULL)
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1104, CAST(202800.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:24:43.077' AS DateTime), CAST(N'2021-03-29T21:24:43.077' AS DateTime), N'kati@gmail.com', N'juan@gmail', N'maincra', 1, NULL)
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1105, CAST(202800.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:24:43.097' AS DateTime), CAST(N'2021-03-29T21:24:43.097' AS DateTime), N'vilu@gmail.com', N'juan@gmail', N'maincra 0', 3, CAST(N'2021-03-26T21:24:43.133' AS DateTime))
INSERT [dbo].[Order] ([ID], [Price], [DateRequested], [DateToDelivery], [Email_Employee], [Email_client], [Commentary], [OrderState], [DateDelivered]) VALUES (1106, CAST(202800.00 AS Decimal(18, 2)), CAST(N'2021-03-26T21:24:43.157' AS DateTime), CAST(N'2021-03-29T21:24:43.157' AS DateTime), N'franco@gmail.com', N'juan@gmail', N'maincra 0', 2, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_State] ON 

INSERT [dbo].[Order_State] ([ID], [Name]) VALUES (1, N'Uncompleted')
INSERT [dbo].[Order_State] ([ID], [Name]) VALUES (2, N'Completed')
INSERT [dbo].[Order_State] ([ID], [Name]) VALUES (3, N'Delivered')
INSERT [dbo].[Order_State] ([ID], [Name]) VALUES (4, N'Mistake')
SET IDENTITY_INSERT [dbo].[Order_State] OFF
GO
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'_')
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'ATX')
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'ITX')
INSERT [dbo].[TypeFormat] ([Name]) VALUES (N'MATX')
GO
INSERT [dbo].[TypeMemory] ([Name]) VALUES (N'_')
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
ALTER TABLE [dbo].[Computer_Error]  WITH CHECK ADD  CONSTRAINT [FK_ComputerError_ComponentError] FOREIGN KEY([ID_Component_Error])
REFERENCES [dbo].[Component] ([ID])
GO
ALTER TABLE [dbo].[Computer_Error] CHECK CONSTRAINT [FK_ComputerError_ComponentError]
GO
ALTER TABLE [dbo].[Computer_Error]  WITH CHECK ADD  CONSTRAINT [FK_ComputerError_ComponentReplace] FOREIGN KEY([ID_Component_Replace])
REFERENCES [dbo].[Component] ([ID])
GO
ALTER TABLE [dbo].[Computer_Error] CHECK CONSTRAINT [FK_ComputerError_ComponentReplace]
GO
ALTER TABLE [dbo].[Computer_Error]  WITH CHECK ADD  CONSTRAINT [FK_ComputerError_Computer] FOREIGN KEY([ID_Computer])
REFERENCES [dbo].[Computer] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Computer_Error] CHECK CONSTRAINT [FK_ComputerError_Computer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Client1] FOREIGN KEY([Email_client])
REFERENCES [dbo].[Client] ([Email])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Client1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee1] FOREIGN KEY([Email_Employee])
REFERENCES [dbo].[Employee] ([Email])
ON UPDATE SET DEFAULT
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Order_State] FOREIGN KEY([OrderState])
REFERENCES [dbo].[Order_State] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Order_State]
GO
USE [master]
GO
ALTER DATABASE [SmartAssembly] SET  READ_WRITE 
GO
