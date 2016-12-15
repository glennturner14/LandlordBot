
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'dbo.ExpenseCategory') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
CREATE TABLE dbo.ExpenseCategory(
    ExpenseCategoryId			INT						NOT NULL,
    Name						VARCHAR(100)			NOT NULL,
	CCHIdentifier				VARCHAR(200)			NULL,
    CONSTRAINT PK_ExpenseCategory PRIMARY KEY CLUSTERED (ExpenseCategoryId)
)
GO


