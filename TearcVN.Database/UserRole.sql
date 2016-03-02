﻿CREATE TABLE [dbo].[UserRole]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(100) NULL,
	[Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL DEFAULT GETDATE(),
)
