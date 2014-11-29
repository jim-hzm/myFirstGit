CREATE PROCEDURE [dbo].[positions_selectct_by_id]
	@keyName varchar(15) = ''
AS
	SELECT * from positions where keyName=@keyName
RETURN 0