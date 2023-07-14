-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetHerdById]

@Id int
	
AS
BEGIN
	SELECT
	   H.[Id]
      ,H.[Name]
      ,H.[Color]
      ,H.[Description]
      ,H.[LivingMembersNumber]
      ,H.[SpecieId]
      ,S.Id
      ,S.[Label]
      ,S.[ChildhoodDurationInDays]
      ,S.[PregnancyDurationInDays]
      ,S.[MinimumTimeSpanBetweenCalvingAndHeatInDays]
  FROM [dbo].[Herds] as H
   inner join dbo.Specie S on H.SpecieId =S.Id  WHERE H.Id = @Id
END