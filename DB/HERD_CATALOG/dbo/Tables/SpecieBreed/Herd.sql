CREATE TABLE [dbo].[Herd] (
    [Id]                  INT          IDENTITY (1, 1) NOT NULL,
    [Name]                VARCHAR (50) NOT NULL,
    [Color]               VARCHAR (50) NOT NULL,
    [Description]         NCHAR (250)  NULL,
    [LivingMembersNumber] INT          NOT NULL,
    [SpecieId]            INT          NOT NULL,
    CONSTRAINT [PK_Herd] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Herd_Specie] FOREIGN KEY ([SpecieId]) REFERENCES [dbo].[Specie] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Herd]
    ON [dbo].[Herd]([Id] ASC);

