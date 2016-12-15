
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Property') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Property(
    PropertyId				    INT              IDENTITY(1,1),
	AddressId					INT				 NOT NULL,
	PropertyTypeId				INT				 NOT NULL,
    Name						varchar(100)     NOT NULL,
    CONSTRAINT PK_Property PRIMARY KEY CLUSTERED (PropertyId),
	CONSTRAINT FK_Property_Address FOREIGN KEY (AddressId) REFERENCES dbo.Address(AddressId),
	CONSTRAINT FK_Property_PropertyType FOREIGN KEY (PropertyTypeId) REFERENCES dbo.PropertyType(PropertyTypeId),
)
GO


