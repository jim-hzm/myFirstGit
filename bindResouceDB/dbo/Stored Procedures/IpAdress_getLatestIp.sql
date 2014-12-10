CREATE PROCEDURE [dbo].[IpAdress_getLatestIp]
AS
	SELECT top 1 Id, ip, dateStamp from IpAddress order by 1 desc
RETURN 0
