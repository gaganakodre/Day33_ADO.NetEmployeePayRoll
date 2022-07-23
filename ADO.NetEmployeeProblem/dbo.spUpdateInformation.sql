CREATE procedure spUpdateInformation
@Address varchar(200),
@FirstName varchar(200)

as
update  AddressBookInfo set Address=@Address where FirstName=@FirstName

exec spUpdateInformation 'gsf','hsd'; 