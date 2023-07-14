-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllSpecies]
	
AS
BEGIN


SELECT [Id]
      ,[Label]
      ,[ChildhoodDurationInDays]
      ,[PregnancyDurationInDays]
      ,[MinimumTimeSpanBetweenCalvingAndHeatInDays]
  FROM [dbo].[Specie]

END
