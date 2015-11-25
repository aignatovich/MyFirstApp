CREATE TABLE [dbo].[ProjectModels] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [StartDate] DATETIME       NOT NULL,
    [EndDate]   DATETIME       NULL,
    CONSTRAINT [PK_dbo.ProjectModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

