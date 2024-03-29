USE [InsertExamples]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 1/25/2024 8:24:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (1, N'Benny', N'Anderson', CAST(N'2005-05-27' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (2, N'Teri', N'Schaefer', CAST(N'2002-12-19' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (3, N'Clint', N'Mante', CAST(N'2005-09-15' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (4, N'Drew', N'Green', CAST(N'2002-01-08' AS Date))
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [BirthDate]) VALUES (5, N'Denise', N'Schaden', CAST(N'2001-01-08' AS Date))
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
