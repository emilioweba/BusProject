
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/06/2015 17:52:50
-- Generated from EDMX file: C:\Users\Emilio\documents\visual studio 2013\Projects\Bus_Application\Bus_Application\Bus_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Teste_Onibus];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Route_Bus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ROUTE] DROP CONSTRAINT [FK_Route_Bus];
GO
IF OBJECT_ID(N'[dbo].[FK_Route_District]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ROUTE] DROP CONSTRAINT [FK_Route_District];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BUS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BUS];
GO
IF OBJECT_ID(N'[dbo].[DISTRICT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DISTRICT];
GO
IF OBJECT_ID(N'[dbo].[ROUTE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ROUTE];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Buses'
CREATE TABLE [dbo].[Buses] (
    [Bus_ID] int IDENTITY(1,1) NOT NULL,
    [Bus_Description] varchar(50)  NOT NULL,
    [Bus_Provider] varchar(50)  NULL,
    [Bus_Color] varchar(20)  NULL,
    [Bus_Route] geography  NULL
);
GO

-- Creating table 'LANDMARKs'
CREATE TABLE [dbo].[LANDMARKs] (
    [Landmark_ID] int IDENTITY(1,1) NOT NULL,
    [Landmark_Name] nchar(50)  NOT NULL,
    [Landmark_Latitude] nvarchar(max)  NOT NULL,
    [Landmark_Longitude] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ROUTEs'
CREATE TABLE [dbo].[ROUTEs] (
    [Route_ID] int IDENTITY(1,1) NOT NULL,
    [Bus_ID] int  NULL,
    [District_ID] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Bus_ID] in table 'Buses'
ALTER TABLE [dbo].[Buses]
ADD CONSTRAINT [PK_Buses]
    PRIMARY KEY CLUSTERED ([Bus_ID] ASC);
GO

-- Creating primary key on [Landmark_ID] in table 'LANDMARKs'
ALTER TABLE [dbo].[LANDMARKs]
ADD CONSTRAINT [PK_LANDMARKs]
    PRIMARY KEY CLUSTERED ([Landmark_ID] ASC);
GO

-- Creating primary key on [Route_ID] in table 'ROUTEs'
ALTER TABLE [dbo].[ROUTEs]
ADD CONSTRAINT [PK_ROUTEs]
    PRIMARY KEY CLUSTERED ([Route_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Bus_ID] in table 'ROUTEs'
ALTER TABLE [dbo].[ROUTEs]
ADD CONSTRAINT [FK_Route_Bus]
    FOREIGN KEY ([Bus_ID])
    REFERENCES [dbo].[Buses]
        ([Bus_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Route_Bus'
CREATE INDEX [IX_FK_Route_Bus]
ON [dbo].[ROUTEs]
    ([Bus_ID]);
GO

-- Creating foreign key on [District_ID] in table 'ROUTEs'
ALTER TABLE [dbo].[ROUTEs]
ADD CONSTRAINT [FK_Route_District]
    FOREIGN KEY ([District_ID])
    REFERENCES [dbo].[LANDMARKs]
        ([Landmark_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Route_District'
CREATE INDEX [IX_FK_Route_District]
ON [dbo].[ROUTEs]
    ([District_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------