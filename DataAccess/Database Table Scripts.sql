/**
Maintain DB Changes Here.
**/


/****************
TABLES
*****************/


--Tables to store the budget figures
CREATE TABLE Budget_Estimates
(id int PRIMARY KEY IDENTITY(1,1),
processing_year int NOT NULL,
ministry char(2) NOT NULL,
program char(4) NOT NULL,
subprog char(3) NOT NULL,
account char(7) NOT NULL,
project char(5) NOT NULL,
sof char(3) NOT NULL,
sector char(3) NOT NULL,
lastcode char(4) NOT NULL,
label nvarchar(150),
quantity smallint,
year0_amount int NOT NULL,
year1_amount int NOT NULL,
year2_amount int NOT NULL,
year3_amount int NOT NULL,
is_by_law bit NOT NULL,
comment nvarchar(150),
flagged bit NOT NULL,
flagged_comment nvarchar(150),
modified_by nvarchar(50),
last_modified datetime,
entry_status_id tinyint NOT NULL
);

CREATE TABLE Entry_Status
(
id tinyint PRIMARY KEY,
status_descp nvarchar(50)
);

--Default Values
INSERT INTO Entry_Status
VALUES (0,'Unsubmitted'),(1,'Submitted'),(2,'Approved');
--Foreign Keys
ALTER TABLE Budget_Estimates
   ADD CONSTRAINT Budget_Estimates_Status FOREIGN KEY (entry_status_id)
      REFERENCES Entry_Status (id)
      ON DELETE CASCADE
      ON UPDATE CASCADE
;


--Table for processing year.  Some years might need preconfiguration. eg. name changes merges etc.  Need a way to hide from end users
CREATE TABLE Processing_Year
(year int Primary Key,
ready_for_data_entry bit not null,
year_closed bit not null)

--User Tables

CREATE TABLE Users
(userName nvarchar(50) Primary Key,
userRole nvarchar(50) not null)

CREATE TABLE User_Roles
(
id nvarchar(50) PRIMARY KEY,
roleDescp nvarchar(50)
);

--Default Values
INSERT INTO User_Roles
VALUES ('Administrator','Administrator'),('BudgetStaff','Budget Staff'),('MinistryStaff','Ministry Staff'),('PsipStaff','PSIP Staff');
--Foreign Keys
ALTER TABLE Users
   ADD CONSTRAINT UsersRoles FOREIGN KEY (userRole)
      REFERENCES User_Roles (id)
      ON DELETE CASCADE
      ON UPDATE CASCADE

CREATE TABLE User_Access
(userName nvarchar(50),
subprogram nvarchar(5),
);
ALTER TABLE User_Access
ADD CONSTRAINT [PK_User_Access] PRIMARY KEY CLUSTERED 
(
	[userName] ASC,
	[subprogram] ASC
);

CREATE TYPE [User_Access] AS TABLE(
	[userName] [nvarchar](50) NOT NULL,
	[subprogram] [nvarchar](5) NOT NULL
 )

 CREATE TABLE [dbo].[Notifications](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[subprogram] [nvarchar](5) NULL,
	[message] [nvarchar](30) NULL,
	[message] [nvarchar](500) NOT NULL,
	[expiryDate] [date] NULL,
	[dateEntered] [datetime] NOT NULL,
	[enteredby] [nvarchar](50) NOT NULL,
	[featured] [bit] NOT NULL,
	[dateModified] [datetime] NOT NULL,
	[modifiedBy] [nvarchar](50) NOT NULL
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--Structure Change for when mergers happen
CREATE TABLE [dbo].[Structure_Change](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[proc_year] [int] NOT NULL,
	[ministry] [nvarchar](50) NOT NULL,
	[program] [nvarchar](50) NOT NULL,
	[subprogram] [nvarchar](50) NOT NULL,
	[soc] [nvarchar](50) NULL,
	[account] [nvarchar](50) NULL,
	[to_ministry] [nvarchar](50) NOT NULL,
	[to_program] [nvarchar](50) NOT NULL,
	[to_subprogram] [nvarchar](50) NOT NULL,
	[to_soc] [nvarchar](50) NULL,
	[to_account] [nvarchar](50) NULL,
	[descp] [nvarchar](150) NULL,
 CONSTRAINT [PK_structure_change] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--Report Configuration
CREATE TABLE [dbo].[Report_Config](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[reportId] [varchar](50) NOT NULL,
	[reportDesc] [varchar](50) NOT NULL,
	[parUser] [bit] NOT NULL,
	[parMinistry] [bit] NOT NULL,
	[parProgram] [bit] NOT NULL,
	[parSubprogram] [bit] NOT NULL,
	[parSOC] [bit] NOT NULL,
	[parAccount] [bit] NOT NULL,
 CONSTRAINT [PK_Report_Config] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]