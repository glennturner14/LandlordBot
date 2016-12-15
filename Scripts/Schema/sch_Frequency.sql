
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Frequency') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Frequency(
    FrequencyId				    INT					NOT NULL,
    Name						VARCHAR(100)		NOT NULL,
	CCHIdentifier				VARCHAR(200)		NULL,
    CONSTRAINT PK_Frequency PRIMARY KEY CLUSTERED (FrequencyId)
)
GO


