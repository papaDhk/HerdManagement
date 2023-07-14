CREATE PROCEDURE [dbo].[UpdateMeasurementUnit]
    @Id int,
	@Label varchar(50),
    @Symbol varchar(50),
	@Commentary varchar(50)
AS

BEGIN
    UPDATE [dbo].[MeasurementUnits]
       SET [Label] = @Label
          ,[Symbol] = @Symbol
          ,[Commentary] = @Commentary
     WHERE Id = @Id
END 



