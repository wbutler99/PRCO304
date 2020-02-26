CREATE TABLE PRODUCTS (
    product_id INT 
        CONSTRAINT products_product_id_pk PRIMARY KEY IDENTITY
        CONSTRAINT products_product_id_nn NOT NULL,
    product_type VARCHAR (50)
        CONSTRAINT products_product_type_nn NOT NULL,
    product_description VARCHAR (200)
        CONSTRAINT products_product_description_nn NOT NULL
);