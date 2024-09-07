USE [master]
GO
/****** Object:  Database [eProject_RailwayReservation_Online_DB]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE DATABASE [eProject_RailwayReservation_Online_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eProject_RailwayReservation_Online_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ADMIN\MSSQL\DATA\eProject_RailwayReservation_Online_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eProject_RailwayReservation_Online_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ADMIN\MSSQL\DATA\eProject_RailwayReservation_Online_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eProject_RailwayReservation_Online_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET RECOVERY FULL 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET  MULTI_USER 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'eProject_RailwayReservation_Online_DB', N'ON'
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [eProject_RailwayReservation_Online_DB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fares]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fares](
	[FareID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NOT NULL,
	[Distance] [int] NOT NULL,
	[CompartmentType] [nvarchar](max) NOT NULL,
	[TrainType] [nvarchar](max) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Fares] PRIMARY KEY CLUSTERED 
(
	[FareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[PnrNo] [int] NOT NULL,
	[UserID] [nvarchar](450) NULL,
	[TrainNo] [int] NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[FromStationID] [int] NOT NULL,
	[ToStationID] [int] NOT NULL,
	[SeatNo] [nvarchar](max) NOT NULL,
	[DateOfJourney] [datetime2](7) NOT NULL,
	[CoachNo] [nvarchar](max) NOT NULL,
	[Fare] [decimal](18, 2) NOT NULL,
	[CancellationStatus] [nvarchar](max) NOT NULL,
	[ScheduleID1] [int] NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[TrainNo] [int] NOT NULL,
	[StartStationID] [int] NOT NULL,
	[EndStationID] [int] NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[ArrivalTime] [time](7) NOT NULL,
	[DayOfWeek] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stations]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stations](
	[StationID] [int] IDENTITY(1,1) NOT NULL,
	[StationCode] [nvarchar](max) NOT NULL,
	[StationName] [nvarchar](max) NOT NULL,
	[RailwayDivisionName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Stations] PRIMARY KEY CLUSTERED 
(
	[StationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[PnrNo] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [nvarchar](1) NOT NULL,
	[TotalPassengers] [int] NOT NULL,
	[ReservationID] [int] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[PnrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trains]    Script Date: 05/09/2024 8:33:59 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trains](
	[TrainID] [int] IDENTITY(1,1) NOT NULL,
	[TrainName] [nvarchar](max) NOT NULL,
	[Route] [nvarchar](max) NOT NULL,
	[NumberOfCompartments] [int] NOT NULL,
 CONSTRAINT [PK_Trains] PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240829165321_UpdateRelationships', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240830085218_initâ', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240830112629_DeletePassengerTable', N'8.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240831060922_Initiall', N'8.0.8')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'100a50ec-945e-454b-b39b-09912603f822', N'TransactionStaff', N'TRANSACTIONSTAFF', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c7bb04c0-891f-4bfd-b296-6966a7cff24c', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fb22492b-8ef8-41bd-90a0-f8812e8ba33d', N'MasterManagement', N'MASTERMANAGEMENT', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'93cd748d-5819-4602-a2e5-05a2eee58351', N'100a50ec-945e-454b-b39b-09912603f822')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6557ee48-ccd4-4868-9cef-6bf6a071a3b2', N'c7bb04c0-891f-4bfd-b296-6966a7cff24c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a5766493-4e4e-443c-b4ab-48525ab81973', N'fb22492b-8ef8-41bd-90a0-f8812e8ba33d')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1a5e6d8f-85f1-40a3-9b8b-460b6f343d82', N'DucQuyyy', N'ducquy@gmail.com', N'DUCQUY@GMAIL.COM', N'ducquy@gmail.com', N'DUCQUY@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEB+ZYhXMIFaX/qnAVOXrThfQOkqSlAHMPK122tdMAD1ws1LcsQYpne7ifJHndM7xQw==', N'ae581bba-bf7b-47da-87e3-535fb4757847', N'88c7c777-74fb-4159-9b7c-64a90b4c514c', N'0945132002', 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1f1c8d1a-16ed-4d91-a5b2-447218d46644', N'ADMIN3', N'admin3@gmail.com', NULL, N'admin3@gmail.com', NULL, 0, N'ADmin@123', N'da6688e3-10fd-4702-8943-a2a31b34a39f', N'3c2db902-4639-4e85-9437-e532d318447a', N'0945132002', 0, 0, NULL, 0, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6557ee48-ccd4-4868-9cef-6bf6a071a3b2', N'ADMIN', N'admin123@gmail.com', N'ADMIN123@GMAIL.COM', N'admin123@gmail.com', N'ADMIN123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELcfA+Bnp1Y0UnzbImAzZ3eJ6mHwE9gDB/eLNwhwUquhwLe1Gw1+SglVG3alYlE/aA==', N'FNYADZVWCL3CMMUBQVCAXBKOKOZGVELR', N'0251cba6-6ff2-47cf-81fe-eb43865d6edf', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'93cd748d-5819-4602-a2e5-05a2eee58351', N'STAFF', N'staff123@gmail.com', N'STAFF123@GMAIL.COM', N'staff123@gmail.com', N'STAFF123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAED036b+bNMwwDhlgzauzug98TwhLs1bM8oPUaCZGQT0z4ngKAdZXbLXH9mkx9szwAg==', N'UFRASO7LSPU6ZH2LF7TQWNCGD75NLEQI', N'90eabeee-0293-4545-9711-78b7b36f390c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a5766493-4e4e-443c-b4ab-48525ab81973', N'MASTER', N'master123@gmail.com', N'MASTER123@GMAIL.COM', N'master123@gmail.com', N'MASTER123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFQs6TRcLdm9Zepta4Wb9f5FqbYRy8i4kMPOP8prWi+l1EAd7cBDSR8XoIi8mDJ7AA==', N'SBNZVPZCSRM32NDE35E24L6BX2MCDN6M', N'1c32f90c-2236-44b0-9e6d-69e25f2b8b73', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bbf2f14a-26c9-4161-871f-3f66247a6bd9', N'staff', NULL, NULL, N'staff@gmail.com', NULL, 0, N'Staff@123', N'96052a8f-c94d-4338-9a6e-f81802904a63', N'abed313a-6128-48ae-bb7b-9f2b20a5c61e', N'0945132002', 0, 0, NULL, 0, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Fares_ReservationID]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Fares_ReservationID] ON [dbo].[Fares]
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_FromStationID]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_FromStationID] ON [dbo].[Reservations]
(
	[FromStationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_ScheduleID]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_ScheduleID] ON [dbo].[Reservations]
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_ScheduleID1]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_ScheduleID1] ON [dbo].[Reservations]
(
	[ScheduleID1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_ToStationID]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_ToStationID] ON [dbo].[Reservations]
(
	[ToStationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_TrainNo]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_TrainNo] ON [dbo].[Reservations]
(
	[TrainNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reservations_UserID]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_UserID] ON [dbo].[Reservations]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedules_TrainNo]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Schedules_TrainNo] ON [dbo].[Schedules]
(
	[TrainNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_ReservationID]    Script Date: 05/09/2024 8:33:59 CH ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_ReservationID] ON [dbo].[Tickets]
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Fares]  WITH CHECK ADD  CONSTRAINT [FK_Fares_Reservations_ReservationID] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservations] ([ReservationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Fares] CHECK CONSTRAINT [FK_Fares_Reservations_ReservationID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_AspNetUsers_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_AspNetUsers_UserID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Schedules_ScheduleID] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedules] ([ScheduleID])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Schedules_ScheduleID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Schedules_ScheduleID1] FOREIGN KEY([ScheduleID1])
REFERENCES [dbo].[Schedules] ([ScheduleID])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Schedules_ScheduleID1]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Stations_FromStationID] FOREIGN KEY([FromStationID])
REFERENCES [dbo].[Stations] ([StationID])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Stations_FromStationID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Stations_ToStationID] FOREIGN KEY([ToStationID])
REFERENCES [dbo].[Stations] ([StationID])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Stations_ToStationID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Trains_TrainNo] FOREIGN KEY([TrainNo])
REFERENCES [dbo].[Trains] ([TrainID])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Trains_TrainNo]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Trains_TrainNo] FOREIGN KEY([TrainNo])
REFERENCES [dbo].[Trains] ([TrainID])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Trains_TrainNo]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Reservations_ReservationID] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservations] ([ReservationID])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Reservations_ReservationID]
GO
USE [master]
GO
ALTER DATABASE [eProject_RailwayReservation_Online_DB] SET  READ_WRITE 
GO

