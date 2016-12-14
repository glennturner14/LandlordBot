IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.AddressType') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.AddressType(
	AddressTypeId SMALLINT IDENTITY(1,1) NOT NULL,
	AddressTypeDesc VARCHAR(50) NOT NULL,
	CONSTRAINT PK_AddressType PRIMARY KEY CLUSTERED (AddressTypeId)
)
GO


