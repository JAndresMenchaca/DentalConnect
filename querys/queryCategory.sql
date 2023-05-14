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


ALTER VIEW dbo.vwCategory
AS
SELECT id, name AS Categor�a, 
    CASE WHEN description = '' THEN 'No hay descripci�n' ELSE description END AS Descripci�n, 
    registerDate AS 'Registro creado el:'
FROM Category
WHERE status = 1



SELECT *
FROM vwCategory
ORDER BY 2

SELECT id, name, description, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), idUser
FROM Category
