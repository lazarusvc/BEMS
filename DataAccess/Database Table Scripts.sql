/**
Maintain DB Changes Here.
**/
--Tables for Data Entry

--Starting Table needed for incase ministries merge or change.  This way history is preserved
CREATE TABLE Starting_Estimates
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
quantity smallint,
amount int NOT NULL,
is_by_law bit NOT NULL,
comment nvarchar(150),
sort_position tinyint,
entered_by nvarchar(50),
date_entered datetime,
modified_by datetime,
last_modified nvarchar(50)
);


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
quantity smallint,
year1_amount int NOT NULL,
year2_amount int NOT NULL,
year3_amount int NOT NULL,
is_by_law bit NOT NULL,
comment nvarchar(150),
sort_position tinyint,
version_no tinyint NOT NULL,
is_current bit NOT NULL,
flagged bit NOT NULL,
flagged_comment nvarchar(150),
entered_by nvarchar(50),
date_entered datetime,
modified_by datetime,
last_modified nvarchar(50)
);