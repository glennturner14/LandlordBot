
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.PropertyType') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.PropertyType(
    PropertyTypeId				INT             NOT NULL,
    Name						varchar(100)	NOT NULL,
	CCHIdentifier				VARCHAR(200)	NULL,
    CONSTRAINT PK_PropertyType PRIMARY KEY CLUSTERED (PropertyTypeId)
)
GO


