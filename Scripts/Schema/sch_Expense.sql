
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.Expense') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.Expense(
    ExpenseId				INT						IDENTITY(1,1),
    Description				varchar(MAX)			NOT NULL,
	Date					SMALLDATETIME			NOT NULL,
	ExpenseCategoryId		INT						NULL,
	Amount					MONEY					NOT NULL,
	IsRepeatingCost			BIT						CONSTRAINT DF_Expense_IsRepeatingCost Default 0 NOT NULL,
	FrequencyId				INT						NOT NULL,
    CONSTRAINT PK_Expense PRIMARY KEY CLUSTERED (ExpenseId),
	CONSTRAINT FK_Expense_ExpenseCategory FOREIGN KEY (ExpenseCategoryId) REFERENCES dbo.ExpenseCategory(ExpenseCategoryId),
	CONSTRAINT FK_Expense_ExpenseFrequency FOREIGN KEY (FrequencyId) REFERENCES dbo.Frequency(FrequencyId),

)
GO


