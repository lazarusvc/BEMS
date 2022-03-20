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
userRole tinyint not null)

CREATE TABLE User_Roles
(
id tinyint PRIMARY KEY,
status_descp nvarchar(50)
);

--Default Values
INSERT INTO User_Roles
VALUES (0,'Admin'),(1,'Budget Staff'),(2,'Ministry Staff');
--Foreign Keys
ALTER TABLE Users
   ADD CONSTRAINT UsersRoles FOREIGN KEY (userRole)
      REFERENCES User_Roles (id)
      ON DELETE CASCADE
      ON UPDATE CASCADE

CREATE TABLE User_Access
(id int PRIMARY KEY IDENTITY(1,1),
userName nvarchar(50),
subprogram nvarchar(5)
);