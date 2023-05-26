BEGIN TRANSACTION;

DECLARE @personaId INT;

INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, email, numberPhone, userID)
VALUES ('123456789', 'Steve', 'Doe', 'Smith', '1990-01-01', 'M', 'john.doe@example.com', '1234567890', 1);

SET @personaId = SCOPE_IDENTITY();

INSERT INTO [User] (id,username, password, role, userID)
VALUES (5, 'iam', HASHBYTES('MD5', '456') , 'Administrador', 5);
COMMIT;

CREATE VIEW vwUser
AS
SELECT
    p.id,
    p.ci AS CI,
    p.firstName AS Nombre,
    p.LastName AS 'Primer Apellido',
    CASE
        WHEN p.secondLastName = '' THEN 'Sin apellido'
        ELSE p.secondLastName
    END AS 'Segundo Apellido',
    u.username AS 'Nombre de Usuario',
    u.role AS Rol,
    p.email AS Email,
    p.numberPhone AS Tel�fono,
    p.birthDate AS 'Fecha de Nacimiento',
    p.gender AS Sexo,
    u.registerDate AS 'Usuario creado el:'
FROM
    Person p
INNER JOIN
    [User] u ON p.id = u.id
WHERE
    u.status = 1;

SELECT *
FROM vwUser
ORDER BY 3

UPDATE Person
SET
    ci = '123456789',
    firstName = 'John',
    LastName = 'Doe',
    secondLastName = '',
    email = 'john.doe@example.com',
    numberPhone = '1234567890',
    birthDate = '1990-01-01',
    gender = 'M',
	lastUpdate=CURRENT_TIMESTAMP, 
	userID=1
WHERE
    id = 10;

UPDATE [User]
SET
	lastUpdate=CURRENT_TIMESTAMP, 
	userID=1,
    role = 'Administrador'
WHERE
    id = 5;


UPDATE Person
SET
    ci = @ci,
    firstName = @name,
    LastName = @lastName,
    secondLastName = @SecondLastName,
    email = @email,
    numberPhone = @number,
    birthDate = @date,
    gender = @gender,
	lastUpdate=CURRENT_TIMESTAMP, 
	userID= @userId
WHERE
    id = @id;

UPDATE [User]
SET
	lastUpdate=CURRENT_TIMESTAMP, 
	userID=@userId,
    role = @role
WHERE
    id = @id



UPDATE [User] SET status=1, lastUpdate=CURRENT_TIMESTAMP, userID=1
WHERE id = 5

SELECT *
FROM [User]

SELECT
    p.id,
    p.ci,
    p.firstName,
    p.lastName,
    p.secondLastName,
    p.birthDate,
    p.gender,
    p.email,
    p.numberPhone,
    u.username,
    u.role,
    COALESCE(u.lastUpdate, CURRENT_TIMESTAMP),
    u.registerDate,
    u.status,
    u.userID
FROM
    Person p
INNER JOIN
    [User] u ON p.id = u.id
WHERE u.id = 11

SELECT *
FROM [User]
SELECT
            p.id,
            p.ci,
            p.firstName,
            p.lastName,
            p.secondLastName,
            p.birthDate,
            p.gender,
            p.email,
            p.numberPhone,
            u.username,
            u.role,
            ISNULL(u.lastUpdate, GETDATE()),
            u.registerDate,
            u.status,
            u.userID
            FROM
                Person p
            INNER JOIN
                [User] u ON p.id = u.id
            WHERE u.id = 5

SELECT COUNT(*) FROM [User] WHERE username = 'iam'

SELECT userID, username
FROM [User]
WHERE username = 'dsds'

UPDATE [User] SET password = HASHBYTES('MD5', 'hola') , lastUpdate=CURRENT_TIMESTAMP, userID=5
WHERE id = 5

SELECT id, username, role
                        FROM [User]
                        WHERE status = 1 AND username = 'AMF204' AND password=HASHBYTES('MD5', 'm8bWVrAj')

UPDATE [User] SET password = HASHBYTES('MD5', 'm8bWVrAj') , lastUpdate=CURRENT_TIMESTAMP, userID=5
WHERE id = 28

UPDATE Person
                        SET
	                        lastUpdate=CURRENT_TIMESTAMP, 
	                        userID= @userId
                        WHERE
                            id = @userId;

                        UPDATE [User]
                        SET
							changePassword = 1,
	                        lastUpdate = CURRENT_TIMESTAMP, 
	                        userID=@userId
                        WHERE
                            id = @userId


SELECT COUNT(*) FROM Person p INNER JOIN [User] u ON u.id = p.id WHERE p.email = 'joseandres190503@gmail.com' AND u.id != 33 AND u.status = 1
