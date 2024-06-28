ALTER PROCEDURE sp_reporte
AS
BEGIN
    SELECT 
        c.Posicion,
        c.Fecha,
        c.Ubicacion,
        CONCAT(p.Nombre, ' ', p.Apellido) AS NombreCompleto,
        e.Nombre AS Equipo,
        CASE WHEN c.Confirmacion = 1 THEN 'SI' ELSE 'NO' END AS Confirmacion
    FROM 
        dbo.Convocatoria c
    INNER JOIN 
        dbo.Jugador j ON c.JugadorId = j.Id
    INNER JOIN 
        dbo.Persona p ON j.Id = p.Id
    INNER JOIN 
        dbo.Equipo e ON j.EquipoId = e.Id
END