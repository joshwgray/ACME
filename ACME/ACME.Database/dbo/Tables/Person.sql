CREATE TABLE [dbo].[Person] (
    [PersonId]  INT            IDENTITY (1, 1) NOT NULL,
    [LastName]  NVARCHAR (128) NOT NULL,
    [FirstName] NVARCHAR (128) NOT NULL,
    [BirthDate] DATE           NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);

