SET QUOTED_IDENTIFIER on 
GO
SET ansi_nulls on 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetStatementLines]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetStatementLines]
GO

Create Procedure [dbo].[GetStatementLines]

As

(Select StartDate as [Date], [Description], Amount 
From dbo.Income i
Inner Join IncomeAmount ia On i.IncomeId = ia.IncomeId
Union
Select [Sate], [Description], -Amount 
From dbo.Expense)
Order By [Date]


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO