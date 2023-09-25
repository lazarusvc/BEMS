USE [GOCDBudget_NW]
GO
CREATE VIEW vw_ss_account_name AS SELECT * FROM view_ss_account_name
CREATE VIEW vw_ss_ledger_accounts AS SELECT * FROM view_ss_ledger_accounts
CREATE VIEW vw_ss_ministry_name AS SELECT * FROM view_ss_ministry_name
CREATE VIEW vw_ss_program_name AS SELECT * FROM view_ss_program_name
CREATE VIEW vw_ss_project_name AS SELECT * FROM view_ss_project_name
CREATE VIEW vw_ss_sector_name AS SELECT * FROM view_ss_sector_name
CREATE VIEW vw_ss_sof_name AS SELECT * FROM view_ss_sof_name
CREATE VIEW vw_ss_subprog_name AS SELECT * FROM view_ss_subprog_name
CREATE VIEW vw_subprogram_approved AS SELECT * FROM view_subprogram_approved
CREATE VIEW vw_subprogram_sub_apv AS SELECT * FROM view_subprogram_sub_apv
CREATE VIEW vw_subprogram_submitted AS SELECT * FROM view_subprogram_submitted
CREATE VIEW vw_user_access AS SELECT * FROM view_user_access
GO