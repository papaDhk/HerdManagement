-- =============================================
-- Author:		<Author,,Label>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBreedsByLabel]
	-- Add the parameters for the stored procedure here
	@Label varchar(50)
AS
BEGIN
SELECT B.[Id]
      ,B.[Label]
      ,B.[SpecieId]
      ,S.Id
      ,S.[Label]
      ,S.[ChildhoodDurationInDays]
      ,S.[PregnancyDurationInDays]
      ,S.[MinimumTimeSpanBetweenCalvingAndHeatInDays]

  FROM [dbo].[Breed] as B 
  inner join dbo.Specie S on B.SpecieId =S.Id
  WHERE B.Label = @Label
END