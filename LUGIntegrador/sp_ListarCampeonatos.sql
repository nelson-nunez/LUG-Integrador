CREATE PROCEDURE sp_ListarCampeonatos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Id,
        Nombre,
        FechaInicio,
        FechaFin,
        CantidadPartidos,
        CantidadJugadores
    FROM 
        Campeonato;
END
