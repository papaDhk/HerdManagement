CREATE TABLE [dbo].[Specie] (
    [Id]                                         INT          IDENTITY (1, 1) NOT NULL,
    [Label]                                      VARCHAR (50) NOT NULL,
    [ChildhoodDurationInDays]                    INT          NOT NULL,
    [PregnancyDurationInDays]                    INT          NOT NULL,
    [MinimumTimeSpanBetweenCalvingAndHeatInDays] INT          NOT NULL,
    CONSTRAINT [PK_Specie] PRIMARY KEY CLUSTERED ([Id] ASC)
);

