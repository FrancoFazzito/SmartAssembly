USE [master]
GO
/****** Object:  Database [SmartAssembly]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[Client]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[Component]    Script Date: 5/4/2021 14:37:02 ******/
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
	[Stock_Limit] [int] NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Component_Computer]    Script Date: 5/4/2021 14:37:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component_Computer](
	[ID_Component] [int] NOT NULL,
	[ID_Computer] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Computer]    Script Date: 5/4/2021 14:37:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Order] [int] NOT NULL,
	[TypeUse] [varchar](50) NOT NULL,
	[Completed] [bit] NULL,
 CONSTRAINT [PK_Computer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Computer_Error]    Script Date: 5/4/2021 14:37:02 ******/
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
	[DateError] [datetime] NULL,
 CONSTRAINT [PK_ComputerError] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cost]    Script Date: 5/4/2021 14:37:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cost](
	[Name] [varchar](50) NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_Costs] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[Order_State]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[TypeFormat]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[TypeMemory]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[TypePart]    Script Date: 5/4/2021 14:37:02 ******/
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
/****** Object:  Table [dbo].[TypeUse]    Script Date: 5/4/2021 14:37:02 ******/
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
ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_Stock_Limit]  DEFAULT ((1)) FOR [Stock_Limit]
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
