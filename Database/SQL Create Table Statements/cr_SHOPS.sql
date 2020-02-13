CREATE TABLE SHOPS(
    shop_id INT
        CONSTRAINT shops_shop_id_pk PRIMARY KEY,
    shop_name VARCHAR (50),
    shop_address_line_one VARCHAR (50)
        CONSTRAINT shops_shop_address_line_one_nn NOT NULL,
    shop_address_line_two VARCHAR (50),
    shop_postcode VARCHAR (8)
        CONSTRAINT shops_shop_postcode_nn NOT NULL
);