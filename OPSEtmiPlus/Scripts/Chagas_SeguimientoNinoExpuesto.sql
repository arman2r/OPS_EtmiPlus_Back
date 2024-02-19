CREATE TABLE Chagas_SeguimientoNinoExpuesto (
    IdSeguimientoNinoExpuesto INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoNinoExpuesto INT FOREIGN KEY REFERENCES Chagas_DiagnosticoNinoExpuesto(IdDiagnosticoNinoExpuesto),
    FechaNacimiento DATETIME,
    IdCondicionRecienNacido INT,
    IdNumeroProductosNacimiento INT,
    EdadGestacionalNacimientoSemanas INT,
    PesoGramos DOUBLE,
    IdSexo INT,
    IdTipoParto INT,
    IdTipoRegimenSalud INT,
    NombreAseguradoraEAPB NVARCHAR(MAX) DEFAULT '',
    NombresApellidos NVARCHAR(MAX) DEFAULT '',
    IdTipoDocumento INT,
    NumeroIdentificacion NVARCHAR(MAX) DEFAULT ''
);