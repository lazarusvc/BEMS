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