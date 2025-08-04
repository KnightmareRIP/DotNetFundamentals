CREATE PROCEDURE [dbo].[spUsers_Insert]
  @firstName NVARCHAR(50),
  @lastName NVARCHAR(50)
AS
Begin

Insert Into [dbo].[Users] (FirstName, LastName)
Values (@firstName, @lastName);

Select SCOPE_IDENTITY() as Id;

End