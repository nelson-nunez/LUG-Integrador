CREATE PROCEDURE sp_GuardarEquipo
    @Id BIGINT,
    @Nombre NVARCHAR(255),
    @Descripcion NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id = 0
    BEGIN
        -- Insertar nuevo equipo
        INSERT INTO Equipo (Nombre, Descripcion)
        VALUES (@Nombre, @Descripcion);
    END
    ELSE
    BEGIN
        -- Actualizar equipo existente
        UPDATE Equipo
        SET Nombre = @Nombre,
            Descripcion = @Descripcion
        WHERE Id = @Id;
    END
END
