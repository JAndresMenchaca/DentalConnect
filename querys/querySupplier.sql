INSERT INTO Supplier(name, phone, email, webSite,
					mainStreet, adjacentStreet, idCity, idUser)
VALUES(@name, @phone, @email, @webSite,
		@mainStreet, @adjacentStreet, @idCity, @idUser)


ALTER VIEW vwSupplier
AS
SELECT s.id, s.name AS Proveedor, s.phone AS Teléfono, s.email AS Email, 
    CASE WHEN s.webSite = '' OR s.webSite IS NULL THEN 'No tiene sitio Web' ELSE s.webSite END AS 'Sitio Web',
    s.mainStreet AS 'Calle Principal', 
    CASE WHEN s.adjacentStreet = '' OR s.adjacentStreet IS NULL THEN 'Sin calle adyacente' ELSE s.adjacentStreet END AS 'Calle Adyacente', 
    c.name AS 'Ciudad', s.registerDate AS 'Registro creado el:'
FROM Supplier s
JOIN City c ON s.idCity = c.id
WHERE s.status = 1



SELECT * 
FROM vwSupplier
ORDER BY 2

UPDATE Category SET name = @name, phone = @phone, email = @email, webSite = @website, mainStreet = @mainStreet, adjacentStreet = @adjacentStreet, idCity = @idCity, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser 
WHERE id = @id

UPDATE Supplier SET status=0, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
                       WHERE id = @id

SELECT id, name, phone, email, webSite, mainStreet, adjacentStreet, idCity, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), status, idUser
                        FROM Supplier
                        WHERE id = @id