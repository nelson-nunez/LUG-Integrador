CREATE PROCEDURE sp_ListarConvocatoriasPorFiltros
    @CampeonatoId BIGINT = NULL,
    @EquipoId BIGINT = NULL,
    @JugadorId BIGINT = NULL,
    @PartidoId BIGINT = NULL
AS
BEGIN
    SELECT c.Id, c.Posicion, c.Confirmacion, c.Fecha, c.Duracion, c.Ubicacion, c.JugadorId
    FROM Convocatoria c
    WHERE (@CampeonatoId IS NULL OR EXISTS (SELECT 1 FROM Partido p WHERE p.CampeonatoId = @CampeonatoId AND p.Id = c.PartidoId))
      AND (@EquipoId IS NULL OR EXISTS (SELECT 1 FROM Jugador j WHERE j.EquipoId = @EquipoId AND j.Id = c.JugadorId))
      AND (@JugadorId IS NULL OR c.JugadorId = @JugadorId)
      AND (@PartidoId IS NULL OR c.PartidoId = @PartidoId);
END;