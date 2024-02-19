CREATE TABLE HB_DiagnosticoGestante (
    IdDiagnosticoGestante INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdMomentoDiagnostico INT,
    EdadGestacional INT,
    FechaResultadoReactivo DATETIME,
    ResultadoAntiHBcIgM INT,
    FechaResultadoAntiHBcIgM DATETIME,
    ResultadoAntiHBcTotalOlgG INT,
    FechaResultadoAntiHBcTotalOlgG DATETIME,
    ResultadoAntiHBeAg INT,
    FechaResultadoAntiHBeAg DATETIME,
    ResultadoAntigenoCargaViral INT,
    FechaResultadoCargaViral DATETIME
);
