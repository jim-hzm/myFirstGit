CREATE TABLE [dbo].[positions] (
    [Id]        INT             IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [keyName]   VARCHAR (15)    NULL,
    [Lat]       NUMERIC (18, 6) NULL,
    [Lng]       NUMERIC (18, 6) NULL,
    [dateStamp] DATETIME        NULL,
    CONSTRAINT [PK__position__3214EC076235412F] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_positions_keyName]
    ON [dbo].[positions]([keyName] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'keyname index', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'positions', @level2type = N'INDEX', @level2name = N'IX_positions_keyName';

