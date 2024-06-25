ALTER PROCEDURE sp_GuardarPersona
  @Id int,
  @Email varchar(50),
  @Password varchar(50)
AS
BEGIN
  SET NOCOUNT ON;

  IF EXISTS (SELECT 1 FROM Persona WHERE Id = @Id)
  BEGIN
      -- Actualizar la información de la persona
      UPDATE Persona
      SET Email = @Email,
          Password = @Password
      WHERE Id = @Id;

      -- Éxito (actualización)
      SELECT 1 AS Exito;
  END
  ELSE
  BEGIN
      -- Insertar nueva persona
      INSERT INTO Persona (Email, Password)
      VALUES (@Email, @Password);

      -- Éxito (inserción)
      SELECT 1 AS Exito;
  END
END

