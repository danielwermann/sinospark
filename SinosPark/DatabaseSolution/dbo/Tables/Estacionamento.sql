CREATE TABLE [dbo].[Estacionamento] (
    [Id]               SMALLINT      NOT NULL IDENTITY(1,1),
    [Nome]             NVARCHAR (50) NOT NULL,
    [isAtivo]          BIT           NOT NULL,
    [QuantidadeMaxima] SMALLINT      NULL,
    CONSTRAINT [PK_Estacionamento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

