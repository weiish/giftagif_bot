IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNextGifIdentifier]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP procedure [dbo].[GetNextGifIdentifier]
END