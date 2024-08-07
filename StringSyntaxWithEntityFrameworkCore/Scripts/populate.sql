USE [BirthDaysDatabase]
GO
/****** Object:  Table [dbo].[BirthDays]    Script Date: 7/7/2024 8:39:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BirthDays](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
	[YearsOld]  AS ((CONVERT([int],format(getdate(),'yyyyMMdd'))-CONVERT([int],format([BirthDate],'yyyyMMdd')))/(10000)),
 CONSTRAINT [PK_BirthDays] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BirthDays] ON 

INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Stefanie', N'Buckley', CAST(N'1967-02-02' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Sandy', N'Mc Gee', CAST(N'1986-06-26' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Lee', N'Warren', CAST(N'1994-07-09' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Regina', N'Forbes', CAST(N'1962-07-12' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Daniel', N'Kim', CAST(N'1979-11-27' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (6, N'Dennis', N'Nunez', CAST(N'1961-09-01' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (7, N'Myra', N'Zuniga', CAST(N'1965-01-04' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (8, N'Teddy', N'Ingram', CAST(N'1998-06-20' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (9, N'Annie', N'Larson', CAST(N'1969-09-27' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (10, N'Herman', N'Anderson', CAST(N'1971-03-29' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (11, N'Jenifer', N'Livingston', CAST(N'1977-02-06' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (12, N'Stefanie', N'Perez', CAST(N'1991-11-09' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (13, N'Chastity', N'Garcia', CAST(N'1986-05-12' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (14, N'Evelyn', N'Stokes', CAST(N'1954-06-15' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (15, N'Jeannie', N'Daniel', CAST(N'1956-12-09' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (16, N'Rickey', N'Santos', CAST(N'1996-05-22' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (17, N'Bobbie', N'Hurst', CAST(N'1958-12-05' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (18, N'Lesley', N'Lawson', CAST(N'1994-01-21' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (19, N'Shawna', N'Browning', CAST(N'1989-05-28' AS Date))
INSERT [dbo].[BirthDays] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (20, N'Theresa', N'Ross', CAST(N'1975-11-10' AS Date))
SET IDENTITY_INSERT [dbo].[BirthDays] OFF
GO
USE [master]
GO
ALTER DATABASE [BirthDaysDatabase] SET  READ_WRITE 
GO
