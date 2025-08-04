CREATE PROCEDURE [dbo].[spUsers_GetAll]
AS
Begin

Select
    Id, FirstName, LastName
  From [dbo].[Users] with (nolock)

End