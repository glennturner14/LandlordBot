if not exists ( select * from dbo.ExpenseCategory f WHERE f.ExpenseCategoryId = 1 )
	INSERT INTO dbo.ExpenseCategory ( ExpenseCategoryId, Name, CCHIdentifier ) VALUES  ( 1, 'Rent', 'Rent')

GO

