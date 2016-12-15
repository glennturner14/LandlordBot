		  INSERT INTO dbo.Address
		          (
		            AddressLine1 ,
		            AddressLine2 ,
		            AddressLine3 ,
		            Town ,
		            County ,
		            PostCode ,
		            Country
		          )
		  VALUES
		          (
		            N'145 London Road' , -- AddressLine1 - nvarchar(50)
		            N'Chichester House' , -- AddressLine2 - nvarchar(50)
		            N'London Rd' , -- AddressLine3 - nvarchar(50)
		            N'Kingston upon Thames' , -- Town - nvarchar(50)
		            N'Surrey' , -- County - nvarchar(50)
		            N'KT2 6SR' , -- PostCode - nvarchar(50)
		            N'England'  -- Country - nvarchar(50)
		          )