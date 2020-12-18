CREATE TABLE [dbo].[MeasurementUnit] (
    [Label]      VARCHAR (50) NOT NULL,
    [Symbol]       VARCHAR (50) NOT NULL,
    [Commentary] NCHAR (100)  NULL,
    [Id] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_MeasurementUnit] PRIMARY KEY CLUSTERED ([Id])
);

