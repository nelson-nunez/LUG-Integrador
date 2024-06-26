CREATE PROCEDURE sp_GuardarPartido
    @Id BIGINT,
    @Fecha DATETIME,
    @Duracion INT,
    @NumeroCancha INT,
    @Ubicacion NVARCHAR(100),
    @Categoria NVARCHAR(100)
AS
BEGIN
    IF @Id = 0
    BEGIN
        INSERT INTO Partido (Fecha, Duracion, NumeroCancha, Ubicacion, Categoria)
        VALUES (@Fecha, @Duracion, @NumeroCancha, @Ubicacion, @Categoria)
    END
    ELSE
    BEGIN
        UPDATE Partido
        SET Fecha = @Fecha, Duracion = @Duracion, NumeroCancha = @NumeroCancha, Ubicacion = @Ubicacion, Categoria = @Categoria
        WHERE Id = @Id
    END
END
