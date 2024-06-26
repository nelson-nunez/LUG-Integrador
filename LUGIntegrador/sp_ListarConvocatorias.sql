CREATE PROCEDURE sp_ListarConvocatorias
AS
BEGIN
    SELECT Id, Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId
    FROM Convocatoria;
END
GO
