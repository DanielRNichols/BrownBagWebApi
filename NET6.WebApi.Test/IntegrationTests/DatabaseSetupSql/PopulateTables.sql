USE [brownbags_integrationtests]
GO

DELETE from Presenters where Id > 0;
DELETE from Sessions where Id > 0;

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
