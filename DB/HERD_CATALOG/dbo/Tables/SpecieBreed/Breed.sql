CREATE TABLE [dbo].[Breed] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Label]    VARCHAR (50) NOT NULL,
    [SpecieId] INT          NOT NULL,
    CONSTRAINT [PK_Breed] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Breed_Specie] FOREIGN KEY ([SpecieId]) REFERENCES [dbo].[Specie] ([Id])
);

