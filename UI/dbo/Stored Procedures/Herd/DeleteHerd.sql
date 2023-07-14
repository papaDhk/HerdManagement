-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Delete a row in Herd table
-- =============================================
CREATE PROCEDURE [dbo].[DeleteHerd] 
	-- Add the parameters for the stored procedure here
	@Id int
AS
BEGIN

	DELETE [dbo].[Herds]
    WHERE Id = @Id  
END
