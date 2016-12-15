if not exists ( select * from dbo.PropertyType f WHERE f.PropertyTypeId = 1 )
	INSERT INTO dbo.PropertyType ( PropertyTypeId, Name, CCHIdentifier ) VALUES  ( 1, 'UK Property', 'UKProperty')

if not exists ( select * from dbo.PropertyType f WHERE f.PropertyTypeId = 2 )
	INSERT INTO dbo.PropertyType ( PropertyTypeId, Name, CCHIdentifier ) VALUES  ( 2, 'UK Furnished Holiday Let', 'UKFurnishedHolidayLet')

if not exists ( select * from dbo.PropertyType f WHERE f.PropertyTypeId = 3 )
	INSERT INTO dbo.PropertyType ( PropertyTypeId, Name, CCHIdentifier ) VALUES  ( 3, 'EEA Furnished Holiday Let', 'EEAFurnishedHolidayLet')
GO
