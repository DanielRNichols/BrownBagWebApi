
USE [master]
GO
ALTER database BrownBags_IntegrationTests set single_user with rollback immediate
GO

/****** Object:  Database [BrownBags_IntegrationTests]    Script Date: 3/15/2022 9:07:16 AM ******/
DROP DATABASE IF EXISTS [BrownBags_IntegrationTests]
GO
/****** Object:  Database [BrownBags_IntegrationTests]    Script Date: 3/15/2022 9:07:16 AM ******/
CREATE DATABASE [BrownBags_IntegrationTests]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BrownBags_IntegrationTests', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BrownBags_IntegrationTests.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BrownBags_IntegrationTests_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BrownBags_IntegrationTests_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BrownBags_IntegrationTests].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET ARITHABORT OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET  MULTI_USER 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET QUERY_STORE = OFF
GO
USE [BrownBags_IntegrationTests]
GO
/****** Object:  Table [dbo].[Presenters]    Script Date: 3/15/2022 9:07:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presenters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Bio] [nvarchar](max) NULL,
	[Image] [nvarchar](512) NULL,
	[ImageSmall] [nvarchar](512) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Presenters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 3/15/2022 9:07:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[PresentationDate] [datetime2](7) NOT NULL,
	[ShortDescription] [nvarchar](256) NULL,
	[Description] [nvarchar](1024) NULL,
	[Summary] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SessionsPresenters]    Script Date: 3/15/2022 9:07:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SessionsPresenters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionId] [int] NOT NULL,
	[PresenterId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[ModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_SessionsPresenters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Presenters] ON 
GO
INSERT [dbo].[Presenters] ([Id], [Name], [Bio], [Image], [ImageSmall], [CreatedAt], [ModifiedAt]) VALUES (3, N'Andy Anderson', N'.NET Specialist', N'presenter_andy.png', N'presenter_small_andy.png', CAST(N'2022-03-09T14:05:06.1966667' AS DateTime2), NULL)
GO
INSERT [dbo].[Presenters] ([Id], [Name], [Bio], [Image], [ImageSmall], [CreatedAt], [ModifiedAt]) VALUES (4, N'Bonnie Bonneville', N'Web Guru', N'presenter_bonnie.png', N'presenter_small_bonnie.png', CAST(N'2022-03-09T14:05:06.1966667' AS DateTime2), NULL)
GO
INSERT [dbo].[Presenters] ([Id], [Name], [Bio], [Image], [ImageSmall], [CreatedAt], [ModifiedAt]) VALUES (5, N'Chuck Charles', N'Front-End Master', N'presenter_chuck.png', N'presenter_small_chuck.png', CAST(N'2022-03-09T14:05:06.1966667' AS DateTime2), NULL)
GO
INSERT [dbo].[Presenters] ([Id], [Name], [Bio], [Image], [ImageSmall], [CreatedAt], [ModifiedAt]) VALUES (6, N'Donna Donaldson', N'Blazor Trailblazer', N'presenter_donna.png', N'presenter_small_donna.png', CAST(N'2022-03-09T14:05:06.1966667' AS DateTime2), NULL)
GO
INSERT [dbo].[Presenters] ([Id], [Name], [Bio], [Image], [ImageSmall], [CreatedAt], [ModifiedAt]) VALUES (7, N'Eva Evans', N'Plus Plus with C++', N'presenter_eva.png', N'presenter_small_eva.png', CAST(N'2022-03-09T14:05:06.1966667' AS DateTime2), NULL)
GO
INSERT [dbo].[Presenters] ([Id], [Name], [Bio], [Image], [ImageSmall], [CreatedAt], [ModifiedAt]) VALUES (8, N'Francis France', N'Favors F#', N'presenter_francis.png', N'presenter_small_francis.png', CAST(N'2022-03-09T14:17:19.8933333' AS DateTime2), CAST(N'2022-03-09T17:29:18.9166667' AS DateTime2))
GO
INSERT [dbo].[Presenters] ([Id], [Name], [Bio], [Image], [ImageSmall], [CreatedAt], [ModifiedAt]) VALUES (9, N'Georgette George', N'Debugger Extraordinaire', N'presenter_gina.png', N'presenter_small_gina.png', CAST(N'2022-03-09T14:26:17.0000000' AS DateTime2), CAST(N'2022-03-09T17:41:56.8933333' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Presenters] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (6, N'Whats New in C#', CAST(N'2022-02-03T00:00:00.0000000' AS DateTime2), N'Latest and greatest C# features', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (7, N'Javascript Frameworks', CAST(N'2022-02-10T00:00:00.0000000' AS DateTime2), N'React, Angular and more', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (8, N'VS Tips & Tricks', CAST(N'2022-02-17T00:00:00.0000000' AS DateTime2), N'VS Production Tips', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (9, N'Gaming with Unity', CAST(N'2022-02-24T00:00:00.0000000' AS DateTime2), N'Creating great games with .NET and Unity', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (10, N'Fun with Unit Testing', CAST(N'2022-03-03T00:00:00.0000000' AS DateTime2), N'Unit testing using XUnit', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (11, N'Open Mic Night', CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2), N'Round robin discussion', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (12, N'Blazor Mania', CAST(N'2022-03-17T00:00:00.0000000' AS DateTime2), N'Building WebApps with Blazor', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (13, N'Maui', CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), N'Introduction to .NET MAUI', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
INSERT [dbo].[Sessions] ([Id], [Name], [PresentationDate], [ShortDescription], [Description], [Summary], [CreatedAt], [ModifiedAt]) VALUES (14, N'Knock the Rust Off', CAST(N'2022-03-31T00:00:00.0000000' AS DateTime2), N'Introduction to Rust', NULL, NULL, CAST(N'2022-03-09T14:05:52.4266667' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[SessionsPresenters] ON 
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (1, 6, 3, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (2, 7, 5, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (3, 7, 4, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (4, 8, 7, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (5, 9, 3, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (6, 10, 4, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (7, 11, 4, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (8, 11, 5, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (9, 11, 7, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (10, 12, 6, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (11, 13, 3, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
INSERT [dbo].[SessionsPresenters] ([Id], [SessionId], [PresenterId], [CreatedAt], [ModifiedAt]) VALUES (12, 13, 6, CAST(N'2022-03-09T14:06:35.3666667' AS DateTime2), NULL)
GO
SET IDENTITY_INSERT [dbo].[SessionsPresenters] OFF
GO
ALTER TABLE [dbo].[Presenters] ADD  CONSTRAINT [DF_Presenters_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Presenters] ADD  CONSTRAINT [DF_Presenters_ModifiedAt]  DEFAULT (getdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [DF_Sessions_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Sessions] ADD  CONSTRAINT [DF_Sessions_ModifiedAt]  DEFAULT (getdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[SessionsPresenters] ADD  CONSTRAINT [DF_SessionsPresenters_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[SessionsPresenters] ADD  CONSTRAINT [DF_SessionsPresenters_ModifiedAt]  DEFAULT (getdate()) FOR [ModifiedAt]
GO
ALTER TABLE [dbo].[SessionsPresenters]  WITH CHECK ADD  CONSTRAINT [FK_SessionsPresenters_Presenters] FOREIGN KEY([PresenterId])
REFERENCES [dbo].[Presenters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SessionsPresenters] CHECK CONSTRAINT [FK_SessionsPresenters_Presenters]
GO
ALTER TABLE [dbo].[SessionsPresenters]  WITH CHECK ADD  CONSTRAINT [FK_SessionsPresenters_Sessions] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SessionsPresenters] CHECK CONSTRAINT [FK_SessionsPresenters_Sessions]
GO
USE [master]
GO
ALTER DATABASE [BrownBags_IntegrationTests] SET  READ_WRITE 
GO


Use [BrownBags_IntegrationTests]
Select * from Presenters;
Select * from Sessions;
Select * from SessionsPresenters;
