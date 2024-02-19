CREATE TABLE ReporteEAPB (
    IdReporteEAPB INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    FechaReporte DATETIME NOT NULL,
    NombreEAPB NVARCHAR(MAX) NOT NULL DEFAULT '',
    NombreRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CargoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    TelefonoMovilRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    TelefonoFijoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion1 NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion2 NVARCHAR(MAX) NOT NULL DEFAULT ''
);
