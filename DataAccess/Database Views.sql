/****************
VIEWS
*****************/

create  view vw_ss_ministry_name as
  SELECT   NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
  FROM [GOCDSSP].[DBSosst].[dbo].[SRG_POINT]
  where [STRUCTURE_ID]=36
  and [GROUP_ID]=4
  and [TYPE]='D'
  and ENABLED=1;

create  view vw_ss_program_name as
SELECT NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
FROM [GOCDSSP].[DBSosst].[dbo].[SRG_POINT]
where [STRUCTURE_ID]=37
and [GROUP_ID]=4
and [TYPE]='D'
and ENABLED=1;

create view vw_ss_subprog_name as
SELECT NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
  FROM [GOCDSSP].[DBSosst].[dbo].[SRG_POINT]
  where [STRUCTURE_ID]=38
  and [GROUP_ID]=4
  and [TYPE]='D'
  and ENABLED=1;


create view vw_ss_account_name as
SELECT NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
  FROM [GOCDSSP].[DBSosst].[dbo].[SRG_POINT]
  where [STRUCTURE_ID]=4
  and [GROUP_ID]=4
  and ENABLED=1 AND (TYPE IN ('F', 'D'));


create  view vw_ss_project_name as
  SELECT NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
  FROM [GOCDSSP].[DBSosst].[dbo].[SRG_POINT]
  where [STRUCTURE_ID]=10
  and [GROUP_ID]=4
  and [TYPE]='D'
  and ENABLED=1
  and NAME <>'';


Create view vw_ss_sof_name as
SELECT NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
  FROM [GOCDSSP].[DBSosst].[dbo].[SRG_POINT]
  where [STRUCTURE_ID]=6
  and [GROUP_ID]=4
  and [TYPE]='D'
  and ENABLED=1
  and NAME <>'';


  Create view vw_ss_sector_name as
SELECT NAME COLLATE SQL_Latin1_General_CP1_CI_AS AS Name, DESCRIPTION COLLATE SQL_Latin1_General_CP1_CI_AS AS Description
  FROM [GOCDSSP].[DBSosst].[dbo].[SRG_POINT]
  where [STRUCTURE_ID]=7
  and [GROUP_ID]=4
  and [TYPE]='D'
  and ENABLED=1
  and NAME <>'';

CREATE VIEW vw_ss_ledger_accounts as
SELECT [ldr_entity_id] COLLATE SQL_Latin1_General_CP1_CI_AS as ldr_entity_id
      ,[ministry] COLLATE SQL_Latin1_General_CP1_CI_AS as ministry
      ,[program] COLLATE SQL_Latin1_General_CP1_CI_AS as program
      ,[subprog] COLLATE SQL_Latin1_General_CP1_CI_AS as subprog
      ,[account] COLLATE SQL_Latin1_General_CP1_CI_AS as account
      ,[project] COLLATE SQL_Latin1_General_CP1_CI_AS as project
      ,[sof] COLLATE SQL_Latin1_General_CP1_CI_AS as sof
      ,[sector] COLLATE SQL_Latin1_General_CP1_CI_AS as sector
  FROM [DBSglep].[dbo].[ldr_acct]
  WHERE acct_type_code='E'
  AND close_date>GETDATE();


  
CREATE VIEW vw_user_access as
SELECT DISTINCT [User_Access].userName, 
      [ministry]
      ,[program]
      ,[subprog]     
  FROM [Budget_Estimates]
  INNER JOIN [User_Access] ON [Budget_Estimates].subprog = [User_Access] .subprogram;


CREATE VIEW vw_subprogram_submitted as
SELECT DISTINCT 
      [processing_year]
      ,[ministry]
      ,[program]
      ,[subprog]     
  FROM [Budget_Estimates]
WHERE entry_status_id=1;


CREATE VIEW vw_subprogram_approved as
SELECT DISTINCT 
      [processing_year]
      ,[ministry]
      ,[program]
      ,[subprog]     
  FROM [Budget_Estimates]  
 WHERE entry_status_id=2;

CREATE VIEW [dbo].[vw_subprogram_sub_apv]
AS
SELECT  processing_year, subprog, ministry, program, max(entry_status_id) as status
FROM            dbo.Budget_Estimates
WHERE        entry_status_id in (1,2)
GROUP BY processing_year, subprog, ministry, program
