CREATE DATABASE EmployeePayRollProblem

Create table EmployeeTable
(
EmployeeID int Primary Key,
Name varchar(200),
Department varchar(300),
Address varchar(200),
Phone int,
BasicPay float,
Gender char(1),
StartDate varchar(200),
TaxablePay float,
NetPay float,
IncomTax Float,
Deductions float);

select * from EmployeeTable;

Insert into EmployeeTable values(001,'Shree','HR','1st Cross',1345678909,2000000,'F','2016-04-01',50000,800000,9000,7000),
(002,'Gowri','Development','2st Cross',1305678909,3000000,'F','2017-05-01',60000,900000,9500,7900),
(003,'Mahesh','CEO','3st Cross',1349678909,4000000,'M','2008-04-01',800000,900000,91000,7100);



