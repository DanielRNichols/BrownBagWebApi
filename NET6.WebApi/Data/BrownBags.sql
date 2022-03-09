USE [BrownBags]
GO
/****** Object:  Table [dbo].[Presenters]    Script Date: 3/8/2022 11:19:56 AM ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 3/8/2022 11:19:56 AM ******/
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
/****** Object:  Table [dbo].[SessionsPresenters]    Script Date: 3/8/2022 11:19:56 AM ******/
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


Insert into Presenters (Name, Bio, Image, ImageSmall) Values
('Andy Anderson', '.NET Specialist', 'presenter_andy.png' ,'presenter_small_andy.png'),
('Bonnie Bonneville', 'Web Guru', 'presenter_bonnie.png' ,'presenter_small_bonnie.png'),
('Chuck Charles', 'Front-End Master', 'presenter_chuck.png' ,'presenter_small_chuck.png'),
('Donna Donaldson', 'Blazor Trailblazer', 'presenter_donna.png' ,'presenter_small_donna.png'),
('Eva Evans', 'Plus Plus with C++', 'presenter_eva.png' ,'presenter_small_eva.png');
GO

Insert into Sessions (Name, PresentationDate, ShortDescription) Values
('Whats New in C#', '02/03/2022', 'Latest and greatest C# features'),
('Javascript Frameworks', '02/10/2022', 'React, Angular and more'),
('VS Tips & Tricks', '02/17/2022', 'VS Production Tips'),
('Gaming with Unity', '02/24/2022', 'Creating great games with .NET and Unity'),
('Fun with Unit Testing', '03/03/2022', 'Unit testing using XUnit'),
('Open Mic Night', '03/10/2022', 'Round robin discussion'),
('Blazor Mania', '03/17/2022', 'Building WebApps with Blazor'),
('Maui', '03/24/2022', 'Introduction to .NET MAUI'),
('Knock the Rust Off', '03/31/2022', 'Introduction to Rust');
GO

Insert Into SessionsPresenters (SessionId, PresenterId) Values
(1,1),
(2,3),
(3,2),
(4,5),
(5,1),
(6,2),
(7,2),
(7,3),
(7,5),
(8,4),
(9,1),
(9,4)
GO

Select * from Presenters;
Select * from Sessions;
Select * from SessionsPresenters;
