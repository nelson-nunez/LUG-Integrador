CREATE PROCEDURE sp_BajaCampeonato
    @Id BIGINT
AS
BEGIN
    DELETE FROM Campeonato WHERE Id = @Id;
END
