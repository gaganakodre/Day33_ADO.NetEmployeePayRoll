ALTER procedure spAddEmployee

@Name nvarchar(150),
@Department nvarchar(120),
@Address nvarchar(120),
@Phone int,
@BasicPay float,
@Gender char(1),
@StartDate varchar(120),
@TaxablePay float,
@NetPay float,
@IncomeTax float,
@Deductions float


as
insert into EmployeeTable(Name,Department,Address,Phone,
BasicPay,Gender ,StartDate,TaxablePay,NetPay,IncomTax,Deductions) values(@Name,@Department,@Address,@Phone,
@BasicPay,@Gender ,@StartDate,@TaxablePay,@NetPay,@IncomeTax,@Deductions);


exec spAddEmployee 'RAVI','hr','2nd cross',5347676,78765,'M','2000-09-08',6547,756,746,923;