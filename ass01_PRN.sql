USE [master]
GO
/****** Object:  Database [CandidateManagement_03]    Script Date: 2/25/2024 8:42:45 PM ******/
CREATE DATABASE [CandidateManagement_03]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CandidateManagement_03', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\CandidateManagement_03.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CandidateManagement_03_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\CandidateManagement_03_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CandidateManagement_03] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CandidateManagement_03].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CandidateManagement_03] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET ARITHABORT OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CandidateManagement_03] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CandidateManagement_03] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CandidateManagement_03] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CandidateManagement_03] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET RECOVERY FULL 
GO
ALTER DATABASE [CandidateManagement_03] SET  MULTI_USER 
GO
ALTER DATABASE [CandidateManagement_03] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CandidateManagement_03] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CandidateManagement_03] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CandidateManagement_03] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CandidateManagement_03] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CandidateManagement_03] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CandidateManagement_03', N'ON'
GO
ALTER DATABASE [CandidateManagement_03] SET QUERY_STORE = ON
GO
ALTER DATABASE [CandidateManagement_03] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CandidateManagement_03]
GO
/****** Object:  Table [dbo].[CandidateProfile]    Script Date: 2/25/2024 8:42:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CandidateProfile](
	[CandidateID] [nvarchar](20) NOT NULL,
	[Fullname] [nvarchar](100) NOT NULL,
	[Birthday] [datetime] NULL,
	[ProfileShortDescription] [nvarchar](250) NULL,
	[ProfileURL] [nvarchar](150) NULL,
	[PostingID] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CandidateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HRAccount]    Script Date: 2/25/2024 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HRAccount](
	[Email] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](40) NULL,
	[FullName] [nvarchar](30) NULL,
	[MemberRole] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InterviewSchedule]    Script Date: 2/25/2024 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InterviewSchedule](
	[InterviewID] [nvarchar](20) NOT NULL,
	[CandidateID] [nvarchar](20) NULL,
	[InterviewDate] [datetime] NULL,
	[InterviewLocation] [nvarchar](100) NULL,
	[Interviewer] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[InterviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPosting]    Script Date: 2/25/2024 8:42:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPosting](
	[PostingID] [nvarchar](20) NOT NULL,
	[JobPostingTitle] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[PostedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PostingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CandidateProfile] ([CandidateID], [Fullname], [Birthday], [ProfileShortDescription], [ProfileURL], [PostingID]) VALUES (N'C01', N'Nguyen Van A', CAST(N'2000-12-02T00:00:00.000' AS DateTime), N'BE developer', NULL, N'P01')
INSERT [dbo].[CandidateProfile] ([CandidateID], [Fullname], [Birthday], [ProfileShortDescription], [ProfileURL], [PostingID]) VALUES (N'C02', N'Nguyen Van B', CAST(N'2001-12-02T00:00:00.000' AS DateTime), N'BE developer', NULL, N'P01')
INSERT [dbo].[CandidateProfile] ([CandidateID], [Fullname], [Birthday], [ProfileShortDescription], [ProfileURL], [PostingID]) VALUES (N'C03', N'Vo Thi C', CAST(N'2000-02-06T00:00:00.000' AS DateTime), N'FE developer', NULL, N'P02')
INSERT [dbo].[CandidateProfile] ([CandidateID], [Fullname], [Birthday], [ProfileShortDescription], [ProfileURL], [PostingID]) VALUES (N'C04', N'Le Van Dung', CAST(N'2001-03-08T00:00:00.000' AS DateTime), N'Full Stack developer', NULL, N'P03')
GO
INSERT [dbo].[HRAccount] ([Email], [Password], [FullName], [MemberRole]) VALUES (N'admin@gmail.com', N'12345', N'Admin', 1)
INSERT [dbo].[HRAccount] ([Email], [Password], [FullName], [MemberRole]) VALUES (N'staff@gmail.com', N'12345', N'staff', 2)
INSERT [dbo].[HRAccount] ([Email], [Password], [FullName], [MemberRole]) VALUES (N'user@gmail.com', N'12345', N'user', 3)
GO
INSERT [dbo].[InterviewSchedule] ([InterviewID], [CandidateID], [InterviewDate], [InterviewLocation], [Interviewer]) VALUES (N'IT01', N'C01', CAST(N'2024-10-10T00:00:00.000' AS DateTime), N'Office ', N'HR manager')
INSERT [dbo].[InterviewSchedule] ([InterviewID], [CandidateID], [InterviewDate], [InterviewLocation], [Interviewer]) VALUES (N'IT02', N'C02', CAST(N'2024-01-01T00:00:00.000' AS DateTime), N'Online', N'HR manager')
INSERT [dbo].[InterviewSchedule] ([InterviewID], [CandidateID], [InterviewDate], [InterviewLocation], [Interviewer]) VALUES (N'IT03', N'C03', CAST(N'2024-02-10T00:00:00.000' AS DateTime), N'Online', N'HR manager')
INSERT [dbo].[InterviewSchedule] ([InterviewID], [CandidateID], [InterviewDate], [InterviewLocation], [Interviewer]) VALUES (N'IT04', N'C04', CAST(N'2024-02-24T00:00:00.000' AS DateTime), N'Office', N'HR manager')
GO
INSERT [dbo].[JobPosting] ([PostingID], [JobPostingTitle], [Description], [PostedDate]) VALUES (N'P01', N'BE developer', N'.Net, SQL, mongoDB, java', CAST(N'2023-12-05T00:00:00.000' AS DateTime))
INSERT [dbo].[JobPosting] ([PostingID], [JobPostingTitle], [Description], [PostedDate]) VALUES (N'P02', N'FE developer', N'React, Vue, javascript', CAST(N'2023-12-05T00:00:00.000' AS DateTime))
INSERT [dbo].[JobPosting] ([PostingID], [JobPostingTitle], [Description], [PostedDate]) VALUES (N'P03', N'Full Stack developer', N'.Net, React, Javascript, Taiwind', CAST(N'2023-06-05T00:00:00.000' AS DateTime))
GO
ALTER TABLE [dbo].[CandidateProfile]  WITH CHECK ADD FOREIGN KEY([PostingID])
REFERENCES [dbo].[JobPosting] ([PostingID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InterviewSchedule]  WITH CHECK ADD FOREIGN KEY([CandidateID])
REFERENCES [dbo].[CandidateProfile] ([CandidateID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [CandidateManagement_03] SET  READ_WRITE 
GO
