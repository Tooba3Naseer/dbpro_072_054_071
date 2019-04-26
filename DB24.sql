USE [master]
GO
/****** Object:  Database [DB24]    Script Date: 4/26/2019 9:07:17 PM ******/
CREATE DATABASE [DB24]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB24', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DB24.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DB24_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DB24_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DB24] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB24].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB24] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB24] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB24] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB24] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB24] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB24] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB24] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DB24] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB24] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB24] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB24] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB24] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB24] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB24] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB24] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB24] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DB24] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB24] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB24] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB24] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB24] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB24] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB24] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB24] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB24] SET  MULTI_USER 
GO
ALTER DATABASE [DB24] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB24] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB24] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB24] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DB24]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/26/2019 9:07:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChefOrder]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChefOrder](
	[OrderId] [int] NOT NULL,
	[ChefId] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChefOrder] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ChefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] NOT NULL,
	[RegistrationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Delivery Team]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Create Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Delivery Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designation]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[designationOfEmployee] [varchar](50) NOT NULL,
	[Salary] [money] NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] NOT NULL,
	[EmployeeRegNo] [nvarchar](20) NOT NULL,
	[HireDate] [date] NULL,
	[DesignationId] [int] NOT NULL,
	[EmployeeTypeId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EmployeeType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[comment] [varchar](max) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[Description] [varchar](max) NULL,
 CONSTRAINT [PK_FoodCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MenuCard]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MenuCard](
	[FoodId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[QuantityPerUnit] [varchar](max) NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[ImagePath] [varchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_MenuCard] PRIMARY KEY CLUSTERED 
(
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[FoodId] [int] NOT NULL,
	[Quantity] [varchar](50) NOT NULL,
	[Discount] [money] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[TotalBill] [money] NOT NULL,
	[DeliveryAddress] [varchar](max) NOT NULL,
	[BillingAddress] [varchar](max) NOT NULL,
	[DeliveryArea] [varchar](max) NOT NULL,
	[DeliveryCity] [varchar](50) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders DeliveryTeams]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders DeliveryTeams](
	[OrderId] [int] NOT NULL,
	[DeliveryTeamId] [int] NOT NULL,
	[DeliveryStatus] [varchar](50) NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
	[Bill Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Orders DeliveryTeams] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrdersVehicles]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrdersVehicles](
	[OrderId] [int] NOT NULL,
	[VehicleId] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_OrdersVehicles] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Purchased Items]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchased Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[QuantityPerUnit] [varchar](50) NULL,
	[UnitsInStock] [int] NULL,
	[UnitPrice] [money] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierId] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[ContactName] [varchar](50) NULL,
	[Address] [varchar](max) NOT NULL,
	[PhoneNo] [varchar](20) NOT NULL,
	[City] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Area] [varchar](50) NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeamMembers]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TeamMembers](
	[TeamId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TeamMembers] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC,
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Contact] [varchar](20) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[City] [varchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 4/26/2019 9:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ChefOrder]  WITH CHECK ADD  CONSTRAINT [FK_ChefOrder_Employee] FOREIGN KEY([ChefId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[ChefOrder] CHECK CONSTRAINT [FK_ChefOrder_Employee]
GO
ALTER TABLE [dbo].[ChefOrder]  WITH CHECK ADD  CONSTRAINT [FK_ChefOrder_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[ChefOrder] CHECK CONSTRAINT [FK_ChefOrder_Orders]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Users] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Users]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Designation]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeType] FOREIGN KEY([EmployeeTypeId])
REFERENCES [dbo].[EmployeeType] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeType]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Users] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Users]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Customer]
GO
ALTER TABLE [dbo].[MenuCard]  WITH CHECK ADD  CONSTRAINT [FK_MenuCard_FoodCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[FoodCategory] ([Id])
GO
ALTER TABLE [dbo].[MenuCard] CHECK CONSTRAINT [FK_MenuCard_FoodCategory]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_MenuCard] FOREIGN KEY([FoodId])
REFERENCES [dbo].[MenuCard] ([FoodId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_MenuCard]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employee]
GO
ALTER TABLE [dbo].[Orders DeliveryTeams]  WITH CHECK ADD  CONSTRAINT [FK_Orders DeliveryTeams_Delivery Team] FOREIGN KEY([DeliveryTeamId])
REFERENCES [dbo].[Delivery Team] ([Id])
GO
ALTER TABLE [dbo].[Orders DeliveryTeams] CHECK CONSTRAINT [FK_Orders DeliveryTeams_Delivery Team]
GO
ALTER TABLE [dbo].[Orders DeliveryTeams]  WITH CHECK ADD  CONSTRAINT [FK_Orders DeliveryTeams_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[Orders DeliveryTeams] CHECK CONSTRAINT [FK_Orders DeliveryTeams_Orders]
GO
ALTER TABLE [dbo].[OrdersVehicles]  WITH CHECK ADD  CONSTRAINT [FK_OrdersVehicles_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrdersVehicles] CHECK CONSTRAINT [FK_OrdersVehicles_Orders]
GO
ALTER TABLE [dbo].[OrdersVehicles]  WITH CHECK ADD  CONSTRAINT [FK_OrdersVehicles_Vehicles] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([Id])
GO
ALTER TABLE [dbo].[OrdersVehicles] CHECK CONSTRAINT [FK_OrdersVehicles_Vehicles]
GO
ALTER TABLE [dbo].[Purchased Items]  WITH CHECK ADD  CONSTRAINT [FK_Purchased Items_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Purchased Items] CHECK CONSTRAINT [FK_Purchased Items_Categories]
GO
ALTER TABLE [dbo].[Purchased Items]  WITH CHECK ADD  CONSTRAINT [FK_Purchased Items_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Suppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[Purchased Items] CHECK CONSTRAINT [FK_Purchased Items_Suppliers]
GO
ALTER TABLE [dbo].[TeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_TeamMembers_Delivery Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Delivery Team] ([Id])
GO
ALTER TABLE [dbo].[TeamMembers] CHECK CONSTRAINT [FK_TeamMembers_Delivery Team]
GO
ALTER TABLE [dbo].[TeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_TeamMembers_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[TeamMembers] CHECK CONSTRAINT [FK_TeamMembers_Employee]
GO
USE [master]
GO
ALTER DATABASE [DB24] SET  READ_WRITE 
GO
