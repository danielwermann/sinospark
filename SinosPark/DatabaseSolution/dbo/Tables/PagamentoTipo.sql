CREATE TABLE [dbo].[PagamentoTipo] (
    [Id]        TINYINT       NOT NULL IDENTITY(1,1),
    [Descricao] NVARCHAR (50) NOT NULL,
    [isAtivo]   BIT           NOT NULL,
    CONSTRAINT [PK_PagamentoTipo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

