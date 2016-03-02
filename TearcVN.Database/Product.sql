﻿CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(100) NULL,
	[Brand] VARCHAR(50) NULL,
	[Code] VARCHAR(50) NULL,
	[Specification] VARCHAR(50) NULL,
	[Unit] VARCHAR(10) NULL,
	[Price] VARCHAR(10) NULL,
	[LaborCost] VARCHAR(10) NULL,
	[Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL DEFAULT GETDATE(),
	[CreatedByUserID] INT NULL DEFAULT 1,
	[LastUpdatedByUserID] INT NULL DEFAULT 1,
	CONSTRAINT FK_Product_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT FK_Product_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES [dbo].[User]([Id]),
)