CREATE PROCEDURE sp_ObtenerConvocatoriaPorId
    @Id BIGINT
AS
BEGIN
    SELECT Id, Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId
    FROM Convocatoria
    WHERE Id = @Id;
END
GO
