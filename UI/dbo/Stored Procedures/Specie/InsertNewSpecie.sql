-- =============================================
-- Author:		Momar
-- Create date: 
-- Description:	Insert a neaw row in Herd table
-- =============================================
CREATE PROCEDURE [dbo].[InsertNewSpecie]
	-- Add the parameters for the stored procedure here
	@Label varchar(50),
	@ChildhoodDurationInDays int,
	@PregnancyDurationInDays int,
	@MinimumTimeSpanBetweenCalvingAndHeatInDays int
AS
BEGIN

INSERT INTO [dbo].[Specie]
           ([Label]
           ,[ChildhoodDurationInDays]
           ,[PregnancyDurationInDays]
           ,[MinimumTimeSpanBetweenCalvingAndHeatInDays])
           OUTPUT inserted.Id
     VALUES
           (@Label
           ,@ChildhoodDurationInDays
           ,@PregnancyDurationInDays
           ,@MinimumTimeSpanBetweenCalvingAndHeatInDays)		    
END
