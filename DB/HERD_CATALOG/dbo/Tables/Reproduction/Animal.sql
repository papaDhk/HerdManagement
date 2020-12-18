CREATE TABLE [dbo].[Animal] (
    [Id]                 NCHAR (50)     NOT NULL,
    [Sex]                VARCHAR (10)   NOT NULL,
    [BirthDate]          DATETIME       NOT NULL,
    [Picture]            VARBINARY (50) NULL,
    [Bought]             BIT            NOT NULL,
    [Weight]             INT            NULL,
    [PresenceStatusEnum] VARCHAR (20)   NOT NULL,
    [DeathDate]          DATETIME       NULL,
    [BreedId]            INT            NOT NULL,
    [HerdId]             INT            NOT NULL,
    [Class]              VARCHAR (30)   NOT NULL,
    CONSTRAINT [PK_Animal] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Animal_Breed] FOREIGN KEY ([BreedId]) REFERENCES [dbo].[Breed] ([Id]),
    CONSTRAINT [FK_Animal_Herd] FOREIGN KEY ([HerdId]) REFERENCES [dbo].[Herd] ([Id])
);

