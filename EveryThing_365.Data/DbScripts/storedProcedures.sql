use [EveryThing_365];

---------------------------------------------12-04-23--------------------------------------------------------

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE GetProductCategories
AS
BEGIN
	SET NOCOUNT ON;
	select * from product_category;
END

---------------------------------------------12-04-23----------------------------------------------------------
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddCustomer
@first_name VARCHAR(30),
@last_name VARCHAR(30),
@password VARCHAR(50),
@email_address VARCHAR(50),
@phone_number VARCHAR(20),
@created_at DATETIME
AS
DECLARE @customer_id AS INT;
BEGIN
  SET NOCOUNT ON;

  INSERT INTO customer(first_name, last_name, password, email_address, phone_number, created_at) 
  VALUES(@first_name, @last_name, @password, @email_address, @phone_number, @created_at) 

  SET @customer_id = (SELECT SCOPE_IDENTITY());

  SELECT @customer_id as customer_id;

END

---------------------------------------------12-04-23----------------------------------------------------------
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddCustomerAddress
@customer_id INT,
@address_line1 VARCHAR(300),
@address_line2 VARCHAR(300),
@city VARCHAR(50),
@postal_code VARCHAR(50),
@country_id INT,
@is_default BIT
AS
BEGIN
	INSERT INTO customer_address(customer_id, address_line1, address_line2, city, postal_code, country_id, is_default)
	VALUES(@customer_id, @address_line1, @address_line2, @city, @postal_code, @country_id, @is_default)
END

---------------------------------------------12-04-23----------------------------------------------------------
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE AddCustomerCart
@customer_id INT
AS
BEGIN
	INSERT INTO shopping_cart(customer_id)
	VALUES(@customer_id)
END

