-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Insert a neaw row in Herd table
-- =============================================
CREATE PROCEDURE [dbo].[InsertNewHerd] 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(50),
	@Color varchar(7) = "#FFFFFF",
	@Description nvarchar(50) = null ,
	@SpecieId int
AS
BEGIN

INSERT INTO [dbo].[Herds]
           ([Name]
           ,[Color]
           ,[Description]
           ,[LivingMembersNumber]
           ,[SpecieId])
	 OUTPUT INSERTED.Id
     VALUES
           (@Name
           ,@Color
           ,@Description
           ,0
           ,@SpecieId)
END
