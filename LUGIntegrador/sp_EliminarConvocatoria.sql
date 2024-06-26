CREATE PROCEDURE sp_EliminarConvocatoria
    @Id BIGINT
AS
BEGIN
    DELETE FROM Convocatoria WHERE Id = @Id;
END
GO
