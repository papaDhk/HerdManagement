-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Insert a neaw row in Breed table
-- =============================================
CREATE PROCEDURE [dbo].[InsertNewBreed] 
	-- Add the parameters for the stored procedure here
	@Label varchar(50),	
	@SpecieId int
AS
BEGIN

INSERT INTO [dbo].[Breed]
           ([Label]
           ,[SpecieId])
	 OUTPUT INSERTED.Id
     VALUES
           (@Label
           ,@SpecieId)
END
