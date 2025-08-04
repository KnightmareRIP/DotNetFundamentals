CREATE PROCEDURE [dbo].[spUsers_Delete]
  @id UNIQUEIDENTIFIER
AS
Begin

Delete from [dbo].[Users]
  Where Id = @id

End