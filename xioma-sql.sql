USE [XiomaData]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 08/08/2021 15:21:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Role] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[DateOfEntry] [datetime] NULL,
	[Remarks] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [DateOfBirth], [Role], [Department], [DateOfEntry], [Remarks], [Address]) VALUES (1234567, N'Eyal', N'Birenbaum', CAST(N'1988-07-13T00:00:00.000' AS DateTime), N'HR Manager', N'HR', CAST(N'2021-08-08T00:00:00.000' AS DateTime), NULL, N'Tel aviv.')
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [DateOfBirth], [Role], [Department], [DateOfEntry], [Remarks], [Address]) VALUES (52428528, N'itamar', N'choen', NULL, N'Developer', N'R&D', CAST(N'2021-08-08T00:00:00.000' AS DateTime), NULL, N't')
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [DateOfBirth], [Role], [Department], [DateOfEntry], [Remarks], [Address]) VALUES (316665678, N'Natia', N'Svanidze', CAST(N'1991-06-10T00:00:00.000' AS DateTime), N'IT SPECIALIST', N'IT', CAST(N'2021-08-08T00:00:00.000' AS DateTime), N'TEST TEST.....', N'Tel Aviv, Yeffet. 77575')
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_DateOfEntry]  DEFAULT (getdate()) FOR [DateOfEntry]
GO
