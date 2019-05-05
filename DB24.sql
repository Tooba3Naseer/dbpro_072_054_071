USE [master]
GO
/****** Object:  Database [DB24]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[ChefOrder]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Delivery Team]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Designation]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[EmployeeType]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[MenuCard]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[FoodId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Discount] [money] NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[FoodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[OrderDate] [datetime] NOT NULL,
	[DeliveryDate] [datetime] NULL,
	[TotalBill] [money] NULL,
	[DeliveryAddress] [varchar](max) NOT NULL,
	[BillingAddress] [varchar](max) NOT NULL,
	[DeliveryArea] [varchar](max) NULL,
	[DeliveryCity] [varchar](50) NULL,
	[DeliveryStatus] [varchar](50) NOT NULL,
	[BillingStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders DeliveryTeams]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders DeliveryTeams](
	[OrderId] [int] NOT NULL,
	[DeliveryTeamId] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders DeliveryTeams] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchased Items]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Suppliers]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[TeamMembers]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 5/5/2019 1:03:48 AM ******/
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
/****** Object:  View [dbo].[ChefOrderDetails]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create View [dbo].[ChefOrderDetails] AS
 Select Concat(FirstName, LastName) As "Chef Name" ,  OrderId, ChefOrder.[Status] AS "Order Status" From
 ((ChefOrder JOIN Employee ON Employee.EmployeeId = ChefOrder.ChefId) JOIN Users ON Users.Id = Employee.EmployeeId)  
GO
/****** Object:  View [dbo].[CustomerOrder]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[CustomerOrder] As
Select Concat(FirstName, LastName) As "Customer Name" , Orders.OrderId , MenuCard.Name AS "Food Name" , 
 OrderDate AS "Order Date", DeliveryDate, Quantity, UnitPrice*Quantity As Price
 From ((((Orders JOIN OrderDetails ON Orders.OrderId = OrderDetails.OrderId) 
JOIN Customer ON Customer.Id = Orders.CustomerId) 
JOIN MenuCard ON MenuCard.FoodId = OrderDetails.FoodId) JOIN Users On Users.Id = Customer.Id)
GO
/****** Object:  View [dbo].[CustomerOrderDetails]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create View [dbo].[CustomerOrderDetails] AS
Select Concat(FirstName, LastName) As CustomerName , OrderId, TotalBill From ((Orders JOIN Customer
 ON Customer.Id = Orders.CustomerId)JOIN Users ON Customer.Id = Users.Id)
GO
/****** Object:  View [dbo].[CustomersFeedback]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[CustomersFeedback] As
Select Concat(FirstName, LastName) As CustomerName , comment As Feedback From ((Feedback JOIN Customer
 ON Customer.Id = Feedback.CustomerId)	JOIN Users On Users.Id = Customer.Id)
GO
/****** Object:  View [dbo].[DailyIncome]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create View [dbo].[DailyIncome] As
 Select OrderDate, Count(CustomerId) As "Total Customers", Sum(TotalBill) As "Total Income"  From
 (Customer JOIN Orders ON Customer.Id = Orders.CustomerId) Group by(OrderDate)
GO
/****** Object:  View [dbo].[DesignationDetails]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[DesignationDetails] As
Select designation.designationOfEmployee  As Designation, Count(EmployeeId)  As "Num Of Employees" From (Employee 
JOIN Designation ON Designation.id = Employee.DesignationId)
Group by ( designationOfEmployee)
GO
/****** Object:  View [dbo].[EmployeeDetails]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[EmployeeDetails] As
Select Concat(FirstName, LastName) As "Employee Name" , Salary , designationOfEmployee As Designation From ((Users JOIN 
Employee ON Employee.EmployeeId = UserS.Id) JOIN Designation on Employee.DesignationId = Designation.Id)
GO
/****** Object:  View [dbo].[MenuCardDetails]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 Create View [dbo].[MenuCardDetails] AS 
 Select CategoryName, Count(FoodId) As "Num of Food Items"  From
 (FoodCategory JOIN MenuCard ON MenuCard.CategoryId = FoodCategory.Id)
 Group By(CategoryName)
GO
/****** Object:  View [dbo].[PurchasedItemsDetails]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[PurchasedItemsDetails] AS
 Select Name AS "Product Name", CategoryName, CompanyName From
 (([Purchased Items] JOIN Suppliers ON [Purchased Items].SupplierId = Suppliers.SupplierId)
 JOIN Categories ON [Purchased Items].CategoryId = Categories.CategoryId)
GO
/****** Object:  View [dbo].[TotalPurchasedItems]    Script Date: 5/5/2019 1:03:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  Create View [dbo].[TotalPurchasedItems] AS
 SELECT CompanyName AS "Company Name", Count(Id) AS "Total Purchased Items" FROM [Purchased Items] JOIN Suppliers ON Suppliers.SupplierId = [Purchased Items].SupplierId GROUP BY CompanyName
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (9, N'oils', N'cdsaasd')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [designationOfEmployee], [Salary]) VALUES (1, N'Manager', 100000.0000)
INSERT [dbo].[Designation] ([Id], [designationOfEmployee], [Salary]) VALUES (2, N'Chef', 50000.0000)
INSERT [dbo].[Designation] ([Id], [designationOfEmployee], [Salary]) VALUES (3, N'Deliverer', 30000.0000)
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EmployeeType] ON 

INSERT [dbo].[EmployeeType] ([Id], [Type]) VALUES (1, N'Admin')
INSERT [dbo].[EmployeeType] ([Id], [Type]) VALUES (2, N'Chef')
INSERT [dbo].[EmployeeType] ([Id], [Type]) VALUES (3, N'Deliverer')
SET IDENTITY_INSERT [dbo].[EmployeeType] OFF
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([Id], [CategoryName], [Description]) VALUES (2, N'Mexican', N'best food in town')
INSERT [dbo].[FoodCategory] ([Id], [CategoryName], [Description]) VALUES (3, N'Thai', N'delicious')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
SET IDENTITY_INSERT [dbo].[MenuCard] ON 

INSERT [dbo].[MenuCard] ([FoodId], [Name], [Description], [QuantityPerUnit], [UnitPrice], [ImagePath], [CategoryId]) VALUES (5, N'Cheese burger', N'tasty cheese burger', N'5 pound', 200.0000, N'~/assets/images/food2192555567.jpg', 2)
INSERT [dbo].[MenuCard] ([FoodId], [Name], [Description], [QuantityPerUnit], [UnitPrice], [ImagePath], [CategoryId]) VALUES (6, N'pasta', N'unique and tasty', N'3 pound', 200.0000, N'~/assets/images/food4190500465.jpg', 2)
INSERT [dbo].[MenuCard] ([FoodId], [Name], [Description], [QuantityPerUnit], [UnitPrice], [ImagePath], [CategoryId]) VALUES (8, N'Zinger Burger', N'layered burger', N'1 pound', 300.0000, N'~/assets/images/update1193236378.jpg', 3)
INSERT [dbo].[MenuCard] ([FoodId], [Name], [Description], [QuantityPerUnit], [UnitPrice], [ImagePath], [CategoryId]) VALUES (9, N'Egg rolls', N'tasty food in town', N'2 pound', 400.0000, N'~/assets/images/food1193416638.jpg', 2)
SET IDENTITY_INSERT [dbo].[MenuCard] OFF
SET IDENTITY_INSERT [dbo].[Purchased Items] ON 

INSERT [dbo].[Purchased Items] ([Id], [Name], [SupplierId], [CategoryId], [QuantityPerUnit], [UnitsInStock], [UnitPrice]) VALUES (1, N'basmati', 1, 9, N'34 kg', 3, 200.0000)
SET IDENTITY_INSERT [dbo].[Purchased Items] OFF
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([SupplierId], [CompanyName], [ContactName], [Address], [PhoneNo], [City], [Country], [Area]) VALUES (1, N'rice shop', N'ali hammad', N'gt road', N'090078601', N'Karachi', N'Pakistan', N'Cantt')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
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
