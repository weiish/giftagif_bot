Create Procedure [dbo].[GetNextGifIdentifier]
As
BEGIN
Select next value for dbo.GifIdentifier;
END

