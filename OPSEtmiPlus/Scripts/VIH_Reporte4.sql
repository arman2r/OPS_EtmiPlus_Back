CREATE TABLE VIH_Reporte4 (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdTipoRegimenSalud INT,
    NombreAseguradora NVARCHAR(MAX) DEFAULT '',
    NombresApellidos NVARCHAR(MAX) DEFAULT '',
    IdTipoDocumento INT,
    NumeroIdentificacion NVARCHAR(MAX) DEFAULT '',
    IdClasificacionTMINinoExpuesto INT,
    RecibioNinoProfilaxisAntiretroviral INT,
    MedicamentosAntirretroviralNinoExpuesto NVARCHAR(MAX) DEFAULT '',
    SeRealizoADNProviral INT,
    FechaResultadoADNProviral DATETIME,
    ResultadoADNProviral NVARCHAR(MAX) DEFAULT '',
    SeRealizaronCargasVirales INT,
    FechaResultadoCargasVirales DATETIME,
    ResultadoCargasVirales INT,
    OtrasPruebasNinoExpuesto NVARCHAR(MAX) DEFAULT ''
);

