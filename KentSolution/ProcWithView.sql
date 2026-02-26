
CREATE PROCEDURE GetTopRecords 
	@records int
AS
BEGIN
	SELECT top(@records)* FROM vw_ECommerceAnalytics;
END
GO
