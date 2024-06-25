CREATE PROCEDURE ActualizarCampeonato
    @Id INT,
    @Nombre NVARCHAR(100),
    @FechaInicio DATE,
    @FechaFin DATE,
    @CantidadPartidos INT,
    @CantidadJugadores INT,
    @Resultado BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Campeonato
    SET Nombre = @Nombre,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        CantidadPartidos = @CantidadPartidos,
        CantidadJugadores = @CantidadJugadores
    WHERE Id = @Id;

    IF @@ROWCOUNT > 0
        SET @Resultado = 1;
    ELSE
        SET @Resultado = 0;
END