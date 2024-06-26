CREATE PROCEDURE sp_ListarJugadores
AS
BEGIN
    SELECT j.Id, p.Nombre, p.Apellido, p.DNI, p.Telefono, p.FechaNacimiento, p.Email, j.Posicion, j.Edad, j.Altura, j.Peso, j.EquipoId
    FROM Jugador j
    INNER JOIN Persona p ON j.Id = p.Id;
END
GO

CREATE PROCEDURE sp_ListarJugadorPorId
    @Id BIGINT
AS
BEGIN
    SELECT j.Id, p.Nombre, p.Apellido, p.DNI, p.Telefono, p.FechaNacimiento, p.Email, j.Posicion, j.Edad, j.Altura, j.Peso, j.EquipoId
    FROM Jugador j
    INNER JOIN Persona p ON j.Id = p.Id
    WHERE j.Id = @Id;
END
GO

CREATE PROCEDURE sp_InsertarJugador
    @Id BIGINT = NULL OUTPUT,
    @Nombre NVARCHAR(255),
    @Apellido NVARCHAR(255),
    @DNI NVARCHAR(255),
    @Telefono NVARCHAR(255),
    @FechaNacimiento DATETIME,
    @Email NVARCHAR(255),
    @Password NVARCHAR(255),
    @Posicion NVARCHAR(255),
    @Edad INT,
    @Altura INT,
    @Peso INT,
    @EquipoId BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    MERGE INTO Persona AS p
    USING (SELECT @Nombre AS Nombre, @Apellido AS Apellido, @DNI AS DNI, @Telefono AS Telefono, @FechaNacimiento AS FechaNacimiento, @Email AS Email, @Password AS Password) AS src
    ON (p.DNI = @DNI)
    WHEN MATCHED THEN
        UPDATE SET p.Nombre = src.Nombre, p.Apellido = src.Apellido, p.Telefono = src.Telefono, p.FechaNacimiento = src.FechaNacimiento, p.Email = src.Email, p.Password = src.Password
    WHEN NOT MATCHED THEN
        INSERT (Nombre, Apellido, DNI, Telefono, FechaNacimiento, Email, Password)
        VALUES (src.Nombre, src.Apellido, src.DNI, src.Telefono, src.FechaNacimiento, src.Email, src.Password);
    
    SET @Id = SCOPE_IDENTITY();

    MERGE INTO Jugador AS j
    USING (SELECT @Id AS Id, @Posicion AS Posicion, @Edad AS Edad, @Altura AS Altura, @Peso AS Peso, @EquipoId AS EquipoId) AS src
    ON (j.Id = @Id)
    WHEN MATCHED THEN
        UPDATE SET j.Posicion = src.Posicion, j.Edad = src.Edad, j.Altura = src.Altura, j.Peso = src.Peso, j.EquipoId = src.EquipoId
    WHEN NOT MATCHED THEN
        INSERT (Id, Posicion, Edad, Altura, Peso, EquipoId)
        VALUES (src.Id, src.Posicion, src.Edad, src.Altura, src.Peso, src.EquipoId);
    
    SELECT @Id AS Id;
END
GO


CREATE PROCEDURE sp_BorrarJugador
    @Id BIGINT
AS
BEGIN
    DELETE FROM Jugador WHERE Id = @Id;
    DELETE FROM Persona WHERE Id = @Id;
END
GO
