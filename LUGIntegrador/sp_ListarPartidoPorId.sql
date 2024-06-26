CREATE PROCEDURE sp_ListarPartidoPorId
    @Id BIGINT
AS
BEGIN
    SELECT Id, Fecha, Duracion, NumeroCancha, Ubicacion, Categoria 
    FROM Partido
    WHERE Id = @Id
END
