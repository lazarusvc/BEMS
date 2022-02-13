--Change the Roles to include Capital
update [role]
set description='Data entry operator - Recurrent'
where name='dataentry';

update [role]
set description='Budget Department Administrator - Recurrent'
where name='budgetadmin';

insert into [role](name,description)
values ('capbudgetadmin','Budget Department Administrator - Capital'),
	('capdataentry','Data entry operator - Capital'),
	('psip','PSIP Administrator');
