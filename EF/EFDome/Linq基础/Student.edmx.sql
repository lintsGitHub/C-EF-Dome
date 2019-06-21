
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2019 14:56:24
-- Generated from EDMX file: D:\个人C#\DOME\EF\EFDome\Linq基础\Student.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SchoolDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StudentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StudentSets'
CREATE TABLE [dbo].[StudentSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [stuID] nvarchar(max)  NOT NULL,
    [ClassName] nvarchar(max)  NOT NULL,
    [ClassNum] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StudentSets'
ALTER TABLE [dbo].[StudentSets]
ADD CONSTRAINT [PK_StudentSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------