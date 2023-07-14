-- =============================================
-- Author:		<Author,,Label>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllBreeds] 
	
AS
BEGIN
	  SELECT B.[Id]
      ,B.[Label]
      ,B.[SpecieId]
      ,S.[Id]
      ,S.[Label]
      ,S.[ChildhoodDurationInDays]
      ,S.[PregnancyDurationInDays]
      ,S.[MinimumTimeSpanBetweenCalvingAndHeatInDays]

  FROM [dbo].[Breed] as B 
  inner join dbo.Specie S on B.SpecieId = S.Id
END
