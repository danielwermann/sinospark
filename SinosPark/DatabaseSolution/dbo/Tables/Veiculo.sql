CREATE TABLE [dbo].[Veiculo] (
    [Id]              INT           NOT NULL IDENTITY(1,1),
    [Placa]           NCHAR (10)    NOT NULL,
    [Cor]             NVARCHAR (30) NULL,
    [VeiculoModeloId] SMALLINT      NULL,
    [isBloqueado]     BIT           NULL,
    CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Veiculo_VeiculoModelo] FOREIGN KEY ([VeiculoModeloId]) REFERENCES [dbo].[VeiculoModelo] ([Id])
);

