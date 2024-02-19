CREATE TABLE Sifilis_SituacionGestanteEmbarazoActual (
    IdSituacionGestanteEmbarazoActual INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdSituacionGestante INT,
    FechaParto DATETIME,
    IdCondicionRecienNacido INT,
    IdNumeroProductosNacimiento INT,
    EdadGestacionalNacimientoSemanas INT,
    PesoRecienNacidoGramos INT,
    IdSexo INT,
    IdTipoRegimenSalud INT,
    NombreAseguradora NVARCHAR(MAX) DEFAULT '',
    DireccionTerritorial NVARCHAR(MAX) DEFAULT '',
    NombresApellidos NVARCHAR(MAX) DEFAULT '',
    IdTipoDocumento INT,
    NumeroIdentificacion NVARCHAR(MAX) DEFAULT ''
);
