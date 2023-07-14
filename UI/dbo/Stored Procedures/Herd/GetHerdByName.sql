-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetHerdByName]
	-- Add the parameters for the stored procedure here
	@Name varchar(50)
AS
BEGIN
SELECT H.[Id]
      ,H.[Name]
      ,H.[Color]
      ,H.[Description]
      ,H.[LivingMembersNumber]
      ,H.[SpecieId]
      ,S.[Label]
      ,S.[ChildhoodDurationInDays]
      ,S.[PregnancyDurationInDays]
      ,S.[MinimumTimeSpanBetweenCalvingAndHeatInDays]

  FROM [dbo].[Herds] as H 
  inner join dbo.Specie S on H.SpecieId =S.Id
  WHERE H.Name = @Name
END