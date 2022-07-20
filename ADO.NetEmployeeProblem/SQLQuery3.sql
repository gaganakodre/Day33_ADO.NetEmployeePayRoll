create procedure spUpdateEmployee
@BasicPay float,
@Name varchar(120)
as
Update EmployeeTable set BasicPay=@BasicPay where Name=@Name;

exec spUpdateEmployee 30000,'Shree'

