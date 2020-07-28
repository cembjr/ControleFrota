Create Database ControleFrota;
GO

Use ControleFrota;
GO


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
    [ServKmFina] int NULL,
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



IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(128) NOT NULL,
    [ProviderKey] nvarchar(128) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(128) NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200727233329_Identity', N'3.1.6');

GO




