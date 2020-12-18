CREATE TABLE [dbo].[Calving] (
    [MaleId]           NCHAR (50)  NOT NULL,
    [FemaleId]         NCHAR (50)  NOT NULL,
    [ReproductionDate] DATETIME    NOT NULL,
    [Date]             DATETIME    NOT NULL,
    [NumberOfNewborn]  INT         NOT NULL,
    [Commentary]       NCHAR (250) NULL,
    CONSTRAINT [PK_Calving] PRIMARY KEY CLUSTERED ([MaleId] ASC, [FemaleId] ASC, [ReproductionDate] ASC)
);

