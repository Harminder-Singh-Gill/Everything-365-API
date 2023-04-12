use [Everything 365];

---------------------------------------------12-04-23--------------------------------------------------------

CREATE PROCEDURE GetProductCategories
AS
BEGIN
	SET NOCOUNT ON;
	select * from product_category;
END
GO

-------------------------------------------------------------------------------------------------------