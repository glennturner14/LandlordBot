IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Address') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Address(
	AddressId INT IDENTITY(1,1) NOT NULL,
	AddressLine1 NVARCHAR(50) NULL,
	AddressLine2 NVARCHAR(50) NULL,
	AddressLine3 NVARCHAR(50) NULL,
	Town NVARCHAR(50) NULL,
	County NVARCHAR(50) NULL,
	PostCode NVARCHAR(50) NULL,
	Country NVARCHAR(50) NULL
 CONSTRAINT PK_Address PRIMARY KEY CLUSTERED (AddressId)
)
GO

