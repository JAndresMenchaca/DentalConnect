SELECT *
FROM Product

INSERT INTO Product(name, description, price, stock, idCategory, idSupplier, idUSer)
VALUES(@name, @description, @price, @stock, @idCategory, @idSupplier, @idUSer)

SELECT CONCAT(c.name, ' ', c.id ) AS CATEGORIA, CONCAT(s.name, ' ', s.id ) AS PROVEEDOR
FROM Product p
INNER JOIN Category c ON c.id = p.idCategory
INNER JOIN Supplier s ON s.id = p.idSupplier


CREATE VIEW vwProduct
AS
SELECT p.id, p.name AS Nombre, p.description AS 'Descripción', p.price AS Precio, 
p.stock AS Stock, c.name AS 'Categoría', s.name AS Proveedor, 
p.registerDate AS 'Producto creado el:'
FROM Product p
INNER JOIN Category c ON c.id = p.idCategory
INNER JOIN Supplier s ON s.id = p.idSupplier
WHERE p.status = 1

SELECT * FROM vwProduct

UPDATE Product SET name = 'hola', description = 'estas', price = 49.00, stock = 30, idCategory = 37, idSupplier = 27, lastUpdate=CURRENT_TIMESTAMP, idUser=5
WHERE id = 3

SELECT id, name, description, price, stock, idCategory, idSupplier,status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), idUser
FROM Product
W

UPDATE Product SET status=1, lastUpdate=CURRENT_TIMESTAMP, idUser=5
WHERE id = 3

SELECT name, id
FROM Category
WHERE status = 1

SELECT name, id
FROM Supplier
WHERE status = 1







