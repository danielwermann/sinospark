CREATE TABLE [dbo].[Preco] (
    [Id]      SMALLINT        NOT NULL IDENTITY(1,1),
    [Tempo]   TIME (7)        NOT NULL,
    [Valor]   DECIMAL (10, 2) NOT NULL,
    [isMoto]  BIT             NOT NULL,
    [isAtivo] BIT             NOT NULL,
    CONSTRAINT [PK_Preco] PRIMARY KEY CLUSTERED ([Id] ASC)
);

