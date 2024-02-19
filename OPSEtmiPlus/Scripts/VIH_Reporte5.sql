CREATE TABLE VIH_Reporte5 (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    FechaPruebaRealizadaADNProviral DATETIME,
    IdTipoPrueba INT,
    FechaPrueba DATETIME,
    ResultadoPrueba NVARCHAR(MAX) DEFAULT '',
    IdTipoAlimentacionNinoExpuesto INT,
    IdSituacionNinoExpuesto INT
);
