-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Updaet a row in Breed table
-- =============================================
CREATE PROCEDURE [dbo].UpdateBreed 
	-- Add the parameters for the stored procedure here
    @Id int,
	@Label varchar(50),
	@SpecieId int
AS
BEGIN

UPDATE [dbo].[Breed]

         SET [Label] = @Label
           ,[SpecieId] = @SpecieId
          WHERE Id = @Id
END
