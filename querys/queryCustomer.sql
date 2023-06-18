/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[nit]
      ,[businessName]
      ,[businessReason]
      ,[status]
      ,[registerDate]
      ,[lastUpdate]
      ,[userID]
      ,[shippingAddress]
  FROM [dbDentalConnect].[dbo].[Customer]

UPDATE Customer SET status=1, lastUpdate=CURRENT_TIMESTAMP, userID=5
	                  WHERE id = 7

UPDATE Customer SET status=0, lastUpdate=CURRENT_TIMESTAMP, userID=@userID
	WHERE id = @id
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
            c.nit,
            c.businessName,
			c.businessReason,
			c.shippingAddress,
            ISNULL(c.lastUpdate, GETDATE()),
            c.registerDate,
            c.status,
            c.userID
            FROM
                Person p
            INNER JOIN
                Customer c ON p.id = c.id
            WHERE c.id = 79



CREATE VIEW vwCustomer
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
	c.businessName AS 'Nombre de la empresa',
	c.nit AS NIT,
	c.businessReason AS 'Razon Social',
	c.shippingAddress AS 'Dirección',
    p.email AS Email,
    p.numberPhone AS 'Teléfono',
    p.birthDate AS 'Fecha de Nacimiento',
    p.gender AS Sexo,
    c.registerDate AS 'Cliente registrado el:'
FROM
    Person p
INNER JOIN
    Customer c ON p.id = c.id
WHERE
    c.status = 1;

SELECT * FROM vwCustomer ORDER BY 3

UPDATE Person
    SET
        ci = 1,
        firstName = 'hola',
        LastName = 'como',
        secondLastName = 'estas',
        email = 'yo',
        numberPhone = '123456',
        birthDate = CURRENT_TIMESTAMP,
        gender = 'M',
	    lastUpdate=CURRENT_TIMESTAMP, 
	    userID= 5
    WHERE
        id = 7;

    UPDATE Customer
    SET
	    lastUpdate=CURRENT_TIMESTAMP,
		businessName = 'bien',
		nit = '456',
		businessReason = 'grax',
		shippingAddress = 'mi esquina',
	    userID=5
        
    WHERE
        id = 7

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
                c.nit,
                c.businessName,
                c.businessReason,
                c.shippingAddress,
                c.lastUpdate,
                c.registerDate,
                c.status,
                c.userID
            FROM
                Person p
            INNER JOIN
                Customer c ON p.id = c.id
            WHERE c.id = 7