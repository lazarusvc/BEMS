USE [master]
GO
/****** Object:  Database [GOCDBudget_NW]    Script Date: 9/18/2023 2:35:47 PM ******/
CREATE DATABASE [GOCDBudget_NW] ON  PRIMARY 
( NAME = N'GOCDBudget_NW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GOCDBudget_NW.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GOCDBudget_NW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GOCDBudget_NW_log.ldf' , SIZE = 10240KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GOCDBudget_NW] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GOCDBudget_NW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GOCDBudget_NW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET ARITHABORT OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GOCDBudget_NW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GOCDBudget_NW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GOCDBudget_NW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GOCDBudget_NW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GOCDBudget_NW] SET RECOVERY FULL 
GO
ALTER DATABASE [GOCDBudget_NW] SET  MULTI_USER 
GO
ALTER DATABASE [GOCDBudget_NW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GOCDBudget_NW] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GOCDBudget_NW', N'ON'
GO
USE [GOCDBudget_NW]
GO
/****** Object:  Table [dbo].[Budget_Estimates]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Budget_Estimates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[processing_year] [int] NOT NULL,
	[ministry] [char](2) NOT NULL,
	[program] [char](4) NOT NULL,
	[subprog] [char](3) NOT NULL,
	[account] [char](7) NOT NULL,
	[project] [char](5) NOT NULL,
	[sof] [char](3) NOT NULL,
	[sector] [char](3) NOT NULL,
	[lastcode] [char](4) NOT NULL,
	[label] [nvarchar](150) NULL,
	[quantity] [smallint] NULL,
	[year0_amount] [int] NOT NULL,
	[year1_amount] [int] NOT NULL,
	[year2_amount] [int] NOT NULL,
	[year3_amount] [int] NOT NULL,
	[is_by_law] [bit] NOT NULL,
	[comment] [nvarchar](150) NULL,
	[flagged] [bit] NOT NULL,
	[flagged_comment] [nvarchar](150) NULL,
	[modified_by] [nvarchar](50) NULL,
	[last_modified] [datetime] NULL,
	[entry_status_id] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Capital_Budget]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capital_Budget](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ldr_entity_id] [nvarchar](1) NULL,
	[ministry] [nvarchar](2) NULL,
	[program] [nvarchar](4) NULL,
	[subprog] [nvarchar](3) NULL,
	[account] [nvarchar](7) NULL,
	[project] [nvarchar](5) NULL,
	[sof] [nvarchar](3) NULL,
	[sector] [nvarchar](3) NULL,
	[lastcode] [nvarchar](4) NULL,
	[curr_code] [nvarchar](3) NULL,
	[Name] [nvarchar](max) NULL,
	[Name2] [nvarchar](max) NULL,
	[ldr_amt_0] [float] NULL,
	[ldr_amt_1] [float] NULL,
	[Expr1000] [int] NULL,
	[Expr1001] [int] NULL,
	[Expr1002] [int] NULL,
	[Expr1003] [int] NULL,
	[Expr1004] [int] NULL,
	[Expr1005] [int] NULL,
	[Expr1006] [int] NULL,
	[Expr1007] [int] NULL,
	[Expr1008] [int] NULL,
	[Expr1009] [int] NULL,
	[Expr1010] [int] NULL,
	[Expr1011] [int] NULL,
	[Expr1012] [int] NULL,
	[Expr1013] [int] NULL,
	[processing_year] [int] NULL,
 CONSTRAINT [PK_Capital_Budget] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Capital_Ledger]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capital_Ledger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[account] [nvarchar](max) NOT NULL,
	[acct_type_code] [nvarchar](max) NULL,
	[acct_descp_1] [nvarchar](max) NULL,
	[acct_descp_2] [nvarchar](max) NULL,
	[open_date] [datetime] NULL,
	[Capital_Budget_EstimatesId] [int] NOT NULL,
 CONSTRAINT [PK_Capital_Ledger] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry_Status]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry_Status](
	[id] [tinyint] NOT NULL,
	[status_descp] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Processing_Year]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Processing_Year](
	[year] [int] NOT NULL,
	[ready_for_data_entry] [bit] NOT NULL,
	[year_closed] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Access]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Access](
	[userName] [nvarchar](50) NULL,
	[subprogram] [nvarchar](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Roles]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Roles](
	[id] [nvarchar](50) NOT NULL,
	[roleDescp] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userName] [nvarchar](50) NOT NULL,
	[userRole] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_ss_account_name]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ss_account_name]
AS
SELECT        NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM            GOCDSSP.DBSosst.dbo.SRG_POINT AS SRG_POINT_1
WHERE        (STRUCTURE_ID = 4) AND (GROUP_ID = 4) AND (ENABLED = 1) AND (TYPE IN ('F', 'D'))
GO
/****** Object:  View [dbo].[vw_ss_ledger_accounts]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_ss_ledger_accounts] as
SELECT [ldr_entity_id] COLLATE SQL_Latin1_General_CP1_CI_AS as ldr_entity_id
      ,[ministry] COLLATE SQL_Latin1_General_CP1_CI_AS as ministry
      ,[program] COLLATE SQL_Latin1_General_CP1_CI_AS as program
      ,[subprog] COLLATE SQL_Latin1_General_CP1_CI_AS as subprog
      ,[account] COLLATE SQL_Latin1_General_CP1_CI_AS as account
      ,[project] COLLATE SQL_Latin1_General_CP1_CI_AS as project
      ,[sof] COLLATE SQL_Latin1_General_CP1_CI_AS as sof
      ,[sector] COLLATE SQL_Latin1_General_CP1_CI_AS as sector
  FROM GOCDSSP.DBSglep.[dbo].[ldr_acct]
  WHERE acct_type_code='E'
  AND close_date>GETDATE();
GO
/****** Object:  View [dbo].[vw_ss_ministry_name]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ss_ministry_name]
AS
SELECT        NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM            GOCDSSP.DBSosst.dbo.SRG_POINT AS SRG_POINT_1
WHERE        (STRUCTURE_ID = 36) AND (GROUP_ID = 4) AND (TYPE = 'D') AND (ENABLED = 1)
GO
/****** Object:  View [dbo].[vw_ss_program_name]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ss_program_name]
AS
SELECT        NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM            GOCDSSP.DBSosst.dbo.SRG_POINT AS SRG_POINT_1
WHERE        (STRUCTURE_ID = 37) AND (GROUP_ID = 4) AND (TYPE = 'D') AND (ENABLED = 1)
GO
/****** Object:  View [dbo].[vw_ss_project_name]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ss_project_name]
AS
SELECT        NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM            GOCDSSP.DBSosst.dbo.SRG_POINT AS SRG_POINT_1
WHERE        (STRUCTURE_ID = 10) AND (GROUP_ID = 4) AND (TYPE = 'D') AND (ENABLED = 1) AND (NAME <> '')
GO
/****** Object:  View [dbo].[vw_ss_sector_name]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ss_sector_name]
AS
SELECT        NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM            GOCDSSP.DBSosst.dbo.SRG_POINT AS SRG_POINT_1
WHERE        (STRUCTURE_ID = 7) AND (GROUP_ID = 4) AND (TYPE = 'D') AND (ENABLED = 1) AND (NAME <> '')
GO
/****** Object:  View [dbo].[vw_ss_sof_name]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ss_sof_name]
AS
SELECT        NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM            GOCDSSP.DBSosst.dbo.SRG_POINT AS SRG_POINT_1
WHERE        (STRUCTURE_ID = 6) AND (GROUP_ID = 4) AND (TYPE = 'D') AND (ENABLED = 1) AND (NAME <> '')
GO
/****** Object:  View [dbo].[vw_ss_subprog_name]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ss_subprog_name]
AS
SELECT        NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM            GOCDSSP.DBSosst.dbo.SRG_POINT AS SRG_POINT_1
WHERE        (STRUCTURE_ID = 38) AND (GROUP_ID = 4) AND (TYPE = 'D') AND (ENABLED = 1)
GO
/****** Object:  View [dbo].[vw_subprogram_approved]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_subprogram_approved] as
SELECT DISTINCT 
      [processing_year]
      ,[ministry]
      ,[program]
      ,[subprog]     
  FROM [Budget_Estimates]  
 WHERE entry_status_id=2;
GO
/****** Object:  View [dbo].[vw_subprogram_sub_apv]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_subprogram_sub_apv]
AS
SELECT  processing_year, subprog, ministry, program, max(entry_status_id) as status
FROM            dbo.Budget_Estimates
WHERE        entry_status_id in (1,2)
GROUP BY processing_year, subprog, ministry, program
GO
/****** Object:  View [dbo].[vw_subprogram_submitted]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_subprogram_submitted] as
SELECT DISTINCT 
      [processing_year]
      ,[ministry]
      ,[program]
      ,[subprog]     
  FROM [Budget_Estimates]
WHERE entry_status_id=1;
GO
/****** Object:  View [dbo].[vw_user_access]    Script Date: 9/18/2023 2:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
CREATE VIEW [dbo].[vw_user_access] as
SELECT DISTINCT dbo.User_Access.userName, dbo.Budget_Estimates.ministry, dbo.Budget_Estimates.program, dbo.Budget_Estimates.subprog, dbo.Users.userRole
FROM            dbo.Budget_Estimates INNER JOIN
                         dbo.User_Access ON dbo.Budget_Estimates.subprog = dbo.User_Access.subprogram INNER JOIN
                         dbo.Users ON dbo.User_Access.userName = dbo.Users.userName
GO
/****** Object:  Index [IX_FK_Capital_Budget_EstimatesCapital_Ledger]    Script Date: 9/18/2023 2:35:47 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Capital_Budget_EstimatesCapital_Ledger] ON [dbo].[Capital_Ledger]
(
	[Capital_Budget_EstimatesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Budget_Estimates]  WITH CHECK ADD  CONSTRAINT [Budget_Estimates_Status] FOREIGN KEY([entry_status_id])
REFERENCES [dbo].[Entry_Status] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Budget_Estimates] CHECK CONSTRAINT [Budget_Estimates_Status]
GO
ALTER TABLE [dbo].[Capital_Ledger]  WITH CHECK ADD  CONSTRAINT [FK_Capital_Budget_EstimatesCapital_Ledger] FOREIGN KEY([Capital_Budget_EstimatesId])
REFERENCES [dbo].[Capital_Budget] ([Id])
GO
ALTER TABLE [dbo].[Capital_Ledger] CHECK CONSTRAINT [FK_Capital_Budget_EstimatesCapital_Ledger]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [UsersRoles] FOREIGN KEY([userRole])
REFERENCES [dbo].[User_Roles] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [UsersRoles]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SRG_POINT_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 309
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 3045
         Width = 5460
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 5295
         Alias = 3135
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_account_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_account_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SRG_POINT_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1935
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_ministry_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_ministry_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SRG_POINT_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 3210
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 5160
         Alias = 1860
         Table = 2595
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_program_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_program_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SRG_POINT_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 3900
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_project_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_project_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SRG_POINT_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_sector_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_sector_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SRG_POINT_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_sof_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_sof_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SRG_POINT_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 2430
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_subprog_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ss_subprog_name'
GO
USE [master]
GO
ALTER DATABASE [GOCDBudget_NW] SET  READ_WRITE 
GO
