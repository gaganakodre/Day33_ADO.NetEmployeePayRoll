create procedure spDeleteEmployee
@Name varchar(120)
as
Delete EmployeeTable where Name=@Name;

exec spDeleteEmployee 'Shree';

