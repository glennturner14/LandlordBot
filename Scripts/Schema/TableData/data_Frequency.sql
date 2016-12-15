if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 1 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 1, 'Annually', 'Annually')

if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 2 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 2, 'Monthly', 'Monthly')

if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 3 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 3, 'Weekly', 'Weekly')

if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 4 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 4, 'Other', 'Other')

GO
