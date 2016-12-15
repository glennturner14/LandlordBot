SET QUOTED_IDENTIFIER on 
GO
SET ansi_nulls on 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreateExpense]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CreateExpense]
GO

Create Procedure [dbo].[CreateExpense]

	@PropertyId AS INT,
	@Description VARCHAR(MAX),
	@Date AS SMALLDATETIME,
	@Amount AS MONEY

AS

	INSERT INTO dbo.Expense
	        (
			  PropertyId ,
	          Description ,
	          Date ,
	          Amount 
	        )
	VALUES
	        (
			  @PropertyId ,
	          @Description , -- Description - varchar(max)
	          @Date , -- Date - smalldatetime
	          @Amount -- Amount - money
	        )


GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO