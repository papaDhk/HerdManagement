CREATE PROCEDURE [dbo].[DeleteMeasurementUnit]
	@Id int
AS

BEGIN
	Delete MeasurementUnits where Id = @Id;
END
