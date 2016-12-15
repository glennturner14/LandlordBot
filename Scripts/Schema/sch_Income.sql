
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Income') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Income(
    IncomeId				INT						IDENTITY(1,1),
    Description				varchar(MAX)			NOT NULL,
	PropertyId				INT						NOT NULL,
	FrequencyId				INT						NOT NULL,
	IsCashBasis				BIT						CONSTRAINT DF_Income_IsCashBasis Default 0 NOT NULL,
    CONSTRAINT PK_Income PRIMARY KEY CLUSTERED (IncomeId),
	CONSTRAINT FK_Income_IncomeFrequency FOREIGN KEY (FrequencyId) REFERENCES dbo.Frequency(FrequencyId),
	CONSTRAINT FK_Income_Property FOREIGN KEY (PropertyId) REFERENCES dbo.Property(PropertyId)
)
GO


