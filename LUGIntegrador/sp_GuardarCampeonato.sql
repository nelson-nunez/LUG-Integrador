ALTER PROCEDURE sp_GuardarCampeonato
  @Id int,
  @Nombre varchar(100),
  @FechaInicio date,
  @FechaFin date,
  @CantidadPartidos int,
  @CantidadJugadores int
AS
BEGIN
  SET NOCOUNT ON;

  IF EXISTS (SELECT 1 FROM Campeonato WHERE Id = @Id)
  BEGIN
      -- Actualizar la información del campeonato
      UPDATE Campeonato
      SET Nombre = @Nombre,
          FechaInicio = @FechaInicio,
          FechaFin = @FechaFin,
          CantidadPartidos = @CantidadPartidos,
          CantidadJugadores = @CantidadJugadores
      WHERE Id = @Id;

      -- Éxito (actualización)
      SELECT 1 AS Exito;
  END
  ELSE
  BEGIN
      -- Insertar nuevo campeonato
      INSERT INTO Campeonato (Nombre, FechaInicio, FechaFin, CantidadPartidos, CantidadJugadores)
      VALUES (@Nombre, @FechaInicio, @FechaFin, @CantidadPartidos, @CantidadJugadores);

      -- Éxito (inserción)
      SELECT 1 AS Exito;
  END
END
