SET QUOTED_IDENTIFIER on 
GO
SET ansi_nulls on 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreateIncome]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CreateIncome]
GO

Create Procedure [dbo].[CreateIncome]

	@PropertyId AS INT,
	@StartDate AS SMALLDATETIME,
	@FrequencyId AS INT,
	@Amount AS MONEY,
	@EndDate AS SMALLDATETIME = NULL

AS

	DECLARE @IncomeId INT

	INSERT INTO dbo.Income
	        (
			  PropertyId,
	          Description ,
	          FrequencyId
	        )
	VALUES
	        (
			  @PropertyId ,
	          '' , -- Description - varchar(max)
	          @FrequencyId  -- FrequencyId - int
	        )
	
	SET @IncomeId = SCOPE_IDENTITY()

	DECLARE @month INT = 0;

	WHILE @month < 12
	BEGIN
		INSERT INTO dbo.IncomeAmount
				(
				  IncomeId ,
				  StartDate ,
				  EndDate ,
				  Amount
				)
		VALUES
				(
				  @IncomeId , -- IncomeId - int
				  DATEADD(MONTH, @month, @StartDate) , -- StartDate - smalldatetime
				  NULL , -- EndDate - smalldatetime
				  @Amount  -- Amount - money
				)
	   SET @month = @month + 1;
	END;



GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO