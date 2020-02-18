CREATE TABLE EMPLOYEES(
    employee_id INT
        CONSTRAINT employees_employee_id_pk PRIMARY KEY IDENTITY
        CONSTRAINT employees_employee_id_nn NOT NULL,
    employeee_first_name VARCHAR (35)
        CONSTRAINT employees_employee_first_name_nn NOT NULL,
    employee_last_name VARCHAR (35)
        CONSTRAINT employees_employee_last_name_nn NOT NULL,
    employee_username VARCHAR (15)
        CONSTRAINT employees_employee_username_nn NOT NULL
        CONSTRAINT employees_employee_username_un UNIQUE,
    employee_email_address VARCHAR (100)
        CONSTRAINT employees_employee_email_address_nn NOT NULL
        CONSTRAINT employees_employee_email_address_un UNIQUE,
    employee_date_of_birth DATE
        CONSTRAINT employees_employee_date_of_birth_nn NOT NULL,
    employee_address_line_one VARCHAR (50)
        CONSTRAINT employees_employee_address_line_one_nn NOT NULL,
    employee_address_line_two VARCHAR (50),
    employee_postcode VARCHAR (8)
        CONSTRAINT employees_employee_postcode_nn NOT NULL,
    employee_hashed_password VARCHAR (50)
        CONSTRAINT employees_employee_hashed_password_nn NOT NULL,
    employee_password_salt VARCHAR (100)
        CONSTRAINT employees_employee_password_salt_nn NOT NULL,
    job_role VARCHAR (20)
        CONSTRAINT employee_job_role_nn NOT NULL
        CONSTRAINT employee_job_role_chk
            CHECK(job_role IN ('Administrator', 'Manager', 'Sales')),
    employee_sort_code VARCHAR (8)
        CONSTRAINT employees_employee_sort_code_nn NOT NULL,
    employee_account_no VARCHAR (8)
        CONSTRAINT employees_employee_account_no_nn NOT NULL,
    employee_shop_id INT
        CONSTRAINT employees_employee_shop_id_fk
            FOREIGN KEY (employee_shop_id) REFERENCES dbo.SHOPS(shop_id)
);