USE dbDentalConnect
INSERT INTO Category(name, description, idUser)
VALUES(@name, @description, @idUser)

UPDATE Category SET name=@name, description=@description, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
WHERE id = @id

UPDATE Category SET status=0, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
WHERE id = @id

CREATE VIEW vwCategory
AS
SELECT id, name AS Categoría, registerDate AS 'Se creó en: '
FROM Category
WHERE status=1


SELECT *
FROM vwCategory
ORDER BY 2
