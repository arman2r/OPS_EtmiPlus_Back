CREATE TABLE Chagas_DiagnosticoGestante (
    IdDiagnosticoGestante INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdCondicionDiagnosticoChagas INT,
    EdadGestacionalSemanas INT,
    EdadGestacionalPrimerControlPrentalSemanas INT,
    FechaProbableParto DATETIME
);
