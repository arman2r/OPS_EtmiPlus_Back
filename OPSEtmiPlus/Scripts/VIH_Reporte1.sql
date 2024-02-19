CREATE TABLE VIH_Reporte1 (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdMomentoDiagnostico INT,
    IdPruebaConfirmarVih INT,
    FechaDiagnostico DATETIME,
    IdResultados INT,
    NumeroCopias INT,
    EstabaRecibiendoTARAntesEmbarazo INT,
    RecibioTARDuranteEmbarazo INT,
    EdadGestacionalInicioTARSemanas INT,
    EstabaRecibiendoTARDuranteEmbarazoActual INT,
    EdadGestacionalCuandoRecibioTAR INT,
    EdadGestacionalAlDianosticoVIHSemanas INT,
    MedicamentosARVSuministrados NVARCHAR(MAX) DEFAULT '',
    SeRealizoControlPrenatalDuranteEmbarazo INT,
    EdadGestacionalPrimerControlPrenatalSemanas INT,
    FechaProbableParto DATETIME
);
