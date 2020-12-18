-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMeasurementUnitByLabel] 
	-- Add the parameters for the stored procedure here
	@Label varchar(50)
AS
BEGIN
SELECT [Id]
      ,[Label]
      ,[Symbol]
      ,[Commentary]
  FROM [dbo].[MeasurementUnit]
  Where Label = @Label
END
