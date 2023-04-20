use [EveryThing_365];

-----------------------------------------------------11-04-23-----------------------------------------------------------
CREATE TABLE customer
(
  customer_id INT IDENTITY(1,1) NOT NULL,
  first_name VARCHAR(30) DEFAULT NULL,
  last_name VARCHAR(30) DEFAULT NULL,
  password VARCHAR(50) DEFAULT NULL,
  email_address VARCHAR(50) DEFAULT NULL UNIQUE,
  phone_number VARCHAR(20) DEFAULT NULL UNIQUE,
  created_at DATETIME DEFAULT NULL,
  modified_at DATETIME DEFAULT NULL,
  PRIMARY KEY(customer_id)
);

CREATE TABLE country
(
  country_id INT IDENTITY(1,1) NOT NULL,
  country_name VARCHAR(50) DEFAULT NULL UNIQUE,
  PRIMARY KEY(country_id)
);


---------------------------------------------------------------11-04-23---------------------------------------------------------

CREATE TABLE customer_address
(
    address_id INT IDENTITY(1,1) NOT NULL,
	customer_id INT DEFAULT NULL,
	address_line1 VARCHAR(300) DEFAULT NULL,
	address_line2 VARCHAR(300) DEFAULT NULL,
	city VARCHAR(50) DEFAULT NULL,
	postal_code VARCHAR(50) DEFAULT NULL,
	country_id INT DEFAULT NULL,
	is_default BIT DEFAULT NULL,
	FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
	FOREIGN KEY(country_id) REFERENCES country(country_id),
	PRIMARY KEY(address_id),
);


------------------------------------------------------------------11-04-23------------------------------------------------------

CREATE TABLE supplier
(
  supplier_id INT IDENTITY(1,1) NOT NULL,
  first_name VARCHAR(30) DEFAULT NULL,
  last_name VARCHAR(30) DEFAULT NULL,
  password VARCHAR(50) DEFAULT NULL,
  email_address VARCHAR(50) DEFAULT NULL UNIQUE,
  phone_number VARCHAR(20) DEFAULT NULL UNIQUE,
  created_at DATETIME DEFAULT NULL,
  modified_at DATETIME DEFAULT NULL,
  PRIMARY KEY(supplier_id)
);


----------------------------------------------------------------------11-04-23--------------------------------------------------

CREATE TABLE store
(
	store_id INT IDENTITY(1,1) NOT NULL,
	supplier_id INT DEFAULT NULL,
	store_name VARCHAR(50) DEFAULT NULL,
	FOREIGN KEY(supplier_id) REFERENCES supplier(supplier_id),
	PRIMARY KEY(store_id)
);


----------------------------------------------------------------------11-04-23--------------------------------------------------

CREATE TABLE store_address
(
	address_id INT IDENTITY(1,1) NOT NULL,
	store_id INT DEFAULT NULL,
	address_line1 VARCHAR(300) DEFAULT NULL,
	address_line2 VARCHAR(300) DEFAULT NULL,
	city VARCHAR(50) DEFAULT NULL,
	postal_code VARCHAR(50) DEFAULT NULL,
	country_id INT DEFAULT NULL,
	FOREIGN KEY(store_id) REFERENCES store(store_id),
	FOREIGN KEY(country_id) REFERENCES country(country_id),
	PRIMARY KEY(address_id),
);


------------------------------------------------------------------------11-04-23------------------------------------------------

CREATE TABLE product_category
(
	category_id INT IDENTITY(1,1) NOT NULL,
	parent_category_id INT DEFAULT NULL,
	category_name VARCHAR(50) DEFAULT NULL UNIQUE,
	FOREIGN KEY(parent_category_id) REFERENCES product_category(category_id),
	PRIMARY KEY(category_id)
);
-------------------------------------------------------------------------11-04-23-----------------------------------------------

CREATE TABLE variation
(
	variation_id INT IDENTITY(1,1) NOT NULL,
	value VARCHAR(100) DEFAULT NULL UNIQUE,
	PRIMARY KEY(variation_id)
);

-------------------------------------------------------------------------11-04-23-----------------------------------------------

CREATE TABLE product
(
	product_id INT IDENTITY(1,1) NOT NULL,
	category_id INT DEFAULT NULL,
	store_id INT DEFAULT NULL,
	title VARCHAR(50) DEFAULT NULL,
	description VARCHAR(300) DEFAULT NULL,
	FOREIGN KEY(category_id) REFERENCES product_category(category_id),
	FOREIGN KEY(store_id) REFERENCES store(store_id),
	PRIMARY KEY(product_id)
);

-------------------------------------------------------------------------11-04-23-----------------------------------------------

CREATE TABLE product_varaint
(
	product_varaint_id INT IDENTITY(1,1) NOT NULL,
	product_id  INT DEFAULT NULL,
	title VARCHAR(200) DEFAULT NULL,
	price DECIMAL DEFAULT 0,
	sku VARCHAR(100) DEFAULT NULL UNIQUE,
	FOREIGN KEY(product_id) REFERENCES product(product_id),
	PRIMARY KEY(product_varaint_id),
);
-------------------------------------------------------------------------11-04-23-----------------------------------------------

CREATE TABLE product_option
(
	product_option_id INT IDENTITY(1,1) NOT NULL,
	product_id  INT DEFAULT NULL,
	variation_id INT DEFAULT NULL,
	option_value varchar(100) DEFAULT Null,
	position INT DEFAULT NULL,
	FOREIGN KEY(product_id) REFERENCES product(product_id),
	FOREIGN KEY(variation_id) REFERENCES variation(variation_id),
	PRIMARY KEY(product_option_id),
	Unique(variation_id, option_value),
);

-------------------------------------------------------------------------11-04-23-----------------------------------------------

CREATE TABLE product_configration
(
    product_configration_id INT IDENTITY(1,1) NOT NULL,
	product_varaint_id INT DEFAULT NULL,
	product_option_id  INT DEFAULT NULL,
	FOREIGN KEY(product_varaint_id) REFERENCES product_varaint(product_varaint_id),
	FOREIGN KEY(product_option_id) REFERENCES product_option(product_option_id),
	PRIMARY KEY(product_configration_id),
	Unique(product_option_id, product_varaint_id),
);

-----------------------------------------------------------------------11-04-23-----------------------------------------------

CREATE TABLE shopping_cart
(
	cart_id INT IDENTITY(1,1) NOT NULL,
	customer_id INT DEFAULT NULL UNIQUE,
	FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
	PRIMARY KEY(cart_id)
);


-----------------------------------------------------------------------11-04-23-------------------------------------------------

CREATE TABLE shopping_cart_item
(
	cart_item_id INT IDENTITY(1,1) NOT NULL,
	cart_id INT DEFAULT NULL,
	product_varaint_id INT DEFAULT NULL,
	quantity INT DEFAULT NULL,
	FOREIGN KEY(cart_id) REFERENCES shopping_cart(cart_id),
	FOREIGN KEY(product_varaint_id) REFERENCES product_varaint(product_varaint_id),
	PRIMARY KEY(cart_item_id)
);


--------------------------------------------------------------------11-04-23----------------------------------------------------

CREATE TABLE payment_type
(
  payment_type_id INT IDENTITY(1,1) NOT NULL,
  payment_value VARCHAR(50) DEFAULT NULL,
  PRIMARY KEY(payment_type_id)
);

------------------------------------------------------------------11-04-23------------------------------------------------------

CREATE TABLE customer_payment
(
	payment_id INT IDENTITY(1,1) NOT NULL,
	customer_id INT DEFAULT NULL,
	payment_type_id INT DEFAULT NULL,
	payment_provider VARCHAR(30) DEFAULT NULL,
	account_number VARCHAR(100) DEFAULT NULL,
	"expiry_date" DATE DEFAULT NULL,
	is_default BIT DEFAULT NULL,
	FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
	FOREIGN KEY(payment_type_id) REFERENCES payment_type(payment_type_id),
	PRIMARY KEY(payment_id)
);

------------------------------------------------------------------11-04-23----------------------------------------------------

CREATE TABLE order_status 
(
	status_id INT IDENTITY(1,1) NOT NULL,
	order_value VARCHAR(30) DEFAULT NULL, 
	PRIMARY KEY(status_id),
);


--------------------------------------------------------------------11-04-23----------------------------------------------------

CREATE TABLE customer_order
(
	order_id INT IDENTITY(1,1) NOT NULL,
	customer_id INT DEFAULT NULL,
	product_varaint_id INT DEFAULT NULL,
	quantity INT DEFAULT NULL,
	payment_id INT DEFAULT NULL,
	shipping_id INT DEFAULT NULL,
	total_price INT DEFAULT NULL, 
	order_date DATETIME DEFAULT NULL,
	order_status_id INT DEFAULT NULL, 
	FOREIGN KEY(customer_id) REFERENCES customer(customer_id),
	FOREIGN KEY(product_varaint_id) REFERENCES product_varaint(product_varaint_id),
	FOREIGN KEY(payment_id) REFERENCES customer_payment(payment_id),
	FOREIGN KEY(shipping_id) REFERENCES customer_address(address_id),
	FOREIGN KEY(order_status_id) REFERENCES order_status(status_id),
	PRIMARY KEY(order_id)
);

------------------------------------------------------------------------------------------------------------------------













