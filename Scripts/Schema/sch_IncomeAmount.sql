
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.IncomeAmount') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.IncomeAmount(
    IncomeId				INT						NOT NULL,
	StartDate				SMALLDATETIME			NOT NULL,
	EndDate					SMALLDATETIME			NULL,
	Amount					MONEY					NOT NULL,
    CONSTRAINT PK_IncomeAmount PRIMARY KEY CLUSTERED (IncomeId, StartDate),
	CONSTRAINT FK_IncomeAmount_Income FOREIGN KEY (IncomeId) REFERENCES dbo.Income(IncomeId)
)
GO


