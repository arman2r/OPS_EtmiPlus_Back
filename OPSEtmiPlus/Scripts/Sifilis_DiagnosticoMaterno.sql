CREATE TABLE Sifilis_DiagnosticoMaterno (
    IdDiagnosticoMaternoSifilis INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdMomentoDiagnostico INT,
    EdadGestacionalDuranteSemanas INT,
    SeRealizoControlPrenatalDuranteEmbarazo INT,
    SeRealizoPruebaTreponemica INT,
    IdPruebaTreponemica INT,
    IdResultadoPruebaTreponemica INT,
    FechaResultadoPruebaTreponemica DATETIME,
    EdadGestacionalALaRealizacionPruebaTreponemicaSemanas INT,
    SeRealizoPruebaNoTreponemica INT,
    IdPruebaNoTreponemica INT,
    IdResultadoPruebaNoTreponemica INT,
    FechaResultadoPruebaNoTreponemica DATETIME,
    ReporteDilucionesPruebaNoTreponemicaReactiva NVARCHAR(MAX)
);
