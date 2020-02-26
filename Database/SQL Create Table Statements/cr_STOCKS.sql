CREATE TABLE STOCKS (
    stock_id INT
        CONSTRAINT stocks_stock_id_pk PRIMARY KEY IDENTITY
        CONSTRAINT stocks_stock_id_nn NOT NULL,
    stock_shop_id INT
       CONSTRAINT stocks_stock_shop_id_fk
            FOREIGN KEY  (stock_shop_id) REFERENCES dbo.SHOPS(shop_id)
        CONSTRAINT stocks_stock_shop_id_nn NOT NULL,
    stock_product_id INT
        CONSTRAINT stocks_stock_product_id_fk
            FOREIGN KEY  (stock_product_id) REFERENCES dbo.PRODUCTS(product_id)
        CONSTRAINT stocks_stock_product_id_nn NOT NULL,
    stock_quantity INT
        CONSTRAINT stocks_stock_quantity_nn NOT NULL
);