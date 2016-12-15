if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 1 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 1, 'Weekly', 'Weekly')

if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 2 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 2, 'Monthly', 'Monthly')

IF not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 3 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 3, 'Quarterly', 'Quarterly')

if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 4 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 4, 'Annually', 'Annually')

if not exists ( select * from dbo.Frequency f WHERE f.FrequencyId = 5 )
	INSERT INTO dbo.Frequency ( FrequencyId, Name, CCHIdentifier ) VALUES  ( 5, 'Other', 'Other')

GO
