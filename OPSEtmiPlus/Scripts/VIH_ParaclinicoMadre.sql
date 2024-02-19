CREATE TABLE VIH_ParaclinicoMadre (
    IdParaclinico INT PRIMARY KEY IDENTITY(1,1),
    IdReporte INT FOREIGN KEY REFERENCES VIH_Reporte1(IdReporte),
    IdMomentoDiagnostico INT,
    IdParaclinicoRealizado INT,
    FechaParaclinico DATETIME,
    ResultadoParaclinico INT
);
