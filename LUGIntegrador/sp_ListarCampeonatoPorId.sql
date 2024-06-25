CREATE PROCEDURE sp_ListarCampeonatoPorId
    @Id BIGINT
AS
BEGIN
    SELECT Id, Nombre, FechaInicio, FechaFin, CantidadPartidos, CantidadJugadores
    FROM Campeonato
    WHERE Id = @Id;
END
