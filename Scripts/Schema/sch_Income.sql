
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Income') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Income(
    IncomeId				INT						IDENTITY(1,1),
    Description				varchar(MAX)			NOT NULL,
	StartDate				SMALLDATETIME			NOT NULL,
	EndDate					SMALLDATETIME			NULL,
	FrequencyId				INT						NOT NULL,
	Amount					MONEY					NOT NULL,
	IsCashBasis				BIT						CONSTRAINT DF_Income_IsCashBasis Default 0 NOT NULL,
    CONSTRAINT PK_Income PRIMARY KEY CLUSTERED (IncomeId),
	CONSTRAINT FK_Income_IncomeFrequency FOREIGN KEY (FrequencyId) REFERENCES dbo.Frequency(FrequencyId)
)
GO


