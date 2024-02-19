CREATE TABLE Chagas_DiagnosticoNinoExpuesto (
    IdDiagnosticoNinoExpuesto INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    FechaNacimiento DATETIME,

    -- Prueba Diagnostico al momento de nacer
    IdExamenParasitologico INT,
    ResultadoExamenParasitologico NVARCHAR(MAX) DEFAULT '',
    FechaRecoleccionMuestra DATETIME,
    FechaEmisionResultado DATETIME,

    -- En caso de ser positiva, prueba diagnostico al momento de nacer a los 3 meses de nacido
    SeHacePruebaDiagnostica3Meses INT,
    IdExamenParasitologico3Meses INT,
    ResultadoExamenParasitologico3Meses NVARCHAR(MAX) DEFAULT '',
    FechaRecoleccionMuestra3Meses DATETIME,
    FechaEmisionResultado3Meses DATETIME,

    -- Prueba de diagnostico molecular por criterio clinico o epidemiológico
    SeHacePrueebaDiagnosticoMolecular INT,
    ResultadoPCR NVARCHAR(MAX) DEFAULT '',
    FechaRecolecionPCR DATETIME,
    FechaEmisionPCR DATETIME,
    
    -- Prueba de diagnostico serológico a los 10 meses de nacido si las pruebas de diagnóstico directo al momento y a los 3 meses de nacido son negativas
    SeHacePruebaDiagnostico10Meses INT,
    EsAntigenosTotales INT,
    EsAntigenosRecombinantes INT,
    ResultadoPrueba INT,
    FechaRecoleccionMuestra10Meses DATETIME,
    FechaEmisionResultado10Meses DATETIME,

    -- Confirmación
    EsCasoConfirmadoTMIChagas INT
);