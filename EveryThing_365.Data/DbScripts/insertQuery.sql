use [EveryThing_365];

-----------------------------------------------------------------12-04-23----------------------------------------------------------------------

SET IDENTITY_INSERT product_category ON;
Insert into product_category(category_id, category_name) values(1,'Beverages');
Insert into product_category(category_id, parent_category_id, category_name) values(2, 1,'Tea');
Insert into product_category(category_id, parent_category_id, category_name) values(3, 1,'Coffee');
Insert into product_category(category_id, parent_category_id, category_name) values(4, 1,'Energy & Soft Drink');
Insert into product_category(category_id, parent_category_id, category_name) values(5, 1,'Health Drink & Supplement');
Insert into product_category(category_id, category_name) values(6,'Baby Care');
Insert into product_category(category_id, parent_category_id, category_name) values(7, 6,'Diapers & Wipes');
Insert into product_category(category_id, parent_category_id, category_name) values(8, 6,'Baby Bath & Hygiene');
Insert into product_category(category_id, parent_category_id, category_name) values(9, 6,'Feeding & Nursing');
Insert into product_category(category_id, parent_category_id, category_name) values(10, 6,'Baby Accessories');
Insert into product_category(category_id, category_name) values(11,'snacks');
Insert into product_category(category_id, parent_category_id, category_name) values(12, 11,'Chocolates & Candies');
Insert into product_category(category_id, parent_category_id, category_name) values(13, 11,'Noodle & Pasta');
Insert into product_category(category_id, parent_category_id, category_name) values(14, 11,'Breakfast Cereals');
Insert into product_category(category_id, parent_category_id, category_name) values(15, 11,'Biscuilts & Cookies');
Insert into product_category(category_id, category_name) values(16,'Men shoes');
Insert into product_category(category_id, parent_category_id, category_name) values(17, 16,'Clogs');
Insert into product_category(category_id, parent_category_id, category_name) values(18, 16,'Causal shoes');
Insert into product_category(category_id, parent_category_id, category_name) values(19, 16,'Formal Shoes');
Insert into product_category(category_id, parent_category_id, category_name) values(20, 16,'Sport Shoes');
SET IDENTITY_INSERT product_category OFF;
----------------------------------------------------------------12-04-23----------------------------------------------------------------------------------------------

SET IDENTITY_INSERT country on;
Insert into country(country_id, country_name) values(1, 'India');
SET IDENTITY_INSERT country off;

-------------------------------------------------------------18-04-23---------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT supplier on;
Insert into supplier(supplier_id, first_name, last_name, password, email_address, phone_number, created_at)
VaLUES(1, 'Shiv', 'Shankar', 'Admin@123', 'shiv@gmail.com', '8080897878', '2023-04-18T06:48:53.292Z');
SET IDENTITY_INSERT supplier off;

-------------------------------------------------------------18-04-23---------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT store on;
Insert into store(store_id, store_name, supplier_id) Values (1, 'shiv convenience store', 1);
SET IDENTITY_INSERT store off;

-----------------------------------------------------------18-04-23-------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT store_address on;
Insert into store_address(address_id, address_line1, address_line2, city, postal_code, country_id)
Values(1, 'shop no 8, mulund colony, near jonson & jonson', 'LBS road, mulund west', 'mumbai', '400042', 1);
SET IDENTITY_INSERT store_address off;

-----------------------------------------------------------18-04-23-------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT variation on;
Insert into variation(variation_id, value)Values(1,'Size');
Insert into variation(variation_id, value)Values(2,'Color');
Insert into variation(variation_id, value)Values(3,'Materail');
Insert into variation(variation_id, value)Values(4,'Style');
SET IDENTITY_INSERT variation off;

--------------------------------------------------------------18-04-23-----------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT Product on;
INSERT INTO product(product_id, category_id, store_id, title, description)
values(1, 17, 1, 'Crocs', 'Crocsband glogs');
SET IDENTITY_INSERT Product off;

--------------------------------------------------------------18-04-23-----------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT Product_varaint on;
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(1,1, 'Crocs (black, size 1)', 3250.70, '#1');
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(2,1, 'Crocs(blue, size 1)', 3000.80, '#2');
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(3,1, 'Crocs (black, size 2)', 2250.0, '#3');
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(4,1, 'Crocs(blue, size 2)', 2750.0, '#4');
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(5,1, 'Crocs (black, size 3)', 4250.23, '#5');
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(6,1, 'Crocs(blue, size 3)', 4500.0, '#6');
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(7,1, 'Crocs (black, size 4)' ,4500.13, '#7');
insert into product_varaint(product_varaint_id, product_id, title, price, sku)
values(8,1, 'Crocs(blue, size 4)', 5000.0, '#8');
SET IDENTITY_INSERT Product_varaint off;

--------------------------------------------------------------18-04-23-----------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT Product_option on;
insert into product_option(product_option_id, product_id, variation_id, option_value, position)
values(1,1,2,'black', 1);
insert into product_option(product_option_id, product_id, variation_id, option_value, position)
values(2,1,2,'blue', 2);
insert into product_option(product_option_id, product_id, variation_id, option_value, position)
values(3,1,1,'1', 1);
insert into product_option(product_option_id, product_id, variation_id, option_value, position)
values(4,1,1,'2', 2);
insert into product_option(product_option_id, product_id, variation_id, option_value, position)
values(5,1,1,'3', 3);
insert into product_option(product_option_id, product_id, variation_id, option_value, position)
values(6,1,1,'4', 4);
SET IDENTITY_INSERT Product_option off;

--------------------------------------------------------------18-04-23-----------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT product_configration on;
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(1,1,1);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(2,1,3);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(3,2,2);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(4,2,3);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(5,3,1);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(6,3,4);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(8,4,2);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(9,4,4);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(10,5,1);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(11,5,5);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(12,6,2);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(13,6,5);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(14,7,1);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(15,7,6);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(16,8,2);
insert into product_configration(product_configration_id, product_varaint_id, product_option_id)
values(17,8,6);
SET IDENTITY_INSERT product_configration off;

--------------------------------------------------------------18-04-23-----------------------------------------------------------------------------------------------------
