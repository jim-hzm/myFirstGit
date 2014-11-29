CREATE PROCEDURE [dbo].[positions_add]
	@Id int = 0,
	@keyName varchar(20),
	@Lat decimal(18,6),
	@Lng decimal(18,6),
	@dateStamp datetime
AS
   insert positions(keyName, Lat, Lng, dateStamp)
   select @keyName, @Lat, @Lng, @dateStamp               

RETURN @@error