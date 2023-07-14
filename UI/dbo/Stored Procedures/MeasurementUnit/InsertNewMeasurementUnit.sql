-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Insert a neaw row in Herd table
-- =============================================
CREATE PROCEDURE [dbo].[InsertNewMeasurementUnit]
	-- Add the parameters for the stored procedure here
	@Label varchar(50),
    @Symbol varchar(50),
	@Commentary varchar(50)
AS
BEGIN

INSERT INTO [dbo].[MeasurementUnits]
           ([Label]
           ,[Symbol]
           ,[Commentary])
           OUTPUT inserted.Id
     VALUES
           (@Label
           ,@Symbol
           ,@Commentary)		    
END
