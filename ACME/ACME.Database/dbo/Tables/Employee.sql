CREATE TABLE [dbo].[Employee] (
    [EmployeeId]     INT           IDENTITY (1, 1) NOT NULL,
    [PersonId]       INT           NOT NULL,
    [EmployeeNum]    NVARCHAR (16) NOT NULL,
    [EmployedDate]   DATE          NOT NULL,
    [TerminatedDate] DATE          NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeId] ASC),
    CONSTRAINT [FK_Employee_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);

