CREATE PROCEDURE sp_InsertarListaPartidos
    @XmlPartidos XML
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @hDoc INT;

    -- Crea un identificador para el documento XML
    EXEC sp_xml_preparedocument @hDoc OUTPUT, @XmlPartidos;

    -- Inserta los datos del XML en la tabla Partido
    INSERT INTO Partido (Fecha, Duracion, NumeroCancha, Ubicacion, Categoria, CampeonatoId)
    SELECT 
        Fecha = CAST(Fecha AS DATETIME),
        Duracion = CAST(Duracion AS INT),
        NumeroCancha = CAST(NumeroCancha AS INT),
        Ubicacion = Ubicacion,
        Categoria = Categoria,
        CampeonatoId = CAST(CampeonatoId AS BIGINT)
    FROM OPENXML (@hDoc, '/Partidos/Partido', 1)
    WITH (
        Fecha DATETIME,
        Duracion INT,
        NumeroCancha INT,
        Ubicacion NVARCHAR(255),
        Categoria NVARCHAR(255),
        CampeonatoId BIGINT
    );

    -- Liberar el documento XML
    EXEC sp_xml_removedocument @hDoc;
END;
GO
