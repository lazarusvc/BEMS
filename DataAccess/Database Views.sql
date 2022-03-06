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