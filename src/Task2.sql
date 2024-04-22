CREATE TABLE Categories (
    Id INT PRIMARY KEY,
    CategoryName NVARCHAR(100)
);

CREATE TABLE Products (
    Id INT PRIMARY KEY,
    ProductName NVARCHAR(100)
);

CREATE TABLE ProductCategories (
    ProductId INT,
    CategoryId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
);

INSERT INTO Categories (Id, CategoryName)
VALUES
    (1, 'Electronics'),
    (2, 'Clothing'),
    (3, 'Books');

INSERT INTO Products (Id, ProductName)
VALUES
    (1, 'Smartphone'),
    (2, 'Laptop'),
    (3, 'T-shirt'),
    (4, 'Jeans'),
    (5, 'Novel');

INSERT INTO ProductCategories (ProductId, CategoryId)
VALUES
    (1, 1),
    (2, 1),
    (3, 2),
    (4, 2),
    (5, 3),
    (1, 2),
    (2, 2),
    (3, 1),
    (4, 1),
    (5, 2);
   
-- Without categories.
INSERT INTO Products (Id, ProductName)
VALUES
    (6, 'Smartphone'),
    (7, 'Laptop'),
    (8, 'T-shirt'),
    (9, 'Jeans'),
    (10, 'Novel');

SELECT p.ProductName, ISNULL(c.CategoryName, 'No Category') AS CategoryName
FROM Products p
LEFT JOIN ProductCategories pc ON p.Id = pc.ProductID
LEFT JOIN Categories c ON pc.CategoryID = c.Id