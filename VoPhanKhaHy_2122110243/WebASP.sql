USE [WebASP]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 1/17/2025 6:32:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avartar] [nvarchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_Brannd] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/17/2025 6:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avartar] [nchar](100) NULL,
	[Slug] [varchar](100) NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[Deleted] [bit] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 1/17/2025 6:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CreatedOnUtc] [datetime] NULL,
	[Status] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 1/17/2025 6:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/17/2025 6:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Avartar] [nchar](100) NULL,
	[CategoryId] [int] NULL,
	[ShortDec] [nvarchar](100) NULL,
	[FullDecription] [nvarchar](500) NULL,
	[Price] [float] NULL,
	[PriceDiscount] [float] NULL,
	[TypeId] [int] NULL,
	[Slug] [varchar](50) NULL,
	[BrandId] [int] NULL,
	[Deleted] [bit] NULL,
	[ShowOnHomePage] [bit] NULL,
	[DisplayOrder] [int] NULL,
	[CreatedOnUtc] [datetime] NULL,
	[UpdatedOnUtc] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/17/2025 6:32:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [Avartar], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc], [Deleted]) VALUES (1, N'BANDAI', N'BANDAI.png', N'BANDAI', 1, 1, NULL, NULL, 0)
INSERT [dbo].[Brand] ([Id], [Name], [Avartar], [Slug], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc], [Deleted]) VALUES (2, N'SNAA', N'SNAA.jpg', N'SNAA', 1, 2, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Avartar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'MG', N'MG.jpg                                                                                              ', N'MG', 1, 1, 0, NULL, NULL)
INSERT [dbo].[Category] ([Id], [Name], [Avartar], [Slug], [ShowOnHomePage], [DisplayOrder], [Deleted], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (2, N'HG', N'HG_20250117053615.jpg                                                                               ', N'HG', 1, 2, 0, NULL, CAST(N'2025-01-17T17:36:15.530' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (1, N'DonHang-20250112135846', CAST(N'2025-01-12T13:58:46.017' AS DateTime), 1, 3)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (2, N'DonHang-20250112141037', CAST(N'2025-01-12T14:10:37.450' AS DateTime), 1, 3)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (3, N'DonHang-20250112141515', CAST(N'2025-01-12T14:15:15.157' AS DateTime), 1, 3)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (4, N'DonHang-20250112141830', CAST(N'2025-01-12T14:18:30.640' AS DateTime), 1, 3)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (5, N'DonHang-20250116171240', CAST(N'2025-01-16T17:12:40.000' AS DateTime), 6, 8)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (6, N'DonHang-20250116214747', CAST(N'2025-01-16T21:47:47.663' AS DateTime), 1, 8)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (7, N'DonHang-20250116215228', CAST(N'2025-01-16T21:52:28.150' AS DateTime), 1, 8)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (8, N'DonHang-20250116215602', CAST(N'2025-01-16T21:56:02.920' AS DateTime), 1, 8)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (9, N'DonHang-20250116220203', CAST(N'2025-01-16T22:02:03.000' AS DateTime), 1, 8)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (10, N'DonHang-20250117131103', CAST(N'2025-01-17T13:11:03.000' AS DateTime), 4, 8)
INSERT [dbo].[Order] ([Id], [Name], [CreatedOnUtc], [Status], [UserId]) VALUES (11, N'DonHang-20250117175844', CAST(N'2025-01-17T17:58:44.807' AS DateTime), 1, 9)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (1, 4, 1, 1)
INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (2, 5, 1, 2)
INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (3, 6, 1, 1)
INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (4, 7, 1, 1)
INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (5, 8, 19, 1)
INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (6, 9, 1, 3)
INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (7, 10, 35, 1)
INSERT [dbo].[OrderDetail] ([Id], [OderId], [ProductId], [Quantity]) VALUES (8, 11, 1, 1)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Avartar], [CategoryId], [ShortDec], [FullDecription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (1, N'HG1_144GhostGundam-003', N'HG1_144GhostGundam-003.jpg                                                                          ', 1, N'Chính hãng', N'Xuất xứ: Nhật Bản
Chất liệu: Nhựa abs
Chiều cao: 14cm', 500000, 450000, 1, N'HG1_144GhostGundam-003', 1, 0, 1, NULL, NULL, NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avartar], [CategoryId], [ShortDec], [FullDecription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (32, N' HG3_144GhostGundam-003', N'HG1_144GhostGundam-003_20250116110315.jpg                                                           ', 1, N'ko ngon', N'không ngon ', 111, 111, 2, N'Hg', 1, NULL, NULL, NULL, CAST(N'2025-01-16T23:03:15.037' AS DateTime), NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avartar], [CategoryId], [ShortDec], [FullDecription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (33, N' HG4_144GhostGundam-003', N'HG1_144GhostGundam-003_20250116110350.jpg                                                           ', 2, N'ko ngon', N'không ngon ', 10000, 10000, 1, N'HG', 1, NULL, NULL, NULL, CAST(N'2025-01-16T23:03:50.623' AS DateTime), NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avartar], [CategoryId], [ShortDec], [FullDecription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (34, N' MG5_144GhostGundam-003', N'HG1_144GhostGundam-003_20250116110457.jpg                                                           ', 1, N'ko ngon', N'không ngon ', 100000, 10000, 1, N'MG', 2, NULL, NULL, NULL, CAST(N'2025-01-16T23:04:57.383' AS DateTime), NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avartar], [CategoryId], [ShortDec], [FullDecription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (35, N' MG7_144GhostGundam-003', N'HG1_144GhostGundam-003_20250116110529.jpg                                                           ', 1, N'ko ngon', N'không ngon ', 1000000, 100000, 1, N'MG', 1, NULL, NULL, NULL, CAST(N'2025-01-16T23:05:29.633' AS DateTime), NULL)
INSERT [dbo].[Product] ([Id], [Name], [Avartar], [CategoryId], [ShortDec], [FullDecription], [Price], [PriceDiscount], [TypeId], [Slug], [BrandId], [Deleted], [ShowOnHomePage], [DisplayOrder], [CreatedOnUtc], [UpdatedOnUtc]) VALUES (36, N' MG5_144GhostGundam-003', N'HG1_144GhostGundam-003_20250117050934.jpg                                                           ', 1, N'Chính hãng ', N'Hàng nhập khẩu chính hãng', 1000000, 10000, 2, N'MG', 2, NULL, NULL, NULL, CAST(N'2025-01-17T17:09:34.887' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin]) VALUES (3, N'Admin', N'1', N'admin@gmail.com', N'e00cf25ad42683b3df678c61f42c6bda', 1)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin]) VALUES (8, N'võ', N'hy', N'vophankhahy12@gmail.com', N'e10adc3949ba59abbe56e057f20f883e', 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [IsAdmin]) VALUES (9, N'hy', N'hu', N'hu@gmail.com', N'c4ca4238a0b923820dcc509a6f75849b', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1: Đặt hàng thành công , 2: Đang xử lý, 3: Đã thanh toán, 4: Đang giao, 5: Hoàn thành, 6: Đã hủy' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'TypeId'
GO
