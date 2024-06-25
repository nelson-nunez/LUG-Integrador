CREATE PROCEDURE sp_ListarPartidosPorCampeonato
  @CampeonatoId bigint
AS
BEGIN
  SET NOCOUNT ON;

  SELECT 
      Id,
      Fecha,
      Duracion,
      NumeroCancha,
      Ubicacion,
      Categoria
  FROM 
      Partido
  WHERE 
      CampeonatoId = @CampeonatoId;
END
