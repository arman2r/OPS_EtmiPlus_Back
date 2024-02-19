CREATE TABLE VIH_Reporte2 (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    TieneCargaViral INT,
    FechaResultado DATETIME,
    ResultadoCargaViral INT
);
