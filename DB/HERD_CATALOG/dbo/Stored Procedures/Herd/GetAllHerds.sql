-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllHerds] 
	
AS
BEGIN
	  SELECT H.[Id]
      ,H.[Name]
      ,H.[Color]
      ,H.[Description]
      ,H.[LivingMembersNumber]
      ,H.[SpecieId]
      ,S.[Id]
      ,S.[Label]
      ,S.[ChildhoodDurationInDays]
      ,S.[PregnancyDurationInDays]
      ,S.[MinimumTimeSpanBetweenCalvingAndHeatInDays]

  FROM [dbo].[Herd] as H 
  inner join dbo.Specie S on H.SpecieId =S.Id
END
