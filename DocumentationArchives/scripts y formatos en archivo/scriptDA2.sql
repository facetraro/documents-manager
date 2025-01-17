USE [DocumentsManagerDatabase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Footer_Id] [uniqueidentifier] NULL,
	[Format_Id] [uniqueidentifier] NULL,
	[Header_Id] [uniqueidentifier] NULL,
	[StyleClass_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Footers]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Footers](
	[Id] [uniqueidentifier] NOT NULL,
	[StyleClass_Id] [uniqueidentifier] NULL,
	[Text_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Footers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Formats]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formats](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Formats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FormatStyleClasses]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormatStyleClasses](
	[Format_Id] [uniqueidentifier] NOT NULL,
	[StyleClass_Id] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.FormatStyleClasses] PRIMARY KEY CLUSTERED 
(
	[Format_Id] ASC,
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Friendships]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friendships](
	[Id] [uniqueidentifier] NOT NULL,
	[State] [int] NOT NULL,
	[Request_Id] [uniqueidentifier] NULL,
	[Requested_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Friendships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Headers]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Headers](
	[Id] [uniqueidentifier] NOT NULL,
	[StyleClass_Id] [uniqueidentifier] NULL,
	[Text_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Headers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoggerTypes]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoggerTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[UserBy] [nvarchar](max) NULL,
	[Action] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LoggerTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModifyDocumentHistories]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModifyDocumentHistories](
	[Id] [uniqueidentifier] NOT NULL,
	[Date] [datetime] NOT NULL,
	[State] [int] NOT NULL,
	[Document_Id] [uniqueidentifier] NULL,
	[User_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.ModifyDocumentHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parragraphs]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parragraphs](
	[Id] [uniqueidentifier] NOT NULL,
	[Document_Id] [uniqueidentifier] NULL,
	[StyleClass_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Parragraphs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [uniqueidentifier] NOT NULL,
	[Rating] [int] NOT NULL,
	[FeedBack] [nvarchar](max) NULL,
	[Commentator_Id] [uniqueidentifier] NULL,
	[Commented_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[token] [uniqueidentifier] NOT NULL,
	[idLogged] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_dbo.Sessions] PRIMARY KEY CLUSTERED 
(
	[token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StyleAttributes]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StyleAttributes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[TextAlignment] [int] NULL,
	[Applies] [int] NULL,
	[FontType] [int] NULL,
	[Size] [int] NULL,
	[TextColor] [int] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
	[Style_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.StyleAttributes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StyleClasses]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StyleClasses](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Based_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.StyleClasses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Texts]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Texts](
	[Id] [uniqueidentifier] NOT NULL,
	[WrittenText] [nvarchar](max) NULL,
	[StyleClass_Id] [uniqueidentifier] NULL,
	[Parragraph_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.Texts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 21/06/2018 20:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documents_dbo.Footers_Footer_Id] FOREIGN KEY([Footer_Id])
REFERENCES [dbo].[Footers] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_dbo.Documents_dbo.Footers_Footer_Id]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documents_dbo.Formats_Format_Id] FOREIGN KEY([Format_Id])
REFERENCES [dbo].[Formats] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_dbo.Documents_dbo.Formats_Format_Id]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documents_dbo.Headers_Header_Id] FOREIGN KEY([Header_Id])
REFERENCES [dbo].[Headers] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_dbo.Documents_dbo.Headers_Header_Id]
GO
ALTER TABLE [dbo].[Documents]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Documents_dbo.StyleClasses_StyleClass_Id] FOREIGN KEY([StyleClass_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[Documents] CHECK CONSTRAINT [FK_dbo.Documents_dbo.StyleClasses_StyleClass_Id]
GO
ALTER TABLE [dbo].[Footers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Footers_dbo.StyleClasses_StyleClass_Id] FOREIGN KEY([StyleClass_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[Footers] CHECK CONSTRAINT [FK_dbo.Footers_dbo.StyleClasses_StyleClass_Id]
GO
ALTER TABLE [dbo].[Footers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Footers_dbo.Texts_Text_Id] FOREIGN KEY([Text_Id])
REFERENCES [dbo].[Texts] ([Id])
GO
ALTER TABLE [dbo].[Footers] CHECK CONSTRAINT [FK_dbo.Footers_dbo.Texts_Text_Id]
GO
ALTER TABLE [dbo].[FormatStyleClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FormatStyleClasses_dbo.Formats_Format_Id] FOREIGN KEY([Format_Id])
REFERENCES [dbo].[Formats] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FormatStyleClasses] CHECK CONSTRAINT [FK_dbo.FormatStyleClasses_dbo.Formats_Format_Id]
GO
ALTER TABLE [dbo].[FormatStyleClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FormatStyleClasses_dbo.StyleClasses_StyleClass_Id] FOREIGN KEY([StyleClass_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FormatStyleClasses] CHECK CONSTRAINT [FK_dbo.FormatStyleClasses_dbo.StyleClasses_StyleClass_Id]
GO
ALTER TABLE [dbo].[Friendships]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Friendships_dbo.Users_Request_Id] FOREIGN KEY([Request_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Friendships] CHECK CONSTRAINT [FK_dbo.Friendships_dbo.Users_Request_Id]
GO
ALTER TABLE [dbo].[Friendships]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Friendships_dbo.Users_Requested_Id] FOREIGN KEY([Requested_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Friendships] CHECK CONSTRAINT [FK_dbo.Friendships_dbo.Users_Requested_Id]
GO
ALTER TABLE [dbo].[Headers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Headers_dbo.StyleClasses_StyleClass_Id] FOREIGN KEY([StyleClass_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[Headers] CHECK CONSTRAINT [FK_dbo.Headers_dbo.StyleClasses_StyleClass_Id]
GO
ALTER TABLE [dbo].[Headers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Headers_dbo.Texts_Text_Id] FOREIGN KEY([Text_Id])
REFERENCES [dbo].[Texts] ([Id])
GO
ALTER TABLE [dbo].[Headers] CHECK CONSTRAINT [FK_dbo.Headers_dbo.Texts_Text_Id]
GO
ALTER TABLE [dbo].[ModifyDocumentHistories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModifyDocumentHistories_dbo.Documents_Document_Id] FOREIGN KEY([Document_Id])
REFERENCES [dbo].[Documents] ([Id])
GO
ALTER TABLE [dbo].[ModifyDocumentHistories] CHECK CONSTRAINT [FK_dbo.ModifyDocumentHistories_dbo.Documents_Document_Id]
GO
ALTER TABLE [dbo].[ModifyDocumentHistories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModifyDocumentHistories_dbo.Users_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[ModifyDocumentHistories] CHECK CONSTRAINT [FK_dbo.ModifyDocumentHistories_dbo.Users_User_Id]
GO
ALTER TABLE [dbo].[Parragraphs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Parragraphs_dbo.Documents_Document_Id] FOREIGN KEY([Document_Id])
REFERENCES [dbo].[Documents] ([Id])
GO
ALTER TABLE [dbo].[Parragraphs] CHECK CONSTRAINT [FK_dbo.Parragraphs_dbo.Documents_Document_Id]
GO
ALTER TABLE [dbo].[Parragraphs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Parragraphs_dbo.StyleClasses_StyleClass_Id] FOREIGN KEY([StyleClass_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[Parragraphs] CHECK CONSTRAINT [FK_dbo.Parragraphs_dbo.StyleClasses_StyleClass_Id]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reviews_dbo.Documents_Commented_Id] FOREIGN KEY([Commented_Id])
REFERENCES [dbo].[Documents] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_dbo.Reviews_dbo.Documents_Commented_Id]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Reviews_dbo.Users_Commentator_Id] FOREIGN KEY([Commentator_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_dbo.Reviews_dbo.Users_Commentator_Id]
GO
ALTER TABLE [dbo].[StyleAttributes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StyleAttributes_dbo.StyleClasses_Style_Id] FOREIGN KEY([Style_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[StyleAttributes] CHECK CONSTRAINT [FK_dbo.StyleAttributes_dbo.StyleClasses_Style_Id]
GO
ALTER TABLE [dbo].[StyleClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StyleClasses_dbo.StyleClasses_Based_Id] FOREIGN KEY([Based_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[StyleClasses] CHECK CONSTRAINT [FK_dbo.StyleClasses_dbo.StyleClasses_Based_Id]
GO
ALTER TABLE [dbo].[Texts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Texts_dbo.Parragraphs_Parragraph_Id] FOREIGN KEY([Parragraph_Id])
REFERENCES [dbo].[Parragraphs] ([Id])
GO
ALTER TABLE [dbo].[Texts] CHECK CONSTRAINT [FK_dbo.Texts_dbo.Parragraphs_Parragraph_Id]
GO
ALTER TABLE [dbo].[Texts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Texts_dbo.StyleClasses_StyleClass_Id] FOREIGN KEY([StyleClass_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[Texts] CHECK CONSTRAINT [FK_dbo.Texts_dbo.StyleClasses_StyleClass_Id]
GO
