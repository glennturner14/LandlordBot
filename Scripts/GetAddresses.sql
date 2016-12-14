SET QUOTED_IDENTIFIER on 
GO
SET ansi_nulls on 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAddresses]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAddresses]
GO

Create Procedure [dbo].[GetAddresses]

As

	Select
		la.AddressTypeId,
		a.AddressId,
		isnull(AddressLine1,'') as Line1,
		isnull(AddressLine2,'') as Line2,
		isnull(AddressLine3,'') as Line3,
		isnull(Town,'') as Town,
		isnull(County,'') as County,
		isnull(PostCode,'') as PostCode,
		isnull(Country,'') as Country,
		AddressTypeDesc
	
	From
		dbo.Address a
		INNER JOIN dbo.LandlordAddress la ON la.AddressId = a.AddressId						
		INNER JOIN dbo.AddressType at ON at.AddressTypeId = la.AddressTypeId
	--Where
	--	la.LandlordId = @LandlordId

	Order By 

		at.AddressTypeDesc DESC

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO