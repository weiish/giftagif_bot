IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GifIdentifier]') AND type = 'SO')
CREATE SEQUENCE [dbo].[GifIdentifier]
    AS INT
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    NO MAXVALUE