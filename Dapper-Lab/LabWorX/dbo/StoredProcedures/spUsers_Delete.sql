CREATE PROCEDURE [dbo].[spUsers_Delete]
  @Id UNIQUEIDENTIFIER
AS
Begin

Delete from [dbo].[Users]
  Where Id = @Id

End