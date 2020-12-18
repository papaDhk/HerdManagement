-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBreedById]

@Id int
	
AS
BEGIN
	SELECT
	   B.[Id]
      ,B.[Label]
      ,B.[SpecieId]
      ,S.Id
      ,S.[Label]
      ,S.[ChildhoodDurationInDays]
      ,S.[PregnancyDurationInDays]
      ,S.[MinimumTimeSpanBetweenCalvingAndHeatInDays]
  FROM [dbo].[Breed] as B
   inner join dbo.Specie S on B.SpecieId =S.Id  WHERE B.Id = @Id
END