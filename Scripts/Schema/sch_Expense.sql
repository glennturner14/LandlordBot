
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Expense') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Expense(
    ExpenseId				INT						IDENTITY(1,1),
	PropertyId				INT						NOT NULL,
    Description				varchar(MAX)			NOT NULL,
	Date					SMALLDATETIME			NOT NULL,
	Amount					MONEY					NOT NULL,
	IsRepeatingCost			BIT						CONSTRAINT DF_Expense_IsRepeatingCost Default 0 NOT NULL
    CONSTRAINT PK_Expense PRIMARY KEY CLUSTERED (ExpenseId),
	CONSTRAINT FK_Expense_Property FOREIGN KEY (PropertyId) REFERENCES dbo.Property(PropertyId)

)
GO
