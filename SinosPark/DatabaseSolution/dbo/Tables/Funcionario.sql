CREATE TABLE [dbo].[Funcionario] (
    [Id]        SMALLINT      NOT NULL identity(1,1),
    [Nome]      NVARCHAR (50) NOT NULL,
    [CPF]       NCHAR (11)    NOT NULL,
    [isGerente] BIT           NOT NULL,
    [Email]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

