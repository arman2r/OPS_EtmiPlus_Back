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

