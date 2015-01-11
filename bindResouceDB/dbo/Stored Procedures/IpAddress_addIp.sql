CREATE PROCEDURE [dbo].[IpAddress_addIp]
	@ip varchar(15)
AS
	insert IpAddress(ip, dateStamp)
	SELECT ip, GETDATE()
RETURN 0
