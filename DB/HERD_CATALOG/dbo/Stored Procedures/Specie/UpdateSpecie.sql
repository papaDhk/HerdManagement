CREATE PROCEDURE [dbo].[UpdateSpecie]
    @Id int,
	@Label varchar(50),
	@ChildhoodDurationInDays int,
	@PregnancyDurationInDays int,
	@MinimumTimeSpanBetweenCalvingAndHeatInDays int
AS

BEGIN
    UPDATE [dbo].[Specie]
       SET [Label] = @Label
          ,[ChildhoodDurationInDays] = @ChildhoodDurationInDays
          ,[PregnancyDurationInDays] = @PregnancyDurationInDays
          ,[MinimumTimeSpanBetweenCalvingAndHeatInDays] = @MinimumTimeSpanBetweenCalvingAndHeatInDays
     WHERE Id = @Id
END 



