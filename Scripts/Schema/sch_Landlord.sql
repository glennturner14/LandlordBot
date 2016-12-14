
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Landlord') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Landlord(
    LandlordId				    INT              IDENTITY(1,1),
    Name						varchar(100)     NOT NULL,
    CONSTRAINT PK_Landlord PRIMARY KEY CLUSTERED (LandlordId)
)
GO


