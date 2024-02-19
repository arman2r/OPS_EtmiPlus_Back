CREATE TABLE VIH_Reporte3 (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdSituacionGestante INT,
    FechaDelParto DATETIME,
    IdEsquemaAntirretroviralIntraparto INT,
    IdEsquemaArvIntraparto INT,
    IdCondicionRecienNacido INT,
    IdNumeroDeProductosNacimiento INT,
    EdadGestacionalNacimientoSemanas INT,
    PesoRecienNacidoGramos INT,
    IdSexo INT,
    IdTipoParto INT,
    SeRealizoSuprecionLactancia INT,
    MedicamentoSuministrado NVARCHAR(MAX) DEFAULT ''
);
