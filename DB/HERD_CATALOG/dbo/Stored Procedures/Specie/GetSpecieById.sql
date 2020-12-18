-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSpecieById]
	 @Id int
AS
BEGIN


SELECT [Id]
      ,[Label]
      ,[ChildhoodDurationInDays]
      ,[PregnancyDurationInDays]
      ,[MinimumTimeSpanBetweenCalvingAndHeatInDays]
  FROM [dbo].[Specie]
  WHERE Id = @Id

END
