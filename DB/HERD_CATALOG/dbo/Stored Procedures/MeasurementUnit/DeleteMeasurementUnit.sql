CREATE PROCEDURE [dbo].[DeleteMeasurementUnit]
	@Id int
AS

BEGIN
	Delete MeasurementUnit where Id = @Id;
END
