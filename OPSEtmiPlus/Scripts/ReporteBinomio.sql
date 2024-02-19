CREATE TABLE ReporteBinomio (
    IdBinomio INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    NombreIPSAtencionVIH NVARCHAR(MAX) NOT NULL DEFAULT '',
    NombreRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CargoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    TelefonoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion1 NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion2 NVARCHAR(MAX) NOT NULL DEFAULT ''
);
