CREATE TABLE [dbo].[IpAddress](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ip] [varchar](15) NULL,
	[dateStamp] [datetime] NULL,
 CONSTRAINT [PK__IpAddress__id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Index [IX_positions_keyName]    Script Date: 11/18/2014 10:24:47 ******/
CREATE NONCLUSTERED INDEX [IX_IpAddress_dateStamp] ON [dbo].[IpAddress] 
(
	[dateStamp] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'dateStamp index' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IpAddress', @level2type=N'INDEX',@level2name=N'IX_IpAddress_dateStamp'
GO



go