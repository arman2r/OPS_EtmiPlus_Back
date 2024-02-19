--Principales
CREATE TABLE Gestante (
    IdGestante INT PRIMARY KEY IDENTITY(1,1),
    NombresApellidos NVARCHAR(255) NOT NULL DEFAULT '',
    IdNacionalidad INT NOT NULL,
    IdTipoDocumento INT NOT NULL,
    NumeroDocumento NVARCHAR(MAX) NOT NULL DEFAULT '',
    Edad INT NOT NULL,
    IdTipoRegimenSalud INT NOT NULL,
    NombreAseguradora NVARCHAR(MAX) NOT NULL DEFAULT '',
    IdPertenenciaEtnica INT NOT NULL,
    IdGrupoPoblacional INT NOT NULL,
    IdAreaOcurrencia INT NOT NULL,
    IdDptoResidencia INT NOT NULL,
    IdMunicipioResidencia INT NOT NULL,
    DireccionResidencia NVARCHAR(MAX) NOT NULL DEFAULT '',
    IdDptoAtencion INT NOT NULL,
    IdMunicipioAtencion INT NOT NULL,
    Telefono NVARCHAR(MAX) NOT NULL DEFAULT '',
    FechaPosibleParto DATETIME NULL,
    SeRealizaControlPrenatal INT NULL,
    EdadGestacionalSemanas INT NULL,
);

CREATE TABLE GestanteControl (
    IdGestanteControl INT PRIMARY KEY IDENTITY(1,1),
    IdGestante INT FOREIGN KEY REFERENCES Gestante(IdGestante),
    FechaControl DATETIME
);

CREATE TABLE ReporteBinomio (
    IdBinomio INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    NombreIPSAtencionVIH NVARCHAR(MAX) NOT NULL DEFAULT '',
    NombreRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CargoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    TelefonoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion1 NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion2 NVARCHAR(MAX) NOT NULL DEFAULT ''
);

CREATE TABLE ReporteEAPB (
    IdReporteEAPB INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    FechaReporte DATETIME NOT NULL,
    NombreEAPB NVARCHAR(MAX) NOT NULL DEFAULT '',
    NombreRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CargoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    TelefonoMovilRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    TelefonoFijoRemitenteInformacion NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion1 NVARCHAR(MAX) NOT NULL DEFAULT '',
    CorreoRemitenteInformacion2 NVARCHAR(MAX) NOT NULL DEFAULT ''
);

--VIH
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

CREATE TABLE VIH_Reporte2 (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    TieneCargaViral INT,
    FechaResultado DATETIME,
    ResultadoCargaViral INT
);

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

CREATE TABLE VIH_Reporte5 (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    FechaPruebaRealizadaADNProviral DATETIME,
    IdTipoPrueba INT,
    FechaPrueba DATETIME,
    ResultadoPrueba NVARCHAR(MAX) DEFAULT '',
    IdTipoAlimentacionNinoExpuesto INT,
    IdSituacionNinoExpuesto INT
);

CREATE TABLE VIH_ParaclinicoMadre (
    IdParaclinico INT PRIMARY KEY IDENTITY(1,1),
    IdReporte INT FOREIGN KEY REFERENCES VIH_Reporte1(IdReporte),
    IdMomentoDiagnostico INT,
    IdParaclinicoRealizado INT,
    FechaParaclinico DATETIME,
    ResultadoParaclinico INT
);

CREATE TABLE VIH_ParaclinicoNino (
    IdParaclinico INT PRIMARY KEY IDENTITY(1,1),
    IdReporte INT FOREIGN KEY REFERENCES VIH_Reporte5(IdReporte),
    IdParaclinicoRealizado INT,
    FechaParaclinico DATETIME,
    ResultadoParaclinico INT
);

--Chagas
CREATE TABLE Chagas_DiagnosticoGestante (
    IdDiagnosticoGestante INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdCondicionDiagnosticoChagas INT,
    EdadGestacionalSemanas INT,
    EdadGestacionalPrimerControlPrentalSemanas INT,
    FechaProbableParto DATETIME
);

CREATE TABLE Chagas_DiagnosticoNinoExpuesto (
    IdDiagnosticoNinoExpuesto INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    FechaNacimiento DATETIME,
    IdExamenParasitologico INT,
    ResultadoExamenParasitologico NVARCHAR(MAX) DEFAULT '',
    FechaRecoleccionMuestra DATETIME,
    FechaEmisionResultado DATETIME,
    SeHacePruebaDiagnostica3Meses INT,
    IdExamenParasitologico3Meses INT,
    ResultadoExamenParasitologico3Meses NVARCHAR(MAX) DEFAULT '',
    FechaRecoleccionMuestra3Meses DATETIME,
    FechaEmisionResultado3Meses DATETIME,
    SeHacePrueebaDiagnosticoMolecular INT,
    ResultadoPCR NVARCHAR(MAX) DEFAULT '',
    FechaRecolecionPCR DATETIME,
    FechaEmisionPCR DATETIME,
    SeHacePruebaDiagnostico10Meses INT,
    EsAntigenosTotales INT,
    EsAntigenosRecombinantes INT,
    ResultadoPrueba INT,
    FechaRecoleccionMuestra10Meses DATETIME,
    FechaEmisionResultado10Meses DATETIME,
    EsCasoConfirmadoTMIChagas INT
);

CREATE TABLE Chagas_Algoritmo (
    IdAlgoritmo INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoGestante INT FOREIGN KEY REFERENCES Chagas_DiagnosticoGestante(IdDiagnosticoGestante),
    SospechaChagasAgudo INT,
    IdExamenParasitologico INT,
    ResultadoExamenParasitologico NVARCHAR(MAX) DEFAULT '',
    SospechaChagasCronicoOTamizajeControlPrenatal INT,
    ResultadoPruebaTamizajeElisaAntigenosTotales INT,
    FechaRecoleccionMuestraElisaAntigenosTotales DATETIME,
    FechaEmisionResultadoElisaAntigenosTotales DATETIME,
    ResultadoPruebaTamizajeElisaAntigenosRecombinantes1 INT,
    FechaRecoleccionMuestraRecombinantes1 DATETIME,
    FechaEmisionResultadoRecombinantes1 DATETIME,
    ResultadoPruebaTamizajeInmunocromatografia INT,
    FechaRecoleccionMuestraInmunocromatografia DATETIME,
    FechaEmisionInmunocromatografia DATETIME,
    ResultadoPruebaTamizajeElisaAntigenosRecombinantes2 INT,
    FechaRecoleccionMuestraRecombinantes2 DATETIME,
    FechaEmisionResultadoRecombinantes2 DATETIME,
    TipoPruebaUtilizada NVARCHAR(MAX) DEFAULT '',
    ResultadoPruebaUtilizada NVARCHAR(MAX) DEFAULT '',
    FechaRecoleccionMuestraNoConcordante DATETIME,
    FechaEmisionNoConcordante DATETIME,
    ResultadoPruebaTamizajeElisaAntigenosRecombinantes3 INT,
    FechaRecoleccionMuestraRecombinantes3 DATETIME,
    FechaEmisionResultadoRecombinantes3 DATETIME,
    EsConfirmadoGestanteConChagas INT,
    EsDescartadoGestanteConChagas INT,
    NumeroHijosDiferenteAlEmbarazoParaRealizarDiagnosticoChagas INT
);

CREATE TABLE Chagas_SeguimientoNinoExpuesto (
    IdSeguimientoNinoExpuesto INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoNinoExpuesto INT FOREIGN KEY REFERENCES Chagas_DiagnosticoNinoExpuesto(IdDiagnosticoNinoExpuesto),
    FechaNacimiento DATETIME,
    IdCondicionRecienNacido INT,
    IdNumeroProductosNacimiento INT,
    EdadGestacionalNacimientoSemanas INT,
    PesoGramos INT,
    IdSexo INT,
    IdTipoParto INT,
    IdTipoRegimenSalud INT,
    NombreAseguradoraEAPB NVARCHAR(MAX) DEFAULT '',
    NombresApellidos NVARCHAR(MAX) DEFAULT '',
    IdTipoDocumento INT,
    NumeroIdentificacion NVARCHAR(MAX) DEFAULT ''
);

CREATE TABLE Chagas_TratamientoSeguimientoNino (
    IdTratamientoSeguimientoNino INT PRIMARY KEY IDENTITY(1,1),
    IdSeguimientoNinoExpuesto INT FOREIGN KEY REFERENCES Chagas_SeguimientoNinoExpuesto(IdSeguimientoNinoExpuesto),
    BenznidazolX60Dias INT,
    FechaInicioTratamiento DATETIME,
    NufurtimoxX60Dias INT,
    IdNufurtimoxControlesMedicos INT,
    EsAntigenosTotales6Meses INT,
    EsAntigenosRecombinantes6Meses INT,
    ResultadoPruebaSerologica6Meses NVARCHAR(MAX) DEFAULT '',
    EsAntigenosTotales12Meses INT,
    EsAntigenosRecombinantes12Meses INT,
    ResultadoPruebaSerologica12Meses NVARCHAR(MAX) DEFAULT '',
    EsNinoCuradoChagas INT
);

CREATE TABLE Chagas_TratamientoMaterno (
    IdTratamientoMaterno INT PRIMARY KEY IDENTITY(1,1),
    IdAlgoritmo INT FOREIGN KEY REFERENCES Chagas_Algoritmo(IdAlgoritmo),
    BenznidazolX60Dias INT,
    FechaInicioTratamiento DATETIME,
    NufurtimoxX60Dias INT,
    IdNufurtimoxControlesMedicos INT,
    FinalizacionLactanciaMaterna INT,
    MetodoAnticonceptivoUtilizadoDuranteTratamiento NVARCHAR(MAX) DEFAULT ''
);

--HB
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

CREATE TABLE HB_TratamientoSeguimientoGestante (
    IdTratamientoSeguimiento INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoGestante INT FOREIGN KEY REFERENCES HB_DiagnosticoGestante(IdDiagnosticoGestante),
    RecibioTratamientoAntesEmbarazoActual INT,
    RequiereTratamientoAntesEmbarazoActual INT,
    EdadGestacionalRecibioTratamientoAntesSemana INT,
    RequiereTratamientoDuranteEmbarazoActual INT,
    EdadGestacionalRecibioTratamientoDuranteSemana INT,
    NombreMedicamentoTratamiento NVARCHAR(MAX),
    IdSituacionGestante INT
);

CREATE TABLE HB_SeguimientoNinoExpuesto (
    IdSeguimientoNinoExpuesto INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    IdCondicionRecienNacido INT,
    EdadGestacionalNacimientoSemanas INT,
    IdTipoParto INT,
    IdNumeroProductosNacimiento INT,
    FechaParto DATETIME,
    IdSexo INT,
    IdTipoRegimenSalud INT,
    NombreAseguradora NVARCHAR(MAX),
    DireccionTerritorial NVARCHAR(MAX),
    NombresApellidos NVARCHAR(MAX),
    IdTipoDocumento INT,
    NumeroIdentificacion NVARCHAR(MAX),
    AplicaronDosisVacunaRecienNacido INT,
    IdTiempoAplicacionVacuna INT,
    AplicaronInmunoglobulinaRecienNacido INT,
    IdTiempoAplicacionInmonoglobulina INT
);

CREATE TABLE HB_Vacunacion (
    IdVacuna INT PRIMARY KEY IDENTITY(1,1),
    IdSeguimientoNinoExpuesto INT FOREIGN KEY REFERENCES HB_SeguimientoNinoExpuesto(IdSeguimientoNinoExpuesto),
    IdDosisVacuna INT,
    FechaAplicacion DATETIME
);

CREATE TABLE HB_ClasificacionNinoExpuesto (
    IdClasificacionNinoExpuesto INT PRIMARY KEY IDENTITY(1,1),
    IdSeguimientoNinoExpuesto INT FOREIGN KEY REFERENCES HB_SeguimientoNinoExpuesto(IdSeguimientoNinoExpuesto),
    ResultadoAntiHBsAg INT,
    FechaResultadoAntiHBsAg DATETIME,
    ResultadoAntiHBs INT,
    FechaResultadoAntiHBs DATETIME,
    IdCondicionFinal INT,
    IdClasificacionFinal INT
);


--Sifilis
CREATE TABLE Sifilis_DiagnosticoMaterno (
    IdDiagnosticoMaterno INT PRIMARY KEY IDENTITY(1,1),
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

CREATE TABLE Sifilis_TratamientoMaternoEstadioClinico (
    IdTratamientoMaternoEstadioClinico INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoMaterno INT FOREIGN KEY REFERENCES Sifilis_DiagnosticoMaterno(IdDiagnosticoMaterno),
    IdClasificacionEstadioClinico INT,
    AplicaronPenicilinaBenzatinica INT,
    IdResultadoManejoSifilisGestacional INT,
    SeRealizoDesensibilizacionAplicacionPenicilinaBenzatinica INT,
    IdResultadoPrevenirSifilisCongenita INT
);

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

CREATE TABLE Sifilis_DiagnosticoEIntervencionNino (
    IdDiagnosticoEIntervencionNino INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    EsDiagnosticoDescartado INT,
    SeAplicoDosisProfilacticaPenicilinaBenzatinica INT,
    EsConfirmadoSifilisCongenita INT,
    SeAplicoTratamiento INT,
    RecibioTratamientoDePenicilinaCristalina INT,
    RecibioTratamientoDePenicilinaCristalina10Dias INT,
    IdCriterioUtilizado INT
);

CREATE TABLE Sifilis_SeguimientoNinoPrimerAnio (
    IdSeguimientoNinoPrimerAnio INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoEIntervencionNino INT FOREIGN KEY REFERENCES Sifilis_DiagnosticoEIntervencionNino(IdDiagnosticoEIntervencionNino),
    SeRealizoSeguimiento INT,
    IdTipoPruebaNoTreponemica INT,
    FechaResultado DATETIME,
    IdDilucionesPruebaNoTreponemica INT,
    CumpleCriteriosCuracion INT
);

CREATE TABLE Sifilis_SeguimientoSerologicoGestante (
    IdSeguimientoSerologicoGestante INT PRIMARY KEY IDENTITY(1,1),
    IdTratamientoMaternoEstadioClinico INT FOREIGN KEY REFERENCES Sifilis_TratamientoMaternoEstadioClinico(IdTratamientoMaternoEstadioClinico),
    IdTipoPruebaNoTreponemicaDuranteGestacion INT,
    FechaResultadoPruebaNoTreponemica DATETIME,
    IdDilucionesPruebaNoTreponemicaEsReactiva INT,
    EdadGestacionalRealizacionPruebaNoTreponemica INT
);

CREATE TABLE Sifilis_RetratamientoMaternoGestacional (
    IdRetratamientoMaternoGestacional INT PRIMARY KEY IDENTITY(1,1),
    IdTratamientoMaternoEstadioClinico INT FOREIGN KEY REFERENCES Sifilis_TratamientoMaternoEstadioClinico(IdTratamientoMaternoEstadioClinico),
    RequirioTratamiento INT,
    IdCausaRetratamiento INT,
    AplicaronPenicilinaBenzatinica INT
);

CREATE TABLE Sifilis_SeguimientoContactoSexual (
    IdSeguimientoContactoSexual INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    SeNotifico INT,
    SeRealizoTratamiento INT,
    SeAplicoPenicilinaBenzatinica INT,
    IdDosisPenicilinaBenzatinica INT,
    FechaAplicacionPenicilinaBenzatinica DATETIME,
    NombreMedicamentoDiferentePenicilinaBenzatinica NVARCHAR(MAX)
);

CREATE TABLE Sifilis_AplicacionPenicilinaBenzatinica (
    IdAplicacionPenicilinaBenzatinica INT PRIMARY KEY IDENTITY(1,1),
    IdTratamientoMaternoEstadioClinico INT,
    IdRetratamientoMaternoGestacional INT,
    IdSeguimientoContactoSexual INT,
    EsRetratamiento INT DEFAULT 0,
    IdDosisPenicilinaBenzatinica INT,
    FechaAplicacionPenicilinaBenzatinica DATETIME,
    EdadGestionalAplicacionPenicilinaBenzatinicaSemanas INT,
    FOREIGN KEY (IdTratamientoMaternoEstadioClinico) REFERENCES Sifilis_TratamientoMaternoEstadioClinico(IdTratamientoMaternoEstadioClinico),
    FOREIGN KEY (IdRetratamientoMaternoGestacional) REFERENCES Sifilis_RetratamientoMaternoGestacional(IdRetratamientoMaternoGestacional),
    FOREIGN KEY (IdSeguimientoContactoSexual) REFERENCES Sifilis_SeguimientoContactoSexual(IdSeguimientoContactoSexual)
);

