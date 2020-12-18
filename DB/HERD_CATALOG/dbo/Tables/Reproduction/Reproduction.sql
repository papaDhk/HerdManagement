CREATE TABLE [dbo].[Reproduction] (
    [MaleId]     NCHAR (50)   NOT NULL,
    [FemaleId]   NCHAR (50)   NOT NULL,
    [Date]       DATETIME     NOT NULL,
    [Type]       VARCHAR (50) NOT NULL,
    [Commentary] NCHAR (250)  NULL,
    CONSTRAINT [PK_Reproduction] PRIMARY KEY CLUSTERED ([MaleId] ASC, [FemaleId] ASC, [Date] ASC),
    CONSTRAINT [FK_Reproduction_Calving] FOREIGN KEY ([MaleId], [FemaleId], [Date]) REFERENCES [dbo].[Calving] ([MaleId], [FemaleId], [ReproductionDate]),
    CONSTRAINT [FK_Reproduction_Female] FOREIGN KEY ([FemaleId]) REFERENCES [dbo].[Animal] ([Id]),
    CONSTRAINT [FK_Reproduction_Male] FOREIGN KEY ([MaleId]) REFERENCES [dbo].[Animal] ([Id])
);

