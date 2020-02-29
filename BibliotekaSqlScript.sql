USE [master]
GO
/****** Object:  Database [Biblioteka]    Script Date: 28.2.2020. 18:42:19 ******/
CREATE DATABASE [Biblioteka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Biblioteka', FILENAME = N'd:\ProgramerskaSekcija\db\Biblioteka.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Biblioteka_log', FILENAME = N'd:\ProgramerskaSekcija\db\Biblioteka_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Biblioteka] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteka].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Biblioteka] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Biblioteka] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Biblioteka] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Biblioteka] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Biblioteka] SET ARITHABORT OFF 
GO
ALTER DATABASE [Biblioteka] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Biblioteka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Biblioteka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Biblioteka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Biblioteka] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Biblioteka] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Biblioteka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Biblioteka] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Biblioteka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Biblioteka] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Biblioteka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Biblioteka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Biblioteka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Biblioteka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Biblioteka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Biblioteka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Biblioteka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Biblioteka] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Biblioteka] SET  MULTI_USER 
GO
ALTER DATABASE [Biblioteka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Biblioteka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Biblioteka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Biblioteka] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Biblioteka] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Biblioteka] SET QUERY_STORE = OFF
GO
USE [Biblioteka]
GO
/****** Object:  Table [dbo].[Knjiga]    Script Date: 28.2.2020. 18:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Knjiga](
	[KnjigaId] [int] IDENTITY(1,1) NOT NULL,
	[InventarniBroj] [nvarchar](30) NOT NULL,
	[Pisac] [nvarchar](70) NOT NULL,
	[Naslov] [nvarchar](500) NOT NULL,
	[GodinaIzdavanja] [int] NULL,
	[MestoIzdavanja] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[KnjigaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ucenik]    Script Date: 28.2.2020. 18:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ucenik](
	[UcenikId] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](15) NOT NULL,
	[Prezime] [nvarchar](15) NOT NULL,
	[GodinaRodjenja] [int] NULL,
	[BrojUDnevniku] [int] NULL,
	[Razred] [nvarchar](6) NULL,
	[Odeljenje] [nvarchar](3) NULL,
	[Adresa] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Telefon] [nvarchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UcenikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Knjiga] ON 
GO
INSERT [dbo].[Knjiga] ([KnjigaId], [InventarniBroj], [Pisac], [Naslov], [GodinaIzdavanja], [MestoIzdavanja]) VALUES (1, N'852', N'Žil Vern', N'Put oko sveta za 80 dana', 1900, N'London')
GO
INSERT [dbo].[Knjiga] ([KnjigaId], [InventarniBroj], [Pisac], [Naslov], [GodinaIzdavanja], [MestoIzdavanja]) VALUES (2, N'853', N'Stevan Sremac', N'Pop Ćira i pop Spira', 1901, N'Novi Sad')
GO
INSERT [dbo].[Knjiga] ([KnjigaId], [InventarniBroj], [Pisac], [Naslov], [GodinaIzdavanja], [MestoIzdavanja]) VALUES (3, N'854', N'Branko Ćopić', N'Orlovi rano lete', 1980, N'Beograd')
GO
INSERT [dbo].[Knjiga] ([KnjigaId], [InventarniBroj], [Pisac], [Naslov], [GodinaIzdavanja], [MestoIzdavanja]) VALUES (4, N'855', N'Den Braun', N'Da Vinčijev kod', 2005, N'Njujork')
GO
SET IDENTITY_INSERT [dbo].[Knjiga] OFF
GO
SET IDENTITY_INSERT [dbo].[Ucenik] ON 
GO
INSERT [dbo].[Ucenik] ([UcenikId], [Ime], [Prezime], [GodinaRodjenja], [BrojUDnevniku], [Razred], [Odeljenje], [Adresa], [Email], [Telefon]) VALUES (1, N'Đorđe', N'Cvetković', NULL, NULL, NULL, NULL, N'Braće Bošnjak 2a', N'blabla@truc.com', N'+381612345')
GO
INSERT [dbo].[Ucenik] ([UcenikId], [Ime], [Prezime], [GodinaRodjenja], [BrojUDnevniku], [Razred], [Odeljenje], [Adresa], [Email], [Telefon]) VALUES (2, N'Mladen', N'Cvetković', 2006, 24, N'VII-2', NULL, N'Braće Bošnjak 2a', N'truc.truc@gmail.com', N'+38161')
GO
SET IDENTITY_INSERT [dbo].[Ucenik] OFF
GO
USE [master]
GO
ALTER DATABASE [Biblioteka] SET  READ_WRITE 
GO
