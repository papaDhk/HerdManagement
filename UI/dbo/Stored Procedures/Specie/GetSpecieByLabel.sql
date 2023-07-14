-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSpecieByLabel] 
	-- Add the parameters for the stored procedure here
	@Label varchar(50)
AS
BEGIN
SELECT [Id]
      ,[Label]
      ,[ChildhoodDurationInDays]
      ,[PregnancyDurationInDays]
      ,[MinimumTimeSpanBetweenCalvingAndHeatInDays]
  FROM [dbo].[Specie]
  Where Label = @Label
END
