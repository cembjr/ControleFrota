IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [CFAten] (
    [IdAten] uniqueidentifier NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [IsExcluido] bit NOT NULL,
    [AtenNome] nvarchar(max) NOT NULL,
    [AtenTele] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_CFAten] PRIMARY KEY ([IdAten])
);

GO

CREATE TABLE [CFMoto] (
    [IdMoto] uniqueidentifier NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [IsExcluido] bit NOT NULL,
    [MotoNome] nvarchar(max) NOT NULL,
    [MotoTele] nvarchar(max) NOT NULL,
    [MotoCnh] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_CFMoto] PRIMARY KEY ([IdMoto])
);

GO

CREATE TABLE [CFVeic] (
    [IdVeic] uniqueidentifier NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [IsExcluido] bit NOT NULL,
    [VeicMarc] nvarchar(max) NOT NULL,
    [VeicMode] nvarchar(max) NOT NULL,
    [VeicPlac] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_CFVeic] PRIMARY KEY ([IdVeic])
);

GO

CREATE TABLE [CFServ] (
    [IdServ] uniqueidentifier NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [IsExcluido] bit NOT NULL,
    [DatSaid] datetime2 NOT NULL,
    [DatCheg] datetime2 NULL,
    [IdAten] uniqueidentifier NOT NULL,
    [IdMoto] uniqueidentifier NOT NULL,
    [IdVeic] uniqueidentifier NOT NULL,
    [ServDest] nvarchar(max) NOT NULL,
    [ServObse] nvarchar(max) NULL,
    [ServKmInic] int NOT NULL,
    [ServKmFina] int NOT NULL,
    CONSTRAINT [PK_CFServ] PRIMARY KEY ([IdServ]),
    CONSTRAINT [FK_CFServ_CFAten_IdAten] FOREIGN KEY ([IdAten]) REFERENCES [CFAten] ([IdAten]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CFServ_CFMoto_IdMoto] FOREIGN KEY ([IdMoto]) REFERENCES [CFMoto] ([IdMoto]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CFServ_CFVeic_IdVeic] FOREIGN KEY ([IdVeic]) REFERENCES [CFVeic] ([IdVeic]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_CFServ_IdAten] ON [CFServ] ([IdAten]);

GO

CREATE INDEX [IX_CFServ_IdMoto] ON [CFServ] ([IdMoto]);

GO

CREATE INDEX [IX_CFServ_IdVeic] ON [CFServ] ([IdVeic]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200727232939_Inicial', N'3.1.6');

GO

