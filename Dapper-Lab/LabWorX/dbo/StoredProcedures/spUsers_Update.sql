CREATE PROCEDURE [dbo].[spUsers_Update]
  @id UNIQUEIDENTIFIER,
  @firstName NVARCHAR(50),
  @lastName NVARCHAR(50)
AS
Begin

Update [dbo].[Users] set
    FirstName = @firstName,
    LastName = @lastName
  Where Id = @id;

End