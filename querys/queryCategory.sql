USE dbDentalConnect
INSERT INTO Category(name, description, idUser)
VALUES(@name, @description, @idUser)

UPDATE Category SET name=@name, description=@description, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
WHERE id = @id

UPDATE Category SET status=0, lastUpdate=CURRENT_TIMESTAMP, idUser=@idUser
WHERE id = @id

CREATE VIEW vwCategory
AS
SELECT id, name AS Categor�a, registerDate AS 'Se cre� en: '
FROM Category
WHERE status=1


SELECT *
FROM vwCategory
ORDER BY 2
