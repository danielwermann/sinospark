CREATE TABLE [dbo].[Evento] (
    [Id]               SMALLINT      NOT NULL IDENTITY(1,1),
    [Entrada]          DATETIME      NOT NULL,
    [Saida]            DATETIME      NULL,
    [CodigoBarras]     NVARCHAR (50) NOT NULL,
    [VeiculoId]        INT           NULL,
    [AlunoId]          INT           NULL,
    [EstacionamentoId] SMALLINT      NOT NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Evento_Aluno] FOREIGN KEY ([AlunoId]) REFERENCES [dbo].[Aluno] ([Id]),
    CONSTRAINT [FK_Evento_Estacionamento] FOREIGN KEY ([EstacionamentoId]) REFERENCES [dbo].[Estacionamento] ([Id]),
    CONSTRAINT [FK_Evento_Veiculo] FOREIGN KEY ([VeiculoId]) REFERENCES [dbo].[Veiculo] ([Id])
);

