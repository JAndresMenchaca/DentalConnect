INSERT INTO Supplier(name, phone, email, webSite,
					mainStreet, adjacentStreet, idCity, idUser)
VALUES(@name, @phone, @email, @webSite,
		@mainStreet, @adjacentStreet, @idCity, @idUser)


ALTER VIEW vwSupplier
AS
SELECT id, name AS Proveedor, phone AS Teléfono, email AS Email, 
    CASE WHEN webSite = '' OR webSite IS NULL THEN 'No tiene sitio Web' ELSE webSite END AS 'Sitio Web',
    mainStreet AS 'Calle Principal', 
    CASE WHEN adjacentStreet = '' OR adjacentStreet IS NULL THEN 'Sin calle adyacente' ELSE adjacentStreet END AS 'Calle Adyacente', 
    idCity AS 'Ciudad', registerDate AS 'Registro creado el:'
FROM Supplier
WHERE status=1


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