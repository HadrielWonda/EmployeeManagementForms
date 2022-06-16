IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PKGen]') AND type in (N'U'))
DROP TABLE [dbo].[PKGen]
GO

CREATE TABLE [dbo].[PKGen](
	[DomainName] [nvarchar](20) NOT NULL,
	[Value] [bigint] NOT NULL,
 CONSTRAINT [PK_PKGen] PRIMARY KEY CLUSTERED 
(
	[DomainName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [BauMax_TestGUI].[dbo].[PKGen]
           ([DomainName]
           ,[Value])
     VALUES
           ('Entities'
           ,1000)
GO
