CREATE TABLE [dbo].[VeiculoModelo] (
    [Id]        SMALLINT      NOT NULL IDENTITY(1,1),
    [Descricao] NVARCHAR (50) NULL,
    [isAtivo]   BIT           NULL,
    [isMoto]    BIT           NOT NULL,
    CONSTRAINT [PK_VeiculoModelo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

