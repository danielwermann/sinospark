CREATE TABLE [dbo].[Aluno] (
    [Id]         INT             NOT NULL IDENTITY (1,1),
    [CPF]        NCHAR (11)      NULL,
    [Matricula]  NCHAR (10)      NOT NULL,
    [Nome]       NVARCHAR (50)   NOT NULL,
    [ValorSaldo] DECIMAL (10, 2) NULL,
    CONSTRAINT [PK_Aluno] PRIMARY KEY  CLUSTERED ([Id] ASC)
);

