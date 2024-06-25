CREATE PROCEDURE sp_ListarEquipoPorId
    @Id BIGINT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Nombre, Descripcion
    FROM Equipo
    WHERE Id = @Id;
END
