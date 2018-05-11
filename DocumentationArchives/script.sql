USE [master]
GO
/****** Object:  Database [DocumentsManagerDatabase]    Script Date: 5/10/2018 10:53:35 PM ******/
CREATE DATABASE [DocumentsManagerDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DocumentsManagerDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DocumentsManagerDatabase.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DocumentsManagerDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\DocumentsManagerDatabase_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DocumentsManagerDatabase] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DocumentsManagerDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DocumentsManagerDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DocumentsManagerDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DocumentsManagerDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DocumentsManagerDatabase]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 5/10/2018 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[Documents]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[Footers]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[Formats]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[FormatStyleClasses]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[Headers]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[ModifyDocumentHistories]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[Parragraphs]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[StyleAttributes]    Script Date: 5/10/2018 10:53:35 PM ******/
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
/****** Object:  Table [dbo].[StyleClasses]    Script Date: 5/10/2018 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StyleClasses](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[StyleClass_Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_dbo.StyleClasses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Texts]    Script Date: 5/10/2018 10:53:36 PM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 5/10/2018 10:53:36 PM ******/
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
/****** Object:  Index [IX_Footer_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Footer_Id] ON [dbo].[Documents]
(
	[Footer_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Format_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Format_Id] ON [dbo].[Documents]
(
	[Format_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Header_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Header_Id] ON [dbo].[Documents]
(
	[Header_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StyleClass_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_StyleClass_Id] ON [dbo].[Documents]
(
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StyleClass_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_StyleClass_Id] ON [dbo].[Footers]
(
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Text_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Text_Id] ON [dbo].[Footers]
(
	[Text_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Format_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Format_Id] ON [dbo].[FormatStyleClasses]
(
	[Format_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StyleClass_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_StyleClass_Id] ON [dbo].[FormatStyleClasses]
(
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StyleClass_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_StyleClass_Id] ON [dbo].[Headers]
(
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Text_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Text_Id] ON [dbo].[Headers]
(
	[Text_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Document_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Document_Id] ON [dbo].[ModifyDocumentHistories]
(
	[Document_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[ModifyDocumentHistories]
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Document_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Document_Id] ON [dbo].[Parragraphs]
(
	[Document_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StyleClass_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_StyleClass_Id] ON [dbo].[Parragraphs]
(
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Style_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Style_Id] ON [dbo].[StyleAttributes]
(
	[Style_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StyleClass_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_StyleClass_Id] ON [dbo].[StyleClasses]
(
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Parragraph_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Parragraph_Id] ON [dbo].[Texts]
(
	[Parragraph_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_StyleClass_Id]    Script Date: 5/10/2018 10:53:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_StyleClass_Id] ON [dbo].[Texts]
(
	[StyleClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[StyleAttributes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StyleAttributes_dbo.StyleClasses_Style_Id] FOREIGN KEY([Style_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[StyleAttributes] CHECK CONSTRAINT [FK_dbo.StyleAttributes_dbo.StyleClasses_Style_Id]
GO
ALTER TABLE [dbo].[StyleClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StyleClasses_dbo.StyleClasses_StyleClass_Id] FOREIGN KEY([StyleClass_Id])
REFERENCES [dbo].[StyleClasses] ([Id])
GO
ALTER TABLE [dbo].[StyleClasses] CHECK CONSTRAINT [FK_dbo.StyleClasses_dbo.StyleClasses_StyleClass_Id]
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
USE [master]
GO
ALTER DATABASE [DocumentsManagerDatabase] SET  READ_WRITE 
GO
