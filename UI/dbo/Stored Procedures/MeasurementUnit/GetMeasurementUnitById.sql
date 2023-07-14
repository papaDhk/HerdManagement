-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMeasurementUnitById]
	 @Id int
AS
BEGIN


SELECT [Id]
      ,[Label]
      ,[Symbol]
      ,[Commentary]
  FROM [dbo].[MeasurementUnits]
  WHERE Id = @Id

END
