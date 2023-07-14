-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Delete a row in Breed table
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBreed] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN

	DELETE [dbo].[Breed]
    WHERE Id = @Id       
END
