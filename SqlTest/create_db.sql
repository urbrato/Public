CREATE TABLE Categories (
    ID INT PRIMARY KEY IDENTITY (1, 1),
    Name VARCHAR (50) NOT NULL
);

CREATE TABLE Products_Categories (
    Product_ID INT NOT NULL,
    Category_ID INT NOT NULL
);