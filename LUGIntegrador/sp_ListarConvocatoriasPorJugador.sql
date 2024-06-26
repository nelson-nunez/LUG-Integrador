CREATE PROCEDURE sp_ListarConvocatoriasPorJugador
    @JugadorId BIGINT
AS
BEGIN
    SELECT Id, Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId
    FROM Convocatoria
    WHERE JugadorId = @JugadorId;
END
GO
