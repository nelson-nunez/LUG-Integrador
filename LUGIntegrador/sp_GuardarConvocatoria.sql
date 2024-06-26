CREATE PROCEDURE sp_GuardarConvocatoria
    @Id BIGINT OUTPUT,
    @Posicion NVARCHAR(255),
    @Confirmacion BIT,
    @Fecha DATETIME,
    @Duracion TIME,
    @Ubicacion NVARCHAR(255),
    @JugadorId BIGINT,
    @PartidoId BIGINT
AS
BEGIN
    IF @Id > 0
    BEGIN
        -- Actualizar convocatoria existente
        UPDATE Convocatoria
        SET Posicion = @Posicion,
            Confirmacion = @Confirmacion,
            Fecha = @Fecha,
            Duracion = @Duracion,
            Ubicacion = @Ubicacion,
            JugadorId = @JugadorId,
            PartidoId = @PartidoId
        WHERE Id = @Id;
    END
    ELSE
    BEGIN
        -- Insertar nueva convocatoria
        INSERT INTO Convocatoria (Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId)
        VALUES (@Posicion, @Confirmacion, @Fecha, @Duracion, @Ubicacion, @JugadorId, @PartidoId);

        SET @Id = SCOPE_IDENTITY();
    END
END
GO
