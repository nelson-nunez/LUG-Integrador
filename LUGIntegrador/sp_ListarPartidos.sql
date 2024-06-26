CREATE PROCEDURE sp_ListarPartidos
AS
BEGIN
    SELECT Id, Fecha, Duracion, NumeroCancha, Ubicacion, Categoria 
    FROM Partido
END
