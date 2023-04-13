use [Everything 365];

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
SET IDENTITY_INSERT product_category OFF;

----------------------------------------------------------------12-04-23----------------------------------------------------------------------------------------------
SET IDENTITY_INSERT country on;
Insert into country(country_id, country_name) values(1, 'India');
SET IDENTITY_INSERT country off;