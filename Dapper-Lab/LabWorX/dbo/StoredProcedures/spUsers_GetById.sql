CREATE PROCEDURE [dbo].[spUsers_GetById]
  @id UNIQUEIDENTIFIER
AS
Begin

Select
    Id, FirstName, LastName
  From [dbo].[Users] with (nolock)
  Where Id = @id

End