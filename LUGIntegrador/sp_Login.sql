CREATE PROCEDURE sp_Login 
  @Email varchar(50),
  @Password varchar(50)
AS
BEGIN
  SET NOCOUNT ON; -- Para evitar contar los mensajes de "número de filas afectadas"

  SELECT 
    p.Id,
    p.Nombre,
    p.Apellido,
    p.DNI,
    p.Telefono,
    p.FechaNacimiento,
    Tipo = CASE 
             WHEN j.Id IS NOT NULL THEN 'Jugador' 
             WHEN t.Id IS NOT NULL THEN 'Tecnico' 
             ELSE NULL 
           END
  FROM 
    Persona p
    LEFT JOIN Jugador j ON p.Id = j.Id
    LEFT JOIN Tecnico t ON p.Id = t.Id
  WHERE 
    p.Email = @Email 
    AND p.Password = @Password;
END
