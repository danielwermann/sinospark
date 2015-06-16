CREATE TABLE [dbo].[Pagamento] (
    [Id]                INT             NOT NULL IDENTITY(1,1),
    [Tempo]             TIME (7)        NULL,
    [Valor]             DECIMAL (10, 2) NULL,
    [DataHoraPagamento] DATETIME        NULL,
    [EventoId]          SMALLINT        NOT NULL,
    [PagamentoTipoId]   TINYINT         NOT NULL,
    CONSTRAINT [PK_Pagamento] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pagamento_Evento] FOREIGN KEY ([EventoId]) REFERENCES [dbo].[Evento] ([Id]),
    CONSTRAINT [FK_Pagamento_PagamentoTipo] FOREIGN KEY ([PagamentoTipoId]) REFERENCES [dbo].[PagamentoTipo] ([Id])
);

