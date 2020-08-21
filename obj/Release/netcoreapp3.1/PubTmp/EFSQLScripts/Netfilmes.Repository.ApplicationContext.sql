IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821021538_Netfilmes')
BEGIN
    CREATE TABLE [Genero] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [DataDeCriacao] datetime2 NOT NULL DEFAULT (CONVERT(DATE, GETDATE())),
        [Ativo] bit NOT NULL,
        CONSTRAINT [PK_Genero] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821021538_Netfilmes')
BEGIN
    CREATE TABLE [Locacao] (
        [Id] int NOT NULL IDENTITY,
        [Cpf] nvarchar(max) NULL,
        [DataDaLocacao] datetime2 NOT NULL DEFAULT (CONVERT(DATE, GETDATE())),
        CONSTRAINT [PK_Locacao] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821021538_Netfilmes')
BEGIN
    CREATE TABLE [Usuario] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [Senha] nvarchar(max) NULL,
        [DataDeCriacao] datetime2 NOT NULL DEFAULT (CONVERT(DATE, GETDATE())),
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821021538_Netfilmes')
BEGIN
    CREATE TABLE [Filme] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(max) NULL,
        [DataDeCriacao] datetime2 NOT NULL DEFAULT (CONVERT(DATE, GETDATE())),
        [Ativo] bit NOT NULL,
        [GeneroId] int NULL,
        [LocacaoId] int NULL,
        CONSTRAINT [PK_Filme] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Filme_Genero_GeneroId] FOREIGN KEY ([GeneroId]) REFERENCES [Genero] ([Id]) ON DELETE SET NULL,
        CONSTRAINT [FK_Filme_Locacao_LocacaoId] FOREIGN KEY ([LocacaoId]) REFERENCES [Locacao] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821021538_Netfilmes')
BEGIN
    CREATE INDEX [IX_Filme_GeneroId] ON [Filme] ([GeneroId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821021538_Netfilmes')
BEGIN
    CREATE INDEX [IX_Filme_LocacaoId] ON [Filme] ([LocacaoId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200821021538_Netfilmes')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200821021538_Netfilmes', N'3.1.7');
END;

GO

