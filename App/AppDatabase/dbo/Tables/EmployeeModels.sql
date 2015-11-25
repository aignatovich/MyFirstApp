CREATE TABLE [dbo].[EmployeeModels] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Surname]  NVARCHAR (MAX) NULL,
    [Position] INT            NOT NULL,
    CONSTRAINT [PK_dbo.EmployeeModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

