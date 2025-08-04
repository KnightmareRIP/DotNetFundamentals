CREATE PROCEDURE [dbo].[spUsers_GetById]
  @Id UNIQUEIDENTIFIER
AS
Begin

Select
    Id, FirstName, LastName
  From [dbo].[Users] with (nolock)
  Where Id = @Id

End