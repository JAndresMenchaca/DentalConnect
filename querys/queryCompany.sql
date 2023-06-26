SELECT CONCAT(p.firstName, ' ', p.lastName), p.id, p.ci
                                FROM Person p
                                LEFT JOIN [User] u ON p.id = u.id
                                LEFT JOIN Customer c ON p.id = c.id
                                WHERE u.id IS NULL AND c.id IS NULL AND p.status = 1


DELETE FROM Person
WHERE id IN (
  SELECT Person.id
  FROM Person
  LEFT JOIN [User] u ON Person.id = u.id
  LEFT JOIN Customer ON Person.id = Customer.id
  WHERE u.id IS NULL AND Customer.id IS NULL AND Person.id = 96
)


INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, status, email, numberPhone, userID)
VALUES ('1234', 'valor_firstName', 'valor_lastName', 'valor_secondLastName', CURRENT_TIMESTAMP , 'M', 1, 'valor_email', '89898989', 92)

INSERT INTO Company (nit, businessName, phone, contactID, userID, latitude, longitude)
VALUES ('154896', 'valor_businessName', 'valor_phone', 92, 5, -568656, -56721387)

ALTER VIEW vwCompany
AS
<<<<<<< HEAD
SELECT c.id, c.nit AS 'Nit', c.businessName AS 'Nombre de la Empresa', c.phone AS 'Tel�fono', p.ci AS 'Ci',
=======
SELECT c.id, c.nit AS 'Nit', c.businessName AS 'Nombre de la Empresa', c.phone AS 'Teléfono', p.ci AS 'Ci',
>>>>>>> 9e954a2a9728b6c5da8af73a99fb60ccefc7c8c4
		CONCAT(p.firstName, ' ', p.lastName) AS 'Contacto', c.registerDate AS 'Registro creado el:'
FROM Company c
INNER JOIN Person p ON c.contactID = p.id
WHERE p.id = c.contactID AND c.status = 1

UPDATE Company
SET nit = 987665,
    businessName = 'miNombre',
    phone = '455667',
    contactID = 92,
    userID = 5,
    latitude = -342,
    longitude = +6867876
WHERE id = 1


SELECT * FROM vwCompany

SELECT * FROM Company

SELECT * FROM [USer]

SELECT id, nit, businessName, phone, status, registerDate, ISNULL(lastUpdate, CURRENT_TIMESTAMP), contactID, userID, latitude, longitude
FROM Company
WHERE id = 1

UPDATE Company SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=5
WHERE id = 1


INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, status, email, numberPhone, userID)
VALUES ('9457896', 'Juan', 'Alcocer', 'Ramirez', CURRENT_TIMESTAMP , 'M', 1, 'JCA125@gmail.com', '76456751', 5)

INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, status, email, numberPhone, userID)
VALUES ('9045623', 'Maria', 'Rojas', 'Suarez', CURRENT_TIMESTAMP , 'F', 1, 'MRS03@gmail.com', '68459257', 5)

INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, status, email, numberPhone, userID)
VALUES ('7548634', 'Carlos', 'Castillo', '', CURRENT_TIMESTAMP , 'M', 1, 'CC250@gmail.com', '75142356', 5)

INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, status, email, numberPhone, userID)
VALUES ('8945263', 'Lucia', 'Vazquez', '', CURRENT_TIMESTAMP , 'F', 1, 'LV500@gmail.com', '76481237', 5)

INSERT INTO Person (ci, firstName, lastName, secondLastName, birthDate, gender, status, email, numberPhone, userID)
VALUES ('9577126', 'Oscar', 'Prado', 'Cordova', CURRENT_TIMESTAMP , 'M', 1, 'OPC1@gmail.com', '69784552', 5)

SELECT CONCAT(firstName, ' ', lastName) FROM Person WHERE id = 92 

<<<<<<< HEAD
ALTER VIEW vwCompany
AS
SELECT c.id, c.nit AS 'Nit', c.businessName AS 'Nombre de la Empresa', c.phone AS 'Teléfono', p.ci AS 'Ci',
        CONCAT(p.firstName, ' ', p.lastName) AS 'Contacto', c.registerDate AS 'Registro creado el:'
FROM Company c
INNER JOIN Person p ON c.contactID = p.id
WHERE p.id = c.contactID AND c.status = 1


SELECT CONCAT(p.ci,' - ', p.firstName,' ',p.lastName), p.id
                        FROM Person p
                        LEFT JOIN [User] u ON p.id = u.id
                        LEFT JOIN Customer c ON p.id = c.id
                        WHERE u.id IS NULL AND c.id IS NULL AND p.status = '1'
<<<<<<< HEAD
=======

=======
>>>>>>> 413c5d016e5cf0e4c3e4dcfdac943388a551e8e6



>>>>>>> 9e954a2a9728b6c5da8af73a99fb60ccefc7c8c4
