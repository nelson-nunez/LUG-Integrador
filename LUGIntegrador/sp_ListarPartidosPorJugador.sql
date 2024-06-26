CREATE PROCEDURE sp_ListarPartidosPorJugador
    @JugadorId BIGINT
AS
BEGIN
    SELECT p.Id, p.Fecha, p.Duracion, p.NumeroCancha, p.Ubicacion, p.Categoria
    FROM Partido p
    INNER JOIN Convocatoria c ON p.Id = c.PartidoId
    WHERE c.JugadorId = @JugadorId;
END
GO
