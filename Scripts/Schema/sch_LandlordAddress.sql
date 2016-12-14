IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.LandlordAddress') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.LandlordAddress(
	AddressId INT NOT NULL,
	AddressTypeId SMALLINT NOT NULL,
	LandlordId INT NOT NULL,
 CONSTRAINT PK_LandlordAddress PRIMARY KEY CLUSTERED (AddressId, AddressTypeId, LandlordId),
 CONSTRAINT FK_LandlordAddress_Address FOREIGN KEY (AddressId) REFERENCES dbo.Address(AddressId),
 CONSTRAINT FK_LandlordAddress_AddressType FOREIGN KEY (AddressTypeId) REFERENCES dbo.AddressType(AddressTypeId),
 CONSTRAINT FK_LandlordAddress_Landlord FOREIGN KEY (LandlordId) REFERENCES dbo.Landlord(LandlordId)
)
GO


