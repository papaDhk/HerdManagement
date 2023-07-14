-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllMeasurementUnits]
	
AS
BEGIN


SELECT [Id]
      ,[Label]
      ,[Symbol]
      ,[Commentary]
  FROM [dbo].[MeasurementUnits]

END
