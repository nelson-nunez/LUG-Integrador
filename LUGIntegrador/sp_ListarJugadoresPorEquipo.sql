CREATE PROCEDURE sp_ListarJugadoresPorEquipo
    @EquipoId BIGINT
AS
BEGIN
    SELECT p.Id, p.Nombre, p.Apellido, p.DNI, p.Telefono, p.FechaNacimiento, j.Posicion, j.Edad, j.Altura, j.Peso
    FROM Persona p
    INNER JOIN Jugador j ON p.Id = j.Id
    WHERE j.EquipoId = @EquipoId;
END
GO
