CREATE TABLE [dbo].[Estimation]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[ProjectId] INT NOT NULL,
	[FloorId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	[Number] INT NULL,
	[Active] BIT NULL DEFAULT 1,
	[CreatedTime] DATETIME NULL DEFAULT GETDATE(),
	[LastUpdatedTime] DATETIME NULL DEFAULT GETDATE(),
	[CreatedByUserID] INT NULL DEFAULT 1,
	[LastUpdatedByUserID] INT NULL DEFAULT 1,
	CONSTRAINT FK_Estimation_User FOREIGN KEY([CreatedByUserID]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT FK_Estimation_User_1 FOREIGN KEY([LastUpdatedByUserID]) REFERENCES [dbo].[User]([Id]),
	CONSTRAINT FK_Estimation_Project FOREIGN KEY([ProjectId]) REFERENCES [dbo].[Project]([Id]),
	CONSTRAINT FK_Estimation_Floor FOREIGN KEY([FloorId]) REFERENCES [dbo].[Floor]([Id]),
	CONSTRAINT FK_Estimation_Product FOREIGN KEY([ProductId]) REFERENCES [dbo].[Product]([Id]),
)
