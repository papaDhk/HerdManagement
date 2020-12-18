CREATE PROCEDURE [dbo].[DeleteSpecie]
	@Id int
AS

BEGIN
	Delete Specie where Id = @Id;
END
