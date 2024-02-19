CREATE TABLE Chagas_Algoritmo (
    IdAlgoritmo INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoGestante INT FOREIGN KEY REFERENCES Chagas_DiagnosticoGestante(IdDiagnosticoGestante),
    SospechaChagasAgudo INT,
    IdExamenParasitologico INT,
    ResultadoExamenParasitologico NVARCHAR(MAX) DEFAULT '',
    SospechaChagasCronicoOTamizajeControlPrenatal INT,

    -- Algoritmo1 (Serologia para deteccion de anticuerpos totales contra Tripanozoma Cruzi por dos tecnicas de ELISA)
    ResultadoPruebaTamizajeElisaAntigenosTotales INT,
    FechaRecoleccionMuestraElisaAntigenosTotales DATETIME,
    FechaEmisionResultadoElisaAntigenosTotales DATETIME,
    ResultadoPruebaTamizajeElisaAntigenosRecombinantes1 INT,
    FechaRecoleccionMuestraRecombinantes1 DATETIME,
    FechaEmisionResultadoRecombinantes1 DATETIME,

    -- Algoritmo2 (Serología con la primera prueba rápida y la segunda ELISA recombinante)
    ResultadoPruebaTamizajeInmunocromatografia INT,
    FechaRecoleccionMuestraInmunocromatografia DATETIME,
    FechaEmisionInmunocromatografia DATETIME,
    ResultadoPruebaTamizajeElisaAntigenosRecombinantes2 INT,
    FechaRecoleccionMuestraRecombinantes2 DATETIME,
    FechaEmisionResultadoRecombinantes2 DATETIME,

    -- Pruebas no concordantes (tercera para decidir resultado)
    TipoPruebaUtilizada NVARCHAR(MAX) DEFAULT '',
    ResultadoPruebaUtilizada NVARCHAR(MAX) DEFAULT '',
    FechaRecoleccionMuestraNoConcordante DATETIME,
    FechaEmisionNoConcordante DATETIME,
    ResultadoPruebaTamizajeElisaAntigenosRecombinantes3 INT,
    FechaRecoleccionMuestraRecombinantes3 DATETIME,
    FechaEmisionResultadoRecombinantes3 DATETIME,

    -- Confirmación
    EsConfirmadoGestanteConChagas INT,
    EsDescartadoGestanteConChagas INT,
    NumeroHijosDiferenteAlEmbarazoParaRealizarDiagnosticoChagas INT
);

