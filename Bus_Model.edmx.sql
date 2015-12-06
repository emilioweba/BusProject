
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/21/2015 18:36:37
-- Generated from EDMX file: C:\Users\Emilio\Documents\Visual Studio 2013\Projects\Bus_Application\Bus_Application\Bus_Model.edmx
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

IF OBJECT_ID(N'[dbo].[FK_LANDMARK_KNOWN_AS_LANDMARKs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LANDMARK_KNOWN_AS] DROP CONSTRAINT [FK_LANDMARK_KNOWN_AS_LANDMARKs];
GO
IF OBJECT_ID(N'[dbo].[FK_Route_Bus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ROUTEs] DROP CONSTRAINT [FK_Route_Bus];
GO
IF OBJECT_ID(N'[dbo].[FK_STATION_BUSES_BUSES1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[STATION_BUSES] DROP CONSTRAINT [FK_STATION_BUSES_BUSES1];
GO
IF OBJECT_ID(N'[dbo].[FK_STATION_BUSES_STATIONS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[STATION_BUSES] DROP CONSTRAINT [FK_STATION_BUSES_STATIONS];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BUSES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BUSES];
GO
IF OBJECT_ID(N'[dbo].[LANDMARK_KNOWN_AS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LANDMARK_KNOWN_AS];
GO
IF OBJECT_ID(N'[dbo].[LANDMARKs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LANDMARKs];
GO
IF OBJECT_ID(N'[dbo].[ROUTEs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ROUTEs];
GO
IF OBJECT_ID(N'[dbo].[STATION_BUSES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STATION_BUSES];
GO
IF OBJECT_ID(N'[dbo].[STATIONS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[STATIONS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LANDMARK_KNOWN_AS'
CREATE TABLE [dbo].[LANDMARK_KNOWN_AS] (
    [Known_As_ID] int  NOT NULL,
    [Known_As_Description] varchar(60)  NULL,
    [Landmark_FK] int  NOT NULL
);
GO

-- Creating table 'STATION_BUSES'
CREATE TABLE [dbo].[STATION_BUSES] (
    [Station_Buses_ID] int IDENTITY(1,1) NOT NULL,
    [Buses_FK] int  NOT NULL,
    [Stations_Fk] int  NOT NULL
);
GO

-- Creating table 'ROUTEs'
CREATE TABLE [dbo].[ROUTEs] (
    [Route_ID] int IDENTITY(1,1) NOT NULL,
    [Bus_ID] int  NULL,
    [Route_Coordinates] geography  NULL
);
GO

-- Creating table 'BUS'
CREATE TABLE [dbo].[BUS] (
    [Bus_ID] int IDENTITY(1,1) NOT NULL,
    [Bus_Description] varchar(50)  NOT NULL,
    [Bus_Provider] varchar(50)  NULL,
    [Bus_Color] varchar(20)  NULL
);
GO

-- Creating table 'STATIONS'
CREATE TABLE [dbo].[STATIONS] (
    [Station_ID] int IDENTITY(1,1) NOT NULL,
    [Station_Description] varchar(50)  NULL,
    [Station_Coordinates] geography  NOT NULL
);
GO

-- Creating table 'LANDMARKs'
CREATE TABLE [dbo].[LANDMARKs] (
    [Landmark_ID] int IDENTITY(1,1) NOT NULL,
    [Landmark_Coordinates] geography  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Known_As_ID] in table 'LANDMARK_KNOWN_AS'
ALTER TABLE [dbo].[LANDMARK_KNOWN_AS]
ADD CONSTRAINT [PK_LANDMARK_KNOWN_AS]
    PRIMARY KEY CLUSTERED ([Known_As_ID] ASC);
GO

-- Creating primary key on [Station_Buses_ID] in table 'STATION_BUSES'
ALTER TABLE [dbo].[STATION_BUSES]
ADD CONSTRAINT [PK_STATION_BUSES]
    PRIMARY KEY CLUSTERED ([Station_Buses_ID] ASC);
GO

-- Creating primary key on [Route_ID] in table 'ROUTEs'
ALTER TABLE [dbo].[ROUTEs]
ADD CONSTRAINT [PK_ROUTEs]
    PRIMARY KEY CLUSTERED ([Route_ID] ASC);
GO

-- Creating primary key on [Bus_ID] in table 'BUS'
ALTER TABLE [dbo].[BUS]
ADD CONSTRAINT [PK_BUS]
    PRIMARY KEY CLUSTERED ([Bus_ID] ASC);
GO

-- Creating primary key on [Station_ID] in table 'STATIONS'
ALTER TABLE [dbo].[STATIONS]
ADD CONSTRAINT [PK_STATIONS]
    PRIMARY KEY CLUSTERED ([Station_ID] ASC);
GO

-- Creating primary key on [Landmark_ID] in table 'LANDMARKs'
ALTER TABLE [dbo].[LANDMARKs]
ADD CONSTRAINT [PK_LANDMARKs]
    PRIMARY KEY CLUSTERED ([Landmark_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Bus_ID] in table 'ROUTEs'
ALTER TABLE [dbo].[ROUTEs]
ADD CONSTRAINT [FK_Route_Bus]
    FOREIGN KEY ([Bus_ID])
    REFERENCES [dbo].[BUS]
        ([Bus_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Route_Bus'
CREATE INDEX [IX_FK_Route_Bus]
ON [dbo].[ROUTEs]
    ([Bus_ID]);
GO

-- Creating foreign key on [Buses_FK] in table 'STATION_BUSES'
ALTER TABLE [dbo].[STATION_BUSES]
ADD CONSTRAINT [FK_STATION_BUSES_BUSES1]
    FOREIGN KEY ([Buses_FK])
    REFERENCES [dbo].[BUS]
        ([Bus_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_STATION_BUSES_BUSES1'
CREATE INDEX [IX_FK_STATION_BUSES_BUSES1]
ON [dbo].[STATION_BUSES]
    ([Buses_FK]);
GO

-- Creating foreign key on [Stations_Fk] in table 'STATION_BUSES'
ALTER TABLE [dbo].[STATION_BUSES]
ADD CONSTRAINT [FK_STATION_BUSES_STATIONS]
    FOREIGN KEY ([Stations_Fk])
    REFERENCES [dbo].[STATIONS]
        ([Station_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_STATION_BUSES_STATIONS'
CREATE INDEX [IX_FK_STATION_BUSES_STATIONS]
ON [dbo].[STATION_BUSES]
    ([Stations_Fk]);
GO

-- Creating foreign key on [Landmark_FK] in table 'LANDMARK_KNOWN_AS'
ALTER TABLE [dbo].[LANDMARK_KNOWN_AS]
ADD CONSTRAINT [FK_LANDMARK_KNOWN_AS_LANDMARKs]
    FOREIGN KEY ([Landmark_FK])
    REFERENCES [dbo].[LANDMARKs]
        ([Landmark_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LANDMARK_KNOWN_AS_LANDMARKs'
CREATE INDEX [IX_FK_LANDMARK_KNOWN_AS_LANDMARKs]
ON [dbo].[LANDMARK_KNOWN_AS]
    ([Landmark_FK]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------