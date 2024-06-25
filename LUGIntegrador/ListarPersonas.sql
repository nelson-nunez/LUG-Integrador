CREATE PROCEDURE ListarPersonas
AS
BEGIN
    SELECT 
        p.Id, 
        p.Nombre, 
        p.Apellido, 
        p.DNI, 
        p.Telefono, 
        p.FechaNacimiento, 
        p.Email,
		p.Password,
        CASE 
            WHEN j.Id IS NOT NULL THEN 'Jugador' 
            WHEN t.Id IS NOT NULL THEN 'Tecnico' 
            ELSE 'Desconocido' 
        END AS Tipo
    FROM 
        Persona p
    LEFT JOIN 
        Jugador j ON p.Id = j.Id
    LEFT JOIN 
        Tecnico t ON p.Id = t.Id;
END;