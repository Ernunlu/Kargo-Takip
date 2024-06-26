USE [master]
GO
/****** Object:  Database [Kargotakipsistemi]    Script Date: 7.05.2018 23:18:32 ******/
CREATE DATABASE [Kargotakipsistemi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Kargotakipsistemi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SERVER\MSSQL\DATA\Kargotakipsistemi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Kargotakipsistemi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SERVER\MSSQL\DATA\Kargotakipsistemi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Kargotakipsistemi] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kargotakipsistemi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kargotakipsistemi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Kargotakipsistemi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Kargotakipsistemi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Kargotakipsistemi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Kargotakipsistemi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET RECOVERY FULL 
GO
ALTER DATABASE [Kargotakipsistemi] SET  MULTI_USER 
GO
ALTER DATABASE [Kargotakipsistemi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Kargotakipsistemi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Kargotakipsistemi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Kargotakipsistemi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Kargotakipsistemi] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Kargotakipsistemi', N'ON'
GO
ALTER DATABASE [Kargotakipsistemi] SET QUERY_STORE = OFF
GO
USE [Kargotakipsistemi]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Kargotakipsistemi]
GO
/****** Object:  Table [dbo].[kargo]    Script Date: 7.05.2018 23:18:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kargo](
	[KargoNo] [nvarchar](50) NULL,
	[Gadsoyad] [nvarchar](50) NULL,
	[Gadres] [nvarchar](100) NULL,
	[Gtel] [nvarchar](50) NULL,
	[Aadsoyad] [nvarchar](50) NULL,
	[Aadres] [nvarchar](100) NULL,
	[Atel] [nvarchar](50) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[kargo] ([KargoNo], [Gadsoyad], [Gadres], [Gtel], [Aadsoyad], [Aadres], [Atel]) VALUES (N'312123', N'asdasd', N'aaaaaa', N'05318845949', N'dddd', N'ccccccccccccc', N'05318845949')
INSERT [dbo].[kargo] ([KargoNo], [Gadsoyad], [Gadres], [Gtel], [Aadsoyad], [Aadres], [Atel]) VALUES (N'2132', N'asdasd', N'rrrr', N'05318845949', N'dddd', N'aaaaaaaaaaaaaaaaa', N'05318845949')
INSERT [dbo].[kargo] ([KargoNo], [Gadsoyad], [Gadres], [Gtel], [Aadsoyad], [Aadres], [Atel]) VALUES (N'44112', N'fvsv', N'tttt', N'05318845949', N'vfvsv', N'rrrr', N'05318845949')
USE [master]
GO
ALTER DATABASE [Kargotakipsistemi] SET  READ_WRITE 
GO
