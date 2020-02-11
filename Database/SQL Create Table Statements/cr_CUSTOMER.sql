CREATE TABLE CUSTOMERS(
    customer_id INT 
        CONSTRAINT customers_customer_id_pk PRIMARY KEY,
    username VARCHAR (50) 
        CONSTRAINT customers_username_un UNIQUE(username)
        CONSTRAINT customers_username_nn NOT NULL,
    email_address VARCHAR (62)
        CONSTRAINT customers_email_address_un UNIQUE
        CONSTRAINT customers_email_address_nn NOT NULL,
    customer_hashed_password VARCHAR (100)
        CONSTRAINT customers_customer_hashed_password_nn NOT NULL,
    password_salt VARCHAR (100)
        CONSTRAINT customers_password_salt_nn NOT NULL,
    first_name VARCHAR (35)
        CONSTRAINT customers_first_name_nn NOT NULL,
    last_name VARCHAR (35)
     CONSTRAINT customers_last_name_nn NOT NULL,
    date_of_birth DATE
        CONSTRAINT customers_date_of_birth_nn NOT NULL,
    address_line_one VARCHAR (50)
        CONSTRAINT customer_address_line_one_nn NOT NULL,
    address_line_two VARCHAR (50),
    postcode VARCHAR (8)
        CONSTRAINT customers_postcode_nn NOT NULL
);