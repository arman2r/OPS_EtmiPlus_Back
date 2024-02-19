CREATE TABLE VIH_ParaclinicoNino (
    IdParaclinico INT PRIMARY KEY IDENTITY(1,1),
    IdReporte INT FOREIGN KEY REFERENCES VIH_Reporte5(IdReporte),
    IdParaclinicoRealizado INT,
    FechaParaclinico DATETIME,
    ResultadoParaclinico INT
);
