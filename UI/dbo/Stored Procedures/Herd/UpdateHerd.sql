-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Updaet a row in Herd table
-- =============================================
CREATE PROCEDURE [dbo].UpdateHerd 
	-- Add the parameters for the stored procedure here
    @Id int,
	@Name nvarchar(50),
	@Color varchar(7),
	@Description nvarchar(50),
	@SpecieId int
AS
BEGIN

UPDATE [dbo].[Herds]

         SET [Name] = @Name
           ,[Color] = @Color
           ,[Description] = @Description
           ,[SpecieId] = @SpecieId
          WHERE Id = @Id
END
