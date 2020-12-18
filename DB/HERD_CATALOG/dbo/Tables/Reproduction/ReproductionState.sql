CREATE TABLE [dbo].[ReproductionState] (
    [State]            VARCHAR (50) NOT NULL,
    [Date]             DATETIME     NOT NULL,
    [MaleId]           NCHAR (50)   NOT NULL,
    [FemaleId]         NCHAR (50)   NOT NULL,
    [ReproductionDate] DATETIME     NOT NULL,
    CONSTRAINT [PK_ReproductionState] PRIMARY KEY CLUSTERED ([Date] ASC, [MaleId] ASC, [FemaleId] ASC, [ReproductionDate] ASC),
    CONSTRAINT [FK_ReproductionState_Reproduction1] FOREIGN KEY ([MaleId], [FemaleId], [ReproductionDate]) REFERENCES [dbo].[Reproduction] ([MaleId], [FemaleId], [Date])
);

