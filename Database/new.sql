USE [master]
GO
/****** Object:  Database [eProject3_RailwayReservation]    Script Date: 18/09/2024 3:11:39 CH ******/
CREATE DATABASE [eProject3_RailwayReservation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eProject3_RailwayReservation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ADMIN\MSSQL\DATA\eProject3_RailwayReservation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'eProject3_RailwayReservation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.ADMIN\MSSQL\DATA\eProject3_RailwayReservation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [eProject3_RailwayReservation] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eProject3_RailwayReservation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eProject3_RailwayReservation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET ARITHABORT OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET RECOVERY FULL 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET  MULTI_USER 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eProject3_RailwayReservation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [eProject3_RailwayReservation] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'eProject3_RailwayReservation', N'ON'
GO
ALTER DATABASE [eProject3_RailwayReservation] SET QUERY_STORE = ON
GO
ALTER DATABASE [eProject3_RailwayReservation] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [eProject3_RailwayReservation]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 18/09/2024 3:11:40 CH ******/
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
/****** Object:  Table [dbo].[Compartments]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compartments](
	[CompartmentID] [int] IDENTITY(1,1) NOT NULL,
	[TrainID] [int] NOT NULL,
	[CompartmentType] [nvarchar](50) NOT NULL,
	[SeatType] [nvarchar](50) NOT NULL,
	[NumberOfSeats] [int] NOT NULL,
 CONSTRAINT [PK_Compartments] PRIMARY KEY CLUSTERED 
(
	[CompartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[PnrNo] [int] NOT NULL,
	[DateOfJourney] [nvarchar](max) NOT NULL,
	[TotalFare] [decimal](18, 2) NOT NULL,
	[AppUserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RouteStations]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteStations](
	[RouteStationID] [int] IDENTITY(1,1) NOT NULL,
	[TrainRouteID] [int] NOT NULL,
	[StationID] [int] NOT NULL,
	[OrderInRoute] [int] NOT NULL,
 CONSTRAINT [PK_RouteStations] PRIMARY KEY CLUSTERED 
(
	[RouteStationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[TrainID] [int] NOT NULL,
	[TrainRouteID] [int] NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[ArrivalTime] [time](7) NOT NULL,
	[DayOfWeek] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[SeatID] [int] IDENTITY(1,1) NOT NULL,
	[CompartmentID] [int] NOT NULL,
	[SeatNumber] [nvarchar](10) NOT NULL,
	[SeatStatus] [nvarchar](20) NOT NULL,
	[Fare] [decimal](18, 2) NOT NULL,
	[ReservationID] [int] NOT NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[SeatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stations]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stations](
	[StationID] [int] IDENTITY(1,1) NOT NULL,
	[StationCode] [nvarchar](10) NOT NULL,
	[StationName] [nvarchar](100) NOT NULL,
	[RailwayDivisionName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Stations] PRIMARY KEY CLUSTERED 
(
	[StationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 18/09/2024 3:11:40 CH ******/
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
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[PnrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainRoutes]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainRoutes](
	[TrainRouteID] [int] IDENTITY(1,1) NOT NULL,
	[TrainRouteName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_TrainRoutes] PRIMARY KEY CLUSTERED 
(
	[TrainRouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trains]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trains](
	[TrainID] [int] IDENTITY(1,1) NOT NULL,
	[TrainName] [nvarchar](100) NOT NULL,
	[TrainStatus] [nvarchar](255) NOT NULL,
	[NumberOfCompartments] [int] NOT NULL,
	[TrainRouteID] [int] NOT NULL,
 CONSTRAINT [PK_Trains] PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trips]    Script Date: 18/09/2024 3:11:40 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trips](
	[TripID] [int] IDENTITY(1,1) NOT NULL,
	[ReservationID] [int] NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[StartStationID] [int] NOT NULL,
	[EndStationID] [int] NOT NULL,
	[DepartureTime] [time](7) NOT NULL,
	[ArrivalTime] [time](7) NOT NULL,
	[TravelTime] [time](7) NOT NULL,
 CONSTRAINT [PK_Trips] PRIMARY KEY CLUSTERED 
(
	[TripID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Compartments_TrainID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Compartments_TrainID] ON [dbo].[Compartments]
(
	[TrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reservations_AppUserId]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_AppUserId] ON [dbo].[Reservations]
(
	[AppUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservations_PnrNo]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Reservations_PnrNo] ON [dbo].[Reservations]
(
	[PnrNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RouteStations_StationID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_RouteStations_StationID] ON [dbo].[RouteStations]
(
	[StationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RouteStations_TrainRouteID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_RouteStations_TrainRouteID] ON [dbo].[RouteStations]
(
	[TrainRouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedules_TrainID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Schedules_TrainID] ON [dbo].[Schedules]
(
	[TrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedules_TrainRouteID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Schedules_TrainRouteID] ON [dbo].[Schedules]
(
	[TrainRouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seats_CompartmentID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Seats_CompartmentID] ON [dbo].[Seats]
(
	[CompartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Seats_ReservationID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Seats_ReservationID] ON [dbo].[Seats]
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trains_TrainRouteID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Trains_TrainRouteID] ON [dbo].[Trains]
(
	[TrainRouteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trips_EndStationID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Trips_EndStationID] ON [dbo].[Trips]
(
	[EndStationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trips_ReservationID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Trips_ReservationID] ON [dbo].[Trips]
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trips_ScheduleID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Trips_ScheduleID] ON [dbo].[Trips]
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Trips_StartStationID]    Script Date: 18/09/2024 3:11:40 CH ******/
CREATE NONCLUSTERED INDEX [IX_Trips_StartStationID] ON [dbo].[Trips]
(
	[StartStationID] ASC
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
ALTER TABLE [dbo].[Compartments]  WITH CHECK ADD  CONSTRAINT [FK_Compartments_Trains_TrainID] FOREIGN KEY([TrainID])
REFERENCES [dbo].[Trains] ([TrainID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compartments] CHECK CONSTRAINT [FK_Compartments_Trains_TrainID]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_AspNetUsers_AppUserId] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_AspNetUsers_AppUserId]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Tickets_PnrNo] FOREIGN KEY([PnrNo])
REFERENCES [dbo].[Tickets] ([PnrNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Tickets_PnrNo]
GO
ALTER TABLE [dbo].[RouteStations]  WITH CHECK ADD  CONSTRAINT [FK_RouteStations_Stations_StationID] FOREIGN KEY([StationID])
REFERENCES [dbo].[Stations] ([StationID])
GO
ALTER TABLE [dbo].[RouteStations] CHECK CONSTRAINT [FK_RouteStations_Stations_StationID]
GO
ALTER TABLE [dbo].[RouteStations]  WITH CHECK ADD  CONSTRAINT [FK_RouteStations_TrainRoutes_TrainRouteID] FOREIGN KEY([TrainRouteID])
REFERENCES [dbo].[TrainRoutes] ([TrainRouteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RouteStations] CHECK CONSTRAINT [FK_RouteStations_TrainRoutes_TrainRouteID]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_TrainRoutes_TrainRouteID] FOREIGN KEY([TrainRouteID])
REFERENCES [dbo].[TrainRoutes] ([TrainRouteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_TrainRoutes_TrainRouteID]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_Trains_TrainID] FOREIGN KEY([TrainID])
REFERENCES [dbo].[Trains] ([TrainID])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_Trains_TrainID]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Compartments_CompartmentID] FOREIGN KEY([CompartmentID])
REFERENCES [dbo].[Compartments] ([CompartmentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Compartments_CompartmentID]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Reservations_ReservationID] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservations] ([ReservationID])
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Reservations_ReservationID]
GO
ALTER TABLE [dbo].[Trains]  WITH CHECK ADD  CONSTRAINT [FK_Trains_TrainRoutes_TrainRouteID] FOREIGN KEY([TrainRouteID])
REFERENCES [dbo].[TrainRoutes] ([TrainRouteID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trains] CHECK CONSTRAINT [FK_Trains_TrainRoutes_TrainRouteID]
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD  CONSTRAINT [FK_Trips_Reservations_ReservationID] FOREIGN KEY([ReservationID])
REFERENCES [dbo].[Reservations] ([ReservationID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trips] CHECK CONSTRAINT [FK_Trips_Reservations_ReservationID]
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD  CONSTRAINT [FK_Trips_Schedules_ScheduleID] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedules] ([ScheduleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trips] CHECK CONSTRAINT [FK_Trips_Schedules_ScheduleID]
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD  CONSTRAINT [FK_Trips_Stations_EndStationID] FOREIGN KEY([EndStationID])
REFERENCES [dbo].[Stations] ([StationID])
GO
ALTER TABLE [dbo].[Trips] CHECK CONSTRAINT [FK_Trips_Stations_EndStationID]
GO
ALTER TABLE [dbo].[Trips]  WITH CHECK ADD  CONSTRAINT [FK_Trips_Stations_StartStationID] FOREIGN KEY([StartStationID])
REFERENCES [dbo].[Stations] ([StationID])
GO
ALTER TABLE [dbo].[Trips] CHECK CONSTRAINT [FK_Trips_Stations_StartStationID]
GO
USE [master]
GO
ALTER DATABASE [eProject3_RailwayReservation] SET  READ_WRITE 
GO
